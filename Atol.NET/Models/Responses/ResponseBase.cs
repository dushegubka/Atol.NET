namespace Atol.NET.Models.Responses;


public class ResponseBase
{
    public bool IsSuccess { get; set; }
    
    public int ErrorCode { get; set; }
    
    public string? Description { get; set; }
}