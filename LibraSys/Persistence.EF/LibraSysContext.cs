using Domian.Model.Book;
using Microsoft.EntityFrameworkCore;
using Persistence.EF.Configuration;

namespace Persistence.EF;

public class LibraSysContext : DbContext
{
    public LibraSysContext(DbContextOptions<LibraSysContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new BookConfiguration());
    }
}