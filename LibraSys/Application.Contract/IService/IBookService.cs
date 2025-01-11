using Application.Contract.Dto;
using FilterSharp.Input;
using Framework.Response;
using Framework.TransientService;

namespace Application.Contract.IService;

public interface IBookService :IInjectScore
{
    Task<ServiceResponse> GetById(int id);
    Task<ServiceResponse> GetList(DataQueryRequest request);
    Task<ServiceResponse> Create(BookCreateDto book);
    Task<ServiceResponse> Update(int id, BookCreateDto book);
    Task<ServiceResponse> Delete(int id);
}