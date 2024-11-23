using Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Author.Create
{
    public class CreateNewAuthorCommandHandler : IRequestHandler<CreateNewAuthorCommand, OutputResponse<bool>>
    {
        private readonly IAuthor author;

        public CreateNewAuthorCommandHandler(IAuthor author)
        {
            this.author = author;
        }
        public async Task<OutputResponse<bool>> Handle(CreateNewAuthorCommand request, CancellationToken cancellationToken)
        {
            return await author.CreateNewAuthor(request);
        }
    }
}
