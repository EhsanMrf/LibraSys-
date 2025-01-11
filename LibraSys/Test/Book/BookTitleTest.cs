using Domian.Model.Book;
using FluentAssertions;

namespace Test.Book
{
    public class BookTitleTest
    {
        [Fact]
        public void should_throw_exception_if_title_null()
        {
            var courser = () =>
            {
                BookTitle.CreateInstance(string.Empty);
            };

            courser.Should().Throw<BookException.BookTitleNullException>();
        }
        
        [Fact]
        public void should_throw_exception_if_title_less_two()
        {
            var courser = () =>
            {
                BookTitle.CreateInstance("A");
            };

            courser.Should().Throw<BookException.BookTitleLengthException>();
        }

        [Fact]
        public void should_throw_exception_if_title_equalto_two()
        {
            var courser = () =>
            {
                BookTitle.CreateInstance("Ab");
            };

            courser.Should().Throw<BookException.BookTitleLengthException>();
        }

        [Fact]
        public void should_instance_with_out_exception()
        {
            var courser = () =>
            {
                BookTitle.CreateInstance("Book Title");
            };

            courser.Should().NotThrow();
        }
    }
}