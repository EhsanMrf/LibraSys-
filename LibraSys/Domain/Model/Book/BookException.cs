using Framework.Exception;

namespace Domian.Model.Book;

public class BookException
{
    public class BookTitleNullException() : BaseException("BookResource.BookTitleNull");
    public class BookTitleLengthException() : BaseException("BookResource.BookTitleLength");
    public class BookTitleInvalidObjectException() : BaseException("BookResource.BookTitleInvalidObject");
    public class BookPublishYearException() : BaseException("BookResource.BookPublishYear");
    public class BookAuthorIdInvalidException() : BaseException("BookResource.BookAuthorIdInvalid");
}