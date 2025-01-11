namespace Framework.Response;

public sealed class ServiceResponse
{
    public object? Data { get; private set; }
    private object Metadata { get; set; }
    private ResponseStatus ResponseStatus { get; set; }
    

    private ServiceResponse()
    {
        
    }

    internal void SetData(object data)
    {
        Data = data;
    }
    
    public static ServiceResponse InstanseResponse(object? data, IEnumerable<object> metadata, ResponseStatus responseStatus)
    {
        return new ServiceResponse(data, metadata, responseStatus);
    }
    public ServiceResponse(object? data, IEnumerable<object> metadata, ResponseStatus responseStatus)
    {
        SetToConstructor(data, metadata,responseStatus);
    }


     void SetToConstructor(object? data, IEnumerable<object> metadata, ResponseStatus responseStatus)
    {
        Data = data;
        Metadata = metadata;
        ResponseStatus = responseStatus;
    }


}

public sealed class ResponseStatus
{
    private string? Message { get; set; }

    private ResponseStatus()
    {
        
    }
    private ResponseStatus(string? message)
    {
        Message = message;
    }
}


public sealed class DetailList
{
    private DetailList()
    {
        
    }
    public DetailList(int totalCount, int pageNumber, int pageSize)
    {
        TotalCount = totalCount;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    private int TotalCount { get; set; }
    private int PageNumber { get; set; }
    private int PageSize { get; set; }
    
}