

using Application.Common.Responses;
using MediatR;

namespace Application.Components.Books.Create
{
    public class CreateNewBookCommandHandler : IRequestHandler<CreateNewBookCommand, OutputResponse<CreateNewBookCommandResult>>
    {
        private readonly IBook book;

        public CreateNewBookCommandHandler(IBook book)
        {
            this.book = book;
        }
        public async Task<OutputResponse<CreateNewBookCommandResult>> Handle(CreateNewBookCommand request, CancellationToken cancellationToken)
        {
            return await book.CreateNewBook(request);
        }
    }
}
