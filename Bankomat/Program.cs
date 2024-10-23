using System;

class Program
{   
    static async Task Main(string[] args)
    {
        try
        {
            Console.WriteLine("Summani kiriting:");
            string input = Console.ReadLine();

        
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Xatolik: Summani kiritish majburiy!");
            }

            
            int summa = int.Parse(input);

            
            if (summa <= 0)
            {
                throw new ArgumentException("Xatolik: Manfiy son yoki nol kiritildi!");
            }

            
            if (summa % 5 != 0)
            {
                throw new ArgumentException("Xatolik: Summa 5 ga bo'linmaydi!");
            }

            int[] birliklar = { 100, 50, 20, 10, 5 };
            int[] natija = new int[birliklar.Length];

           
            for (int i = 0; i < birliklar.Length; i++)
            {
                natija[i] = summa / birliklar[i];
                summa %= birliklar[i];
            }

            // Natijani chiqarish
            Console.WriteLine("Pulingizni quyidagicha bo'lish mumkin:");
            for (int i = 0; i < birliklar.Length; i++)
            {
                if (natija[i] > 0)
                {
                    Console.WriteLine($"{birliklar[i]}: {natija[i]} ta");
                }
            }

            // Kiritilgan summani CashWallet-ga tushirish
            await DepositCash(summa);

            // Summaning 1% qo'shib OnlineWallet-ga tushirish
            await TransferToOnlineWallet(summa);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Xatolik: Son kiritishingiz kerak!");
        }
    }

    // Naqd pulni CashWallet-ga tushirish
    public static async Task DepositCash(int cash)
    {
        var cashWallet = new Bankomat.Models.CashWallet
        {
            Cash = cash,
            DateTime = DateTime.Now
        };

        // CashWallet ma'lumotini saqlash (odatda bu ma'lumotlar bazaga saqlanadi)
        Console.WriteLine($"CashWallet-ga {cash} miqdoridagi summa saqlandi.");
        await Task.CompletedTask;
    }

    // Summani 1% qo'shib OnlineWallet-ga tushirish
    public static async Task TransferToOnlineWallet(int cash)
    {
        int increasedCash = cash + (cash / 100); // 1% qo'shildi

        var onlineWallet = new Bankomat.Models.OnlineWallet
        {
            Cash = increasedCash,
            DateTime = DateTime.Now
        };

        // OnlineWallet ma'lumotini saqlash (odatda bu ma'lumotlar bazaga saqlanadi)
        Console.WriteLine($"OnlineWallet-ga {increasedCash} miqdoridagi summa saqlandi (1% qo'shib).");
        await Task.CompletedTask;
    }
}
