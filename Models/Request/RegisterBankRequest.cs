namespace WebApi.Models.Request;

public class RegisterBankRequest
{
    public string BankName { get; set; } = string.Empty;
    public long CurrencyId { get; set; }
}