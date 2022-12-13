using System;
namespace CurrencyCalculator
{
	public class Actions
	{
        public void Deposit(string customerName)
        {
            int option;
            
            Random rng = new Random();
            TypeOut t = new TypeOut();
            SmallTalk s = new SmallTalk();
            Deposits d = new Deposits();
            SaveToCSV CSV = new SaveToCSV();

            CSV.GetBalance(customerName);

            t.TypeFast("What kind of Deposit would you like?");
            t.TypeFast("1) Full Deposit");
            t.TypeFast("2) Platinum Deposit");
            t.TypeFast("3) Gold Deposit");
            t.TypeFast("4) Electrum Deposit");
            t.TypeFast("5) Silver Deposit");
            t.TypeFast("6) Copper Deposit");

            switch (option)
            {
            case (1):
                {
                    t.TypeFast(d.DepositTotal(d.CopperDeposit(), d.SilverDeposit(), d.ElectrumDeposit(), d.GoldDeposit(), d.PlatinumDeposit(), customerName));
                }
                break;
            case (2):
                {
                    t.TypeFast(d.DepositTotal(0, 0, 0, 0, d.PlatinumDeposit(), customerName));
                }
                break;
            case (3):
                {
                    t.TypeFast(d.DepositTotal(0, 0, 0, d.GoldDeposit(), 0, customerName));
                }
                break;
            case (4):
                {
                    t.TypeFast(d.DepositTotal(0, 0, d.ElectrumDeposit(), 0, 0, customerName));
                }
                break;
            case (5):
                {
                    t.TypeFast(d.DepositTotal(0, d.SilverDeposit(), 0, 0, 0, customerName));
                }
                break;
            case (6):
                {
                    t.TypeFast(d.DepositTotal(d.CopperDeposit(), 0, 0, 0, 0, customerName));
                }
                break;
            }
        }
        //hello
	
    }
}

