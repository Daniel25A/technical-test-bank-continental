using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts): base(opts)
    {
        
    }

    public DbSet<AccountMovement> AccountMovements { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<UserAccount> UserAccounts { get; set; }
}