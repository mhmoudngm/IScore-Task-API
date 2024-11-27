using Application.Common.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Books.Delete
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, OutputResponse<DeleteBookCommandResult>>
    {
        private readonly IBook book;

        public DeleteBookCommandHandler(IBook book)
        {
            this.book = book;
        }
        public async Task<OutputResponse<DeleteBookCommandResult>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return await book.DeleteBook(request);
        }
    }
}
