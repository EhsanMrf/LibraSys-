using Application.Contract.Dto;
using Application.Contract.IService;
using FilterSharp.Input;

namespace API.EndPoint;

public static class BookEndPoint
{

    public static void MapBookEndPoints(this IEndpointRouteBuilder endpoint)
    {
        var group = endpoint.MapGroup("book");
        group.MapGet("/{id}", async (int id, IBookService service) => await service.GetById(id));
        group.MapPost("/get-list", async (int page,int pageNumber, IBookService service) => await service.GetList(new DataQueryRequest
        {
            PageNumber = page,
            PageSize = pageNumber
        }));


        group.MapPost("/add", async (BookCreateDto input, IBookService service) => await service.Create(input));
        group.MapPut("/{id}/update", async (int id, BookCreateDto input, IBookService service) => await service.Update(id,input));
        group.MapDelete("/{id}/delete", async (int id, IBookService service) => await service.Delete(id));
    }
}