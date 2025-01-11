using System.ComponentModel.DataAnnotations;
using Framework.Tag;
using Framework.Validator;

namespace Domian.Model.Book;

public sealed class BookTitle:IValueObject
{
    [MaxLength(70)]
    public string Title { get; private set; } = null!;

    public static BookTitle CreateInstance(string title)=> new (title);

    /// <summary>
    /// for ef core 
    /// </summary>
    private BookTitle() { }

    private BookTitle(string title)
    {
        SetTitle(title);
    }
    
    void SetTitle(string title)
    {
        GuardAssessment(title);
        Title = title;
    }

    void GuardAssessment(string title)
    {
        ObjectValidator.Instance
            .RuleFor(title)
            .NotNullOrEmpty(new BookException.BookTitleNullException())
            .Must(title,x=>x.Length is 2 or<2,
                new BookException.BookTitleLengthException());
    }
}