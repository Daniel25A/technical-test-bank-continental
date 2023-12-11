using WebApi.Commons.Enums;

namespace WebApi.Models.Request;

public class RegisterAccountRequest
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DocumentTypeEnum DocumentType { get; set; }
    public long BankId { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
}