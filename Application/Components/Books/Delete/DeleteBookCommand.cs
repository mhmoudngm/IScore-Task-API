
using Application.Common.Responses;
using MediatR;

namespace Application.Components.Books.Delete
{
    public class DeleteBookCommand : IRequest<OutputResponse<DeleteBookCommandResult>>
    {
        public Guid Id { get; set; }
    }
}
