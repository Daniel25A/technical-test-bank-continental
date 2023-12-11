namespace WebApi.Models.Request;

public class RegisterCurrencyRequest
{
    public string Name { get; set; } = string.Empty;
    public string Symbol { get; set; } = string.Empty;
}