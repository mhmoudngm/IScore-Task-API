using Domain.Entities;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) 
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<UsersBooks> UsersBooks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(BookConfiguration))!);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(AuthorConfiguration))!);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(UsersBooksConfiguration))!);
        }
    }
}
