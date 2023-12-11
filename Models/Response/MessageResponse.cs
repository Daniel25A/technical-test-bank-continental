namespace WebApi.Models.Response;

public class MessageResponse<T>
{
    public MessageResponse(T objectReference, string message)
    {
        ObjectReference = objectReference;
        Message = message;
    }

    public string Message { get; set; } = string.Empty;
    public T? ObjectReference { get; set; }
}