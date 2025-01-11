using Application.Contract.Dto;
using FilterSharp.Input;
using Framework.Response;
using Framework.TransientService;

namespace Application.Contract.IService;

public interface IBookService :IScopedService
{
    Task<ServiceResponse> GetById(int id);
    Task<ServiceResponse> GetList(DataQueryRequest request);
    Task<ServiceResponse> Add(BookDto book);
    Task<ServiceResponse> Update(int id,BookDto book);
}