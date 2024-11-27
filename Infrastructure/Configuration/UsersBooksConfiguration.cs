using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class UsersBooksConfiguration : IEntityTypeConfiguration<UsersBooks>
    {
        public void Configure(EntityTypeBuilder<UsersBooks> builder)
        {
            builder.HasOne(i => i.User)
                 .WithMany(i => i.UsersBooks)
                 .HasForeignKey(i => i.UserId);

            builder.HasOne(i => i.Book)
               .WithMany(i => i.UsersBooks)
               .HasForeignKey(i => i.BookId);
        }
    }
}
