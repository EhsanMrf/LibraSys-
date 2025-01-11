using Framework.Response;

namespace Framework.Extensions;

public static class ServiceResponseExtension
{
    public static ServiceResponse ToDto<T, TR>(this ServiceResponse serviceResponse, Func<T, TR> mapper)
        where T : class
        where TR : class
    {
        if (serviceResponse.Data is T data)
        {
            var mappedData = mapper(data);
            serviceResponse.RefreshData(mappedData);
        }
        return serviceResponse;
    } 
    
    public static ServiceResponse MapToDtos<T, TR>(this ServiceResponse serviceResponse, Func<T, TR> mapper)
        where T : class
        where TR : class
    {
        if (serviceResponse.Data is IEnumerable<T> dataList)
        {
            var mappedDataList = dataList.Select(mapper).ToList();
            serviceResponse.RefreshData(mappedDataList);
        }


        return serviceResponse;
    }
}