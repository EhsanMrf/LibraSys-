using Domian.Model.Book;
using FluentAssertions;

namespace Test.Book;

public class BookTest
{
    [Fact]
    public void should_throw_exception_if_bookTitle_null()
    {
        var courser = () =>
        {
            BookBuilder.Instance()
                .WithBookTitle(string.Empty)
                .Build();
        };
        courser.Should().Throw<BookException.BookTitleInvalidObjectException>();
    }

    [Fact]
    public void should_throw_exception_if_publishYear_equalto_zero()
    {
        var courser = () =>
        {
            BookBuilder.Instance()
                .WithBookTitle(nameof(BookTitle))
                .WithPublishYear(0)
                .Build();
        };
        courser.Should().Throw<BookException.BookPublishYearException>();
    } 

    [Fact]
    public void should_throw_exception_if_AuthorId_equalto_empty()
    {
        var courser = () =>
        {
            BookBuilder.Instance()
                .WithBookTitle(nameof(BookTitle))
                .WithPublishYear(2014)
                .Build();
        };
        courser.Should().Throw<BookException.BookAuthorIdInvalidException>();
    } 

    [Fact]
    public void should_instance_with_out_exception()
    {
        var courser = () =>
        {
            BookBuilder.Instance()
                .WithBookTitle(nameof(BookTitle))
                .WithPublishYear(2014)
                .Build();
        };
        courser.Should().NotThrow();
    }
}