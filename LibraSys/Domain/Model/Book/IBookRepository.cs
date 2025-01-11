using FilterSharp.Input;
using Framework.Response;
using Framework.TransientService;

namespace Domian.Model.Book;

public interface IBookRepository:IInjectScore
{
    Task<ServiceResponse> GetBook(int id);
    Task<ServiceResponse> GetListBook(DataQueryRequest request);
    Task<ServiceResponse> Create(Book book);
    Task<ServiceResponse> UpdateBook(Book book);
}