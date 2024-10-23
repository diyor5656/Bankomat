using Microsoft.EntityFrameworkCore;
using Bankomat.Models;

namespace Bankomat.Data
{
    public class BankomatDbContext : DbContext
    {
        public BankomatDbContext(DbContextOptions<BankomatDbContext> options) : base(options) { }

        public DbSet<CashWallet> CashWallets { get; set; }
        public DbSet<OnlineWallet> OnlineWallets { get; set; }
    }
}
