using FilterSharp.Dto;
using Framework.Response;

namespace Framework.FluentFilter;

public static class FluentFilterSharpConvert
{
    public static ServiceResponse ToServiceResponse(this QueryResult fluentFilter)
    {
        if (fluentFilter.PageSize==0)
            return new ServiceResponse(null, null, null);

        return new ServiceResponse(fluentFilter.Items, new
        {
            fluentFilter.TotalCount,
            fluentFilter.Page,
            fluentFilter.PageSize
        }, null);
    }
    
    public static ServiceResponse ToServiceResponse<T>(this T data)
    {
        return new ServiceResponse(data, null, null);
    }
    
    public static ServiceResponse ToServiceResponse<T>(this int saveChange)
    {
        var b = saveChange > 0;
        return new ServiceResponse(b, null, null);
    }
    
}