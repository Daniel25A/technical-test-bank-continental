namespace WebApi.Models.Response;

public class PaginateResponse<T>
{
    public PaginateResponse(IEnumerable<T> items, int count)
    {
        Items = items;
        Count = count;
    }

    public IEnumerable<T> Items { get; set; } = null!;
    public int Count { get; set; }
}