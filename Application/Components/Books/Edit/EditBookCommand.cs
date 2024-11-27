

using Application.Common.Responses;
using MediatR;

namespace Application.Components.Books.Edit
{
    public class EditBookCommand:IRequest<OutputResponse<EditBookCommandResult>>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Quantity { get; set; }
        public Guid AuthorId { get; set; }
    }
}
