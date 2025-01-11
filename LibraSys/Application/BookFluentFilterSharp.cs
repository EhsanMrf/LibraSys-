using Domian.Model.Book;
using FilterSharp.FluentSharp;

namespace Application
{

    public class BookFluentFilterSharp : AbstractFilterSharpMapper<Book>
    {
        public override void Configuration(FilterSharpMapperBuilder<Book> builder)
        {
            builder.OnField(x => x.BookTitle.Title).FilterFieldName("Title");
        }
    }
}
