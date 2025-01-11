using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Domian.Model.Book;
using Microsoft.EntityFrameworkCore;
using Persistence.EF.Configuration;

namespace Persistence.EF;

public class LibraSysContext(DbContextOptions<LibraSysContext> options, DbSet<Book> books)
    : DbContext(options)
{
    public DbSet<Book> Books { get; set; } = books;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new BookConfiguration());
    }
}