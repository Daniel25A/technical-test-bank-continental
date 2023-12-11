namespace WebApi.Models.Request;

public class LoginRequest
{
    public string DocumentNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}