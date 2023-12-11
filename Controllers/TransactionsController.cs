using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Entities;
using WebApi.Models.Request;
using WebApi.Models.Response;

namespace WebApi.Controllers;
[Authorize]
[Route("api/transactions"),ApiController]
public class TransactionsController(AppDbContext context) : Controller
{
    [HttpPost("{accountId}/transfer-money")]
    public async Task<IActionResult> TransferMoney( long accountId,[FromBody] CreateTransactionRequest request,CancellationToken token)
    {
        var account = await context.UserAccounts.Include(x => x.Bank)
            .ThenInclude(x=> x.Currency).AsTracking()
            .FirstOrDefaultAsync(x => x.Id == accountId, token);
        if (account is null)
            return NotFound(new MessageResponse<UserAccount?>(null, "La cuenta de origen no existe"));
        var toAccount = await context.UserAccounts.Include(x => x.Bank)
            .ThenInclude(x => x.Currency).AsTracking()
            .FirstOrDefaultAsync(x => x.AccountNumber.Equals(request.AccountToTransfer), token);
        if (toAccount is null)
            return NotFound(new MessageResponse<UserAccount?>(null, "La cuenta de destino no existe"));
        if (request.Value < account.FoundInAccount)
        {
            return BadRequest(new MessageResponse<UserAccount?>(account, "La cuenta no cuenta con suficientes fondos"));
        }

        account.FoundInAccount -= request.Value;
        toAccount.FoundInAccount += request.Value;
        await context.AccountMovements.AddRangeAsync(new []
        {
            new AccountMovement()
            {
                BankId = toAccount.BankId,
                Concept = request.Concept,
                Credit = request.Value,
                Method = request.Method,
                FDateTime = DateTime.Now,
                UserAccountId = toAccount.Id,
            },
            new AccountMovement()
            {
                BankId = toAccount.BankId,
                Concept = request.Concept,
                Debit = request.Value,
                Method = request.Method,
                FDateTime = DateTime.Now,
                UserAccountId = account.Id,
            },
        }, token);
        await context.SaveChangesAsync(token);
        return Ok(new MessageResponse<AccountMovement>(null, "Transferencia realizada con exito !"));
    }
}