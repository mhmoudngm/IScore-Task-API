using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Id)
              .ValueGeneratedOnAdd();

            builder.Property(b => b.IsDeleted)
             .HasDefaultValue(false)
             .IsRequired();

            builder.HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);

            builder.Property(x => x.Title)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.CreatedBy).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.PublishedDate).IsRequired();
        }
    }
}
