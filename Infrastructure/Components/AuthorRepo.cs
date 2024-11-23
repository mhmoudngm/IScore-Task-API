using Application.Common.Responses;
using Application.Components.Author;
using Application.Components.Author.Create;
using Application.Components.Author.List;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infrastructure.Components
{
    public class AuthorRepo : IAuthor
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IUserContext userContext;

        public AuthorRepo(AppDbContext context, IMapper mapper,IUserContext userContext)
        {
            this.context = context;
            this.mapper = mapper;
            this.userContext = userContext;
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

        public async Task<OutputResponse<GetAllAuthorsQueryResult>> GetAllAuthors(GetAllAuthorsQuery query)
        {
            var AllAuthors = await context.Authors.AsNoTracking().ToListAsync();

            var Maplist = mapper.Map<List<AuthorDto>>(AllAuthors);
            return new OutputResponse<GetAllAuthorsQueryResult>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Model = new GetAllAuthorsQueryResult() { Collection = Maplist }
            };
        }
    }
}
