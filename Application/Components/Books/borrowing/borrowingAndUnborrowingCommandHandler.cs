using Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Books.borrowing
{
    public class borrowingAndUnborrowingCommandHandler : IRequestHandler<borrowingAndUnborrowingCommand, OutputResponse<bool>>
    {
        private readonly IBook book;

        public borrowingAndUnborrowingCommandHandler(IBook book)
        {
            this.book = book;
        }
        public async Task<OutputResponse<bool>> Handle(borrowingAndUnborrowingCommand request, CancellationToken cancellationToken)
        {
            return await book.borrowingAndUnborrowing(request);
        }
    }
}
