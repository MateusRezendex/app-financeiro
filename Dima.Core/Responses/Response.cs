using System.Text.Json.Serialization;

namespace Dima.Core.Responses;

public class Response <TData>
{
    private readonly int _code;

    [JsonConstructor]
    public Response()
        => _code = Configuration.DefaulStatusCode;

    public Response(
        TData? data, 
        int code = Configuration.DefaulStatusCode, 
        string? message = null)
    {
        Data = data;
        Message = message;
        _code = Configuration.DefaulStatusCode;
    }
    
    public TData? Data { get; set; }
    public string? Message { get; set; }
    
    [JsonIgnore]
    public bool IsSuccess => _code is >= 200 and <= 299;
}