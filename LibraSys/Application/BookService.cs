using Application.Contract.Dto;
using Application.Contract.IService;
using Application.Contract.Mapper;
using Domian.Model.Book;
using FilterSharp.Input;
using Framework.Extensions;
using Framework.Response;

namespace Application;

public class BookService(IBookRepository bookRepository) : IBookService
{
    public async Task<ServiceResponse> GetById(int id)
    {
        var book = await bookRepository.GetBook(id);
        return book.ToDto<Book, BookDto>(BookMapper.ToDto);
    }

    public async Task<ServiceResponse> GetList(DataQueryRequest request)
    {
        var serviceResponse = await bookRepository.GetListBook(request);
        return serviceResponse.MapToDtos<Book, BookDto>(BookMapper.ToDto);
    }

    public async Task<ServiceResponse> Add(BookDto book)
    {
        return await bookRepository.AddBook(book.ToBook());
    }

    public async Task<ServiceResponse> Update(int id, BookDto bookDto)
    {
        var book = await GuardOnBookAndReturnBook(id);
        book.Update(bookDto.Title,bookDto.PublishYear);

        return await Updated(book);
    } 
    
    public async Task<ServiceResponse> Delete(int id)
    {
        var book = await GuardOnBookAndReturnBook(id);
        book.Delete();

        return await Updated(book);
    }
    
    private async Task<Book> GuardOnBookAndReturnBook(int id)
    {
        var serviceResponse = await bookRepository.GetBook(id);

        if (serviceResponse.Data is not Book book)
            throw new Exception("Book Not Found");
        
        return book;
    }

    private async Task<ServiceResponse> Updated(Book book)
    {
        return await bookRepository.UpdateBook(book);
    }
}