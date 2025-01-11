using Domian.Model.Book;
using FluentAssertions;

namespace Test.Book;

public class BookPublishYearTest
{
    [Fact]
    public void should_throw_exception_if_publishYear_is_zero()
    {
        var act = () => BookPublishYear.CreateInstance(0);

        act.Should().Throw<BookException.BookPublishYearException>();
    }
    
    [Fact]
    public void should_create_instance_if_publishYear_is_valid()
    {
        var instance = BookPublishYear.CreateInstance(2023);

        instance.PublishYear.Should().Be(2023);
    }
    
    [Fact]
    public void should_set_publishYear_correctly_when_valid()
    {
        var instance = BookPublishYear.CreateInstance(1995);

        instance.PublishYear.Should().Be(1995);
    }
}