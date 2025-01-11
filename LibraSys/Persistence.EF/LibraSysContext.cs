using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Domian.Model.Book;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EF;

public class LibraSysContext(DbContextOptions<LibraSysContext> dbContextOptions) :DbContext
{
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        ApplyOwnsOne(builder);
    }
    
    private void ApplyOwnsOne(ModelBuilder builder)
    {
        var entityTypes = builder.Model.GetEntityTypes();

        foreach (var entityType in entityTypes)
        {
            var clrType = entityType.ClrType;

            var ownedProperties = clrType.GetProperties()
                .Where(p => typeof(IValidatableObject).IsAssignableFrom(p.PropertyType))
                .ToList();

            foreach (var property in ownedProperties)
            {
                var navigationBuilder = builder.Entity(clrType).OwnsOne(property.PropertyType, property.Name);

                foreach (var prop in property.PropertyType.GetProperties())
                {
                    var maxLengthAttribute = prop.GetCustomAttribute<MaxLengthAttribute>();
                    if (maxLengthAttribute != null)
                        navigationBuilder.Property(prop.Name).HasMaxLength(maxLengthAttribute.Length);
                }
            }
        }

    }
}