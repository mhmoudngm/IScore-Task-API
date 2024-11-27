

using Application.Common.Responses;
using MediatR;

namespace Application.Components.Books.Edit
{
    public class EditBookCommandHandler : IRequestHandler<EditBookCommand, OutputResponse<EditBookCommandResult>>
    {
        private readonly IBook book;

        public EditBookCommandHandler(IBook book)
        {
            this.book = book;
        }
        public async Task<OutputResponse<EditBookCommandResult>> Handle(EditBookCommand request, CancellationToken cancellationToken)
        {
            return await book.EditBookInfo(request);
        }
    }
}
