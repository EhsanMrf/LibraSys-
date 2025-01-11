using Framework.Entity;
using Framework.Validator;

namespace Domian.Model.Book;

public sealed class Book :BaseEntity<int>
{
    public BookTitle BookTitle { get; private set; } = null!;
    public BookPublishYear PublishYear { get; private set; }= null!;

    private Book()
    {
        
    }
    public Book(string title, int publishYear)
    {
        SetData(title, publishYear);
    }
    
    

    private void SetData(string title, int publishYear)
    {
        SetBookTitle(BookTitle.CreateInstance(title));
        SetPublishYear(BookPublishYear.CreateInstance(publishYear));
    }

    private void SetPublishYear(BookPublishYear bookPublishYear)
    {
        ObjectValidator.Instance
            .RuleFor(bookPublishYear)
            .NotNullOrEmpty(new BookException.BookTitleInvalidObjectException());
        
        PublishYear = bookPublishYear;
    }

    public void Update(string title, int publishYear)
    {
        SetData(title, publishYear);
        UpdateDateTime= DateTime.Now;
    }

    public void Delete()
    {
        IsDeleted=true;
    }

    private void SetBookTitle(BookTitle bookTitle)
    {
        ObjectValidator.Instance
            .RuleFor(bookTitle)
            .NotNullOrEmpty(new BookException.BookTitleInvalidObjectException());
        
        BookTitle = bookTitle;
    }
}