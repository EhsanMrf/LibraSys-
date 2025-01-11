using Domian.Model.Book;
using Framework.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence.EF.Configuration;
using System.Linq.Expressions;

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


        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var clrType = entityType.ClrType;

            if (clrType.BaseType is {IsGenericType: true} &&
                clrType.BaseType.GetGenericTypeDefinition() == typeof(BaseEntity<>))
            {
                modelBuilder.Entity(clrType).HasQueryFilter(CreateIsDeletedFilter(clrType));
            }
        }
    }

    private LambdaExpression CreateIsDeletedFilter(Type entityType)
    {
        var parameter = Expression.Parameter(entityType, "e");
        var property = Expression.Property(parameter, nameof(BaseEntity<object>.IsDeleted));
        var condition = Expression.Equal(property, Expression.Constant(false));

        return Expression.Lambda(condition, parameter);
    }
}