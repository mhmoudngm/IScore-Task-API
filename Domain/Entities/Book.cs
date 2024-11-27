

namespace Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public string CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
        public ICollection<UsersBooks> UsersBooks { get; set; }
    }
}
