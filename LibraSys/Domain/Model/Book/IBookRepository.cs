using FilterSharp.Input;
using Framework.Response;
using Framework.TransientService;

namespace Domian.Model.Book;

public interface IBookRepository:IScopedService
{
    Task<ServiceResponse> GetBook(int id);
    Task<ServiceResponse> GetListBook(DataQueryRequest request);
    Task<ServiceResponse> AddBook(Book book);
    Task<ServiceResponse> UpdateBook(Book book);
}