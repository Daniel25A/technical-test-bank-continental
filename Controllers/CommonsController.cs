using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Entities;
using WebApi.Models.Request;
using WebApi.Models.Response;

namespace WebApi.Controllers;
[Route("api/commons"),ApiController]
public class CommonsController(AppDbContext context): Controller
{
    [HttpPost("register-bank")]
    public async Task<IActionResult> RegisterBank(RegisterBankRequest request, CancellationToken token)
    {
        var bank = request.Adapt<Bank>();
        await context.Banks.AddAsync(bank, token);
        await context.SaveChangesAsync(token);
        return Ok(new MessageResponse<Bank>(bank, "Entidad Bancaria Registrada con exito"));
    }
    [HttpPost("register-currency")]
    public async Task<IActionResult> RegisterCurrency(RegisterCurrencyRequest request, CancellationToken token)
    {
        var currency = request.Adapt<Currency>();
        await context.Currencies.AddAsync(currency, token);
        await context.SaveChangesAsync(token);
        return Ok(new MessageResponse<Currency>(currency, "Moneda registrada con exito"));
    }
    [HttpGet("get-banks")]
    public async Task<IActionResult> GetBanks(int skip, int take, CancellationToken token)
    {
        var count = await context.Banks.CountAsync(token);
        var items = await context.Banks.Select(x => new ItemResponse<long>()
        {
            Identifier = x.Id,
            Name = x.BankName
        }).Skip(skip).Take(take).ToListAsync(token);
        return Ok(new PaginateResponse<ItemResponse<long>>(items, count));
    }
    [HttpGet("get-currencies")]
    public async Task<IActionResult> GetCurrencies(int skip, int take, CancellationToken token)
    {
        var count = await context.Currencies.CountAsync(token);
        var items = await context.Currencies.Select(x => new ItemResponse<long>()
        {
            Identifier = x.Id,
            Name = x.Name
        }).Skip(skip).Take(take).ToListAsync(token);
        return Ok(new PaginateResponse<ItemResponse<long>>(items, count));
    }
}