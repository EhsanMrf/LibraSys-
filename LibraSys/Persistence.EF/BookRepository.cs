using Domian.Model.Book;
using FilterSharp.Extensions;
using FilterSharp.Input;
using Framework.FluentFilter;
using Framework.Response;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EF;

public class BookRepository(LibraSysContext libraSysContext) : IBookRepository
{
    public async Task<ServiceResponse> GetBook(int id)
    {
        var data=await libraSysContext.Books.FirstOrDefaultAsync(x=>x.Id==id);
        return data.ToServiceResponse();
    }

    public async Task<ServiceResponse> GetListBook(DataQueryRequest request)
    {
        var applyQuery = await libraSysContext.Books.Where(x=>!x.IsDeleted).ApplyQueryAsResultAsync(request);
        return applyQuery.ToServiceResponse();
    }

    public async Task<ServiceResponse> AddBook(Book book)
    {
        libraSysContext.Books.Add(book);
        var saveChangesAsync = await libraSysContext.SaveChangesAsync();
        return saveChangesAsync.ToServiceResponse();
    }

    public async Task<ServiceResponse> UpdateBook(Book book)
    {
        libraSysContext.Books.Update(book);
        var saveChangesAsync = await libraSysContext.SaveChangesAsync();
        return saveChangesAsync.ToServiceResponse();
    }
}