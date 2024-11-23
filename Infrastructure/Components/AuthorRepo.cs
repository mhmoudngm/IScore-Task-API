using Application.Common.Responses;
using Application.Components.Author;
using Application.Components.Author.Create;
using Application.Components.Books.Create;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Components
{
    public class AuthorRepo : IAuthor
    {
        private readonly AppDbContext context;

        public AuthorRepo(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<OutputResponse<bool>> CreateNewAuthor(CreateNewAuthorCommand command)
        {
            Author author = new Author() { Name = command.Name };
            context.Authors.Add(author);
            await context.SaveChangesAsync();
            return new OutputResponse<bool>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Message = "Author Added Successfully",
                Model = true
            };
        }
    }
}
