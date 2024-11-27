using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UsersBooks
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public Book Book { get; set; }
        public Guid BookId { get; set; }
    }
}
