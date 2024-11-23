using Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Author.List
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, OutputResponse<GetAllAuthorsQueryResult>>
    {
        private readonly IAuthor author;

        public GetAllAuthorsQueryHandler(IAuthor author)
        {
            this.author = author;
        }
        public async Task<OutputResponse<GetAllAuthorsQueryResult>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await author.GetAllAuthors(request);
        }
    }
}
