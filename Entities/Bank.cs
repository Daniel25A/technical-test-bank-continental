using System.ComponentModel.DataAnnotations;
using WebApi.Commons;

namespace WebApi.Entities;

public class Bank : BaseEntity
{
    [MaxLength(50)]
    public string BankName { get; set; } = string.Empty;

    public Currency Currency { get; set; }
    public long CurrencyId { get; set; }
}