

using Application.Common.Responses;
using MediatR;

namespace Application.Components.Books.Create
{
    public class CreateNewBookCommand : IRequest<OutputResponse<CreateNewBookCommandResult>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Quantity { get; set; }
        public Guid AuthorId { get; set; }
    }
}
