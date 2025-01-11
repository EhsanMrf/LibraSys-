using Framework.Exception;

namespace Framework.Validator;

public interface IMultiObjectValidator
{
    public IMultiObjectValidator NotNullOrEmptyList(BaseException exception);
}