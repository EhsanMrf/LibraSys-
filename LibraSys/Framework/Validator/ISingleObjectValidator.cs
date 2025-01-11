using Framework.Exception;

namespace Framework.Validator;

public interface ISingleObjectValidator
{
    public IObjectValidator NotNullOrEmpty(BaseException exception);
}