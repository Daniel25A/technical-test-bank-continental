using WebApi.Commons;
using WebApi.Commons.Enums;

namespace WebApi.Entities;

public class AccountMovement : BaseEntity
{
    public decimal Credit { get; set; }
    public decimal Debit { get; set; }
    public Bank Bank { get; set; }
    public long BankId { get; set; }
    public DateTime FDateTime { get; set; }
    public string Concept { get; set; } = string.Empty;
    public UserAccount UserAccount { get; set; }
    public long UserAccountId { get; set; }
    public TransactionMethodEnum Method { get; set; }
}