using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using WebApi.Commons.Enums;

namespace WebApi.Entities;

public class UserAccount : IdentityUser<long>
{
    public string FullName { get; set; } = string.Empty;
    public decimal FoundInAccount { get; set; }
    [MaxLength(40)]
    public string AccountNumber { get; set; } = string.Empty;
    public Bank Bank { get; set; } = null!;
    public long BankId { get; set; }
    public string DocumentNumber { get; set; } = string.Empty;
    public DocumentTypeEnum DocumentType { get; set; }
}