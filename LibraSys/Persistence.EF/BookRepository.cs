using Domian.Model.Book;
using FilterSharp.Extensions;
using FilterSharp.Input;
using Framework.FluentFilter;
using Framework.Response;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EF;

public class BookRepository : IBookRepository
{
    private readonly LibraSysContext _libraSysContext;

    public BookRepository(LibraSysContext libraSysContext)
    {
        _libraSysContext = libraSysContext;
    }
    public async Task<ServiceResponse> GetBook(int id)
    {
        var data=await _libraSysContext.Books.FirstOrDefaultAsync(x=>x.Id==id);
        return data.ToServiceResponse();
    }

    public async Task<ServiceResponse> GetListBook(DataQueryRequest request)
    {
        var applyQuery = await _libraSysContext.Books.Where(x=>!x.IsDeleted).ApplyQueryAsResultAsync(request);
        return applyQuery.ToServiceResponse();
    }

    public async Task<ServiceResponse> Create(Book book)
    {
        _libraSysContext.Books.Add(book);
        var saveChangesAsync = await _libraSysContext.SaveChangesAsync();
        return saveChangesAsync.ToServiceResponse();
    }

    public async Task<ServiceResponse> UpdateBook(Book book)
    {
        _libraSysContext.Books.Update(book);
        var saveChangesAsync = await _libraSysContext.SaveChangesAsync();
        return saveChangesAsync.ToServiceResponse();
    }
}