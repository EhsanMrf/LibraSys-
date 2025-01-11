using Domian.Model.Book;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EF.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Book");
        builder.Property(x => x.Id);


        builder.OwnsOne(b => b.BookTitle, titleBuilder =>
        {
            titleBuilder.Property(t => t.Title).HasMaxLength(70).IsRequired();
        });  
        
        builder.OwnsOne(b => b.PublishYear, pubYear =>
        {
            pubYear.Property(t => t.PublishYear).IsRequired();
        });
    }
}