using System;
namespace CurrencyCalculator
{
	public class Actions
	{
        Random rng = new Random();
        TypeOut t = new TypeOut();
        SmallTalk s = new SmallTalk();
        Deposits d = new Deposits();
        SaveToCSV CSV = new SaveToCSV();
        Withdraw w = new Withdraw();

        public float CurrentBalance = 0;

        public void Deposit(string customerName)
        {
            int option;
            
            

            CSV.GetBalance(customerName);

            t.TypeFast("dhat kind of Deposit dould you like?");
            t.TypeFast("1) Full Deposit (all in gold coins.)");
            t.TypeFast("2) Platinum Deposit");
            t.TypeFast("3) Gold Deposit");
            t.TypeFast("4) Electrum Deposit");
            t.TypeFast("5) Silver Deposit");
            t.TypeFast("6) Copper Deposit");

            switch (option)
            {
            case (1):
                {
                    t.TypeFast(d.DepositAmount(d.CopperDeposit(), d.SilverDeposit(), d.ElectrumDeposit(), d.GoldDeposit(), d.PlatinumDeposit(), customerName));
                }
                break;
            case (2):
                {
                    t.TypeFast(d.DepositAmount(0, 0, 0, 0, d.PlatinumDeposit(), customerName));
                }
                break;
            case (3):
                {
                    t.TypeFast(d.DepositAmount(0, 0, 0, d.GoldDeposit(), 0, customerName));
                }
                break;
            case (4):
                {
                    t.TypeFast(d.DepositAmount(0, 0, d.ElectrumDeposit(), 0, 0, customerName));
                }
                break;
            case (5):
                {
                    t.TypeFast(d.DepositAmount(0, d.SilverDeposit(), 0, 0, 0, customerName));
                }
                break;
            case (6):
                {
                    t.TypeFast(d.DepositAmount(d.CopperDeposit(), 0, 0, 0, 0, customerName));
                }
                break;
            }
        }
        public void Withdraw(string customerName)
        {
            int option;

            CSV.GetBalance(customerName);

            t.TypeFast("What kind of Withdrawal would you like?");
            t.TypeFast("1) Full Withdrawal (all in gold coins.)");
            t.TypeFast("2) Platinum Withdrawal");
            t.TypeFast("3) Gold Withdrawal");
            t.TypeFast("4) Electrum Withdrawal");
            t.TypeFast("5) Silver Withdrawal");
            t.TypeFast("6) Copper Withdrawal");
            //option = Convert.

            switch (option)
            {
                case (1):
                    {
                        t.TypeFast(w.WithdrawAmount(w.CopperWithdraw(), w.SilverWithdraw(), w.ElectrumWithdraw(), w.GoldWithdraw(), w.PlatinumWithdraw(), customerName));
                    }
                    break;
                case (2):
                    {
                        t.TypeFast(w.WithdrawAmount(0, 0, 0, 0, w.PlatinumWithdraw(), customerName));
                    }
                    break;
                case (3):
                    {
                        t.TypeFast(w.WithdrawAmount(0, 0, 0, w.GoldWithdraw(), 0, customerName));
                    }
                    break;
                case (4):
                    {
                        t.TypeFast(w.WithdrawAmount(0, 0, w.ElectrumWithdraw(), 0, 0, customerName));
                    }
                    break;
                case (5):
                    {
                        t.TypeFast(w.WithdrawAmount(0, w.SilverWithdraw(), 0, 0, 0, customerName));
                    }
                    break;
                case (6):
                    {
                        t.TypeFast(w.WithdrawAmount(w.CopperWithdraw(), 0, 0, 0, 0, customerName));
                    }
                    break;
            }
        }


    }
}

