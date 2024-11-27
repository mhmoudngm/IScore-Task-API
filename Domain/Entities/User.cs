using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public ICollection<UsersBooks> UsersBooks { get; set; }
    }
}
