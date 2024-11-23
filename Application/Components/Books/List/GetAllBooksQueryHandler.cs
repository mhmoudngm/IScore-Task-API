using Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Books.List
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, OutputResponse<GetAllBooksQueryResult>>
    {
        private readonly IBook book;

        public GetAllBooksQueryHandler(IBook book)
        {
            this.book = book;
        }
        public async Task<OutputResponse<GetAllBooksQueryResult>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
          return  await book.GetAllBooks(request);
        }
    }
}
