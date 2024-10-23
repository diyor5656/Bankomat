using System;
using Bankomat.Models;
using Bankomat.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class WalletService
{
    private readonly BankomatDbContext _context;

    public WalletService(BankomatDbContext context)
    {
        _context = context;
    }

    
    public async Task DepositCash(int cash)
    {
        var cashWallet = new CashWallet
        {
            Cash = cash,
            DateTime = DateTime.Now
        };

        _context.CashWallets.Add(cashWallet);
        await _context.SaveChangesAsync();

        
        await TransferToOnlineWallet(cash);
    }

    
    private async Task TransferToOnlineWallet(int cash)
    {
        var increasedCash = cash + (cash / 100);

        var onlineWallet = new OnlineWallet
        {
            Cash = increasedCash,
            DateTime = DateTime.Now
        };

        _context.OnlineWallets.Add(onlineWallet);
        await _context.SaveChangesAsync();
    }
}
