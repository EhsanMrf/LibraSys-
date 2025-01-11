using Application.Contract.Dto;
using Domian.Model.Book;

namespace Application.Contract.Mapper;

public static class BookMapper
{
    public static BookDto ToDto(Book book)
    {
        return new BookDto(book.Id, book.BookTitle.Title, book.PublishYear.PublishYear);
    }
    

    public static Book ToBook(this BookDto bookDto)
    {
        return new Book(bookDto.Title,bookDto.PublishYear);
    }
}