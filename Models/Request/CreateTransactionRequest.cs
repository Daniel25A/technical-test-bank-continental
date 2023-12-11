using WebApi.Commons.Enums;

namespace WebApi.Models.Request;

public class CreateTransactionRequest
{
  public string AccountToTransfer { get; set; } = string.Empty;
  public long BankId { get; set; }
  public decimal Value { get; set; }
  public string Concept { get; set; } = string.Empty;
  public TransactionMethodEnum Method { get; set; }
}