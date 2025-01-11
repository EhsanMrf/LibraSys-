using FilterSharp.Input;
using Framework.Response;

namespace Domian.Model.Book;

public interface IBookRepository
{
    Task<ServiceResponse> GetBook(int id);
    Task<ServiceResponse> GetListBook(DataQueryRequest request);
    Task<ServiceResponse> AddBook(Book book);
    Task<ServiceResponse> UpdateBook(Book book);
}