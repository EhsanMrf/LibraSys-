namespace Domian.Model.Book;

public class BookBuilder
{
    private BookTitle BookTitle { get;  set; } =null!;
    private BookPublishYear PublishYear { get; set; } = null!;

    public BookBuilder WithBookTitle(string title)
    {
        this.BookTitle = BookTitle.CreateInstance(title);
        return this;
    }

    public BookBuilder WithPublishYear(int publishYear)
    {
        this.PublishYear = BookPublishYear.CreateInstance(publishYear);
        return this;
    }
    

    public static BookBuilder Instance()
    {
        return new BookBuilder();
    }
    public Book Build()
    {
        return new Book(BookTitle.Title, PublishYear.PublishYear);
    }
}