namespace WebApi.Models.Response;

public class ItemResponse<T>
{
    public string Name { get; set; } = string.Empty;
    public T Identifier { get; set; }
}