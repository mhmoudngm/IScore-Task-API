using Application.Common.Responses;
using Application.Components.Author.List;
using Application.Components.Books;
using Application.Components.Books.borrowing;
using Application.Components.Books.Create;
using Application.Components.Books.Delete;
using Application.Components.Books.Edit;
using Application.Components.Books.List;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Components
{
    public class BookRepo : IBook
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IUserContext userContext;

        public BookRepo(AppDbContext context, IMapper mapper, IUserContext userContext)
        {
            this.context = context;
            this.mapper = mapper;
            this.userContext = userContext;
        }

        public async Task<OutputResponse<bool>> borrowingAndUnborrowing(borrowingAndUnborrowingCommand command)
        {
            //get current user
            var CurrentUser = await userContext.GetCurrentUser();
            //check if this book already borrowed from this user or not
            var check = context.UsersBooks.FirstOrDefault(i => i.UserId == CurrentUser.UserId && i.BookId == command.Id);
            if (check != null)
                context.UsersBooks.Remove(check);
            else
                await context.UsersBooks.AddAsync(new UsersBooks() { BookId = command.Id, UserId = CurrentUser.UserId });


            await context.SaveChangesAsync();
            return new OutputResponse<bool>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Message = "Book borrowed Successfully",
                Model = true
            };
        }

        public async Task<OutputResponse<CreateNewBookCommandResult>> CreateNewBook(CreateNewBookCommand command)
        {
            //Map Command To Book Entity
            var MappedObj = mapper.Map<Book>(command);
            var CurrentUser = await userContext.GetCurrentUser();
            MappedObj.CreatedBy = CurrentUser?.UserId;
            await context.Books.AddAsync(MappedObj);
            await context.SaveChangesAsync();

            return new OutputResponse<CreateNewBookCommandResult>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Message = "Book Added Successfully",
                Model = new CreateNewBookCommandResult()
                {
                    Result = true,
                    Title = command.Title,
                }
            };
        }

        public async Task<OutputResponse<DeleteBookCommandResult>> DeleteBook(DeleteBookCommand command)
        {
            var Book = await context.Books.FirstOrDefaultAsync(i => i.Id == command.Id);
            Book.IsDeleted = true;
            await context.SaveChangesAsync();

            return new OutputResponse<DeleteBookCommandResult>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Message = "Book Deleted Successfully",
                Model = new DeleteBookCommandResult()
                {
                    Result = true,
                }
            };
        }

        public async Task<OutputResponse<EditBookCommandResult>> EditBookInfo(EditBookCommand command)
        {
            var CurrentUser = await userContext.GetCurrentUser();
            var book = await context.Books.FirstOrDefaultAsync(i => i.Id == command.Id);
            book.Title = command.Title;
            book.Description = command.Description;
            book.AuthorId = command.AuthorId;
            book.Quantity = command.Quantity;
            book.PublishedDate = command.PublishedDate;
            book.ModifiedBy = CurrentUser?.UserId;
            book.LastModifiedDate = DateTime.Now;
            await context.SaveChangesAsync();

            return new OutputResponse<EditBookCommandResult>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Message = "Book Updated Successfully",
                Model = new EditBookCommandResult()
                {
                    Result = true,
                }
            };
        }

        public async Task<OutputResponse<GetAllBooksQueryResult>> GetAllBooks(GetAllBooksQuery query)
        {
            if (query.PageSize <= 0) query.PageSize = 10;
            if (query.PageNumber <= 0) query.PageNumber = 1;

            var AllBooks = await context.Books.Include(i => i.Author).AsNoTracking().Where(i => !i.IsDeleted && (string.IsNullOrEmpty(query.Term) ||
            (i.Title.Contains(query.Term) || i.Author.Name.Contains(query.Term) || i.PublishedDate.ToString().Contains(query.Term))))
                .ToListAsync();
            var AllFilteredBooks = AllBooks.Where(i => !i.IsDeleted && (string.IsNullOrEmpty(query.Term) ||
       (i.Title.Contains(query.Term) || i.Author.Name.Contains(query.Term) || i.PublishedDate.ToString().Contains(query.Term))))
           .Skip(query.PageSize * (query.PageNumber - 1)).Take(query.PageSize).ToList();

            var Maplist = mapper.Map<List<BookDto>>(AllFilteredBooks);
            var CurrentUser = await userContext.GetCurrentUser();
            foreach (var book in Maplist)
            {
               book.borrowing = context.UsersBooks.Any(i => i.UserId == CurrentUser.UserId && i.BookId == book.Id);
            }
            var TotalCount = AllBooks.Count();
            var TotalPages = TotalCount / query.PageSize;
            if (TotalCount % query.PageSize > 0)
                TotalPages++;

            return new OutputResponse<GetAllBooksQueryResult>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Model = new GetAllBooksQueryResult() { Collection = Maplist, TotalCount = TotalCount, TotalPages = TotalPages }
            };
        }
    }
}
