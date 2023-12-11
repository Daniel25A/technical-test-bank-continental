using System.Security.Claims;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Models.Request;
using WebApi.Models.Response;
using WebApi.Services;

namespace WebApi.Controllers;
[Route("api/accounts"),ApiController]
public class AccountsController(UserManager<UserAccount> userManager, TokenService tokenService) : Controller
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterAccountRequest request, CancellationToken token)
    {
        var account = request.Adapt<UserAccount>();
        var result = await userManager.CreateAsync(account, request.Password);
        if (result.Succeeded)
            return Ok(new MessageResponse<IdentityResult?>(null, "Cuenta aperturada con exito!"));
        return BadRequest(
            new MessageResponse<IdentityResult>(result, "Ocurrio un error, consulte el objeto de resultado"));
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken token)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(x => x.DocumentNumber.Equals(request.DocumentNumber),
            token);
        if (user is null)
            return NotFound(new LoginResponse()
            {
                Token = "INVALID",
                Message = $"No existe ningún usuario con el Nº de Doc. {request.DocumentNumber}"
            });
        var result = await userManager.CheckPasswordAsync(user, request.Password);
        if (result)
        {
            var jwtToken = await tokenService.GenerateJwtToken(new[]
            {
                new Claim( ClaimTypes.Sid,user.Id.ToString())
            }, DateTime.UtcNow.AddHours(2));
            return Ok(new LoginResponse
            {
                Token = jwtToken,
                Message = $"Bienvenido {user.FullName}"
            });
        }

        return Unauthorized(new LoginResponse
        {
            Message = "La Contraseña es incorrecta !",
            Token = "INVALID"
        });
    }
    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> Me(CancellationToken token)
    {
        var claimAccountId = User.FindFirst(ClaimTypes.Sid);
        if (claimAccountId is null)
            return BadRequest(new MessageResponse<Claim? > (null, "Error en Claims !"));
        var account = await userManager.FindByIdAsync(claimAccountId.Value);
        if(account is null)
            return NotFound(new MessageResponse<UserAccount? > (null, "El Usuario no existe, se borro o se modifico de forma externa !"));
        var meResponse = new
        {
            account.FullName,
            account.Email,
            account.DocumentNumber,
            account.FoundInAccount,
            account.Bank.BankName,
            account.UserName
        };
        return Ok(meResponse);
    }
}