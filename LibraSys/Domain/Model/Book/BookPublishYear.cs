using Framework.Tag;
using Framework.Validator;

namespace Domian.Model.Book;

public sealed class BookPublishYear:IValueObject
{
    public int PublishYear { get; private set; }

    private BookPublishYear() {}
    public static BookPublishYear CreateInstance(int publishYear)=> new (publishYear);

    private BookPublishYear(int publishYear)
    {
        SetPublishYear(publishYear);
    }

    void SetPublishYear(int publishYear)
    {
        ObjectValidator.Instance
            .Must(publishYear, x => x == 0,
                new BookException.BookPublishYearException());
        PublishYear = publishYear;

    }
}