using Application.Common.Responses;
using Application.Components.Author.List;
using Application.Components.Books;
using Application.Components.Books.Create;
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
                    Resut = true,
                    Title = command.Title,
                }
            };
        }

        public async Task<OutputResponse<GetAllBooksQueryResult>> GetAllBooks(GetAllBooksQuery query)
        {
            if (query.PageSize <= 0) query.PageSize = 10;
            if (query.PageNumber <= 0) query.PageNumber = 1;

            var AllBooks = await context.Books.Include(i => i.Author).AsNoTracking().Where(i => string.IsNullOrEmpty(query.Term) ||
            (i.Title.Contains(query.Term) || i.Author.Name.Contains(query.Term) || i.PublishedDate.ToString().Contains(query.Term)))
                .Skip(query.PageSize * (query.PageNumber - 1)).Take(query.PageSize).ToListAsync();

            var Maplist = mapper.Map<List<BookDto>>(AllBooks);
            var TotalCount = Maplist.Count();
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
