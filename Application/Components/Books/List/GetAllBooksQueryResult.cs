using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Components.Books.List
{
    public class GetAllBooksQueryResult
    {
        public List<BookDto> Collection { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string AuthorName { get; set; }
        public Guid AuthorId { get; set; }
        public bool borrowing { get; set; }
    }
}
