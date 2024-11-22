using Application.Common.Responses;
using Application.Components.Books;
using Application.Components.Books.Create;
using AutoMapper;
using Domain.Entities;
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

        public BookRepo(AppDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<OutputResponse<CreateNewBookCommandResult>> CreateNewBook(CreateNewBookCommand command)
        {
            //Map Command To Book Entity
            var MappedObj = mapper.Map<Book>(command);
            await context.Books.AddAsync(MappedObj);
            await context.SaveChangesAsync();

            return new OutputResponse<CreateNewBookCommandResult>()
            {
                StatusCode= HttpStatusCode.OK,
                Success= true,
                Message = "Book Added Successfully",
                Model = new CreateNewBookCommandResult()
                {
                    Resut = true,
                    Title = command.Title,
                }
            };
        }
    }
}
