using System;
using Microsoft.VisualBasic.FileIO;

namespace CurrencyCalculator
{
	public class Actions
	{
        
        TypeOut t = new TypeOut();
        SmallTalk s = new SmallTalk();
        Coin c = new Coin();
        SaveToCSV CSV = new SaveToCSV(); 

        float hold;
        int thank;

        public float CopperDeposit()
        {
            t.TypeFast("Please Enter the number of Copper Pieces (CP) you have...");

            int cP = Convert.ToInt32(Console.ReadLine());
            hold = Convert.ToSingle(cP * 0.01);
            thank = Convert.ToInt32(hold);
            float CD = hold;

            Thread.Sleep(1500);
            t.TypeLine(s.Thank(thank));
            Thread.Sleep(2000);
            return CD;
        }
        public float SilverDeposit()
        {
            t.TypeFast("Please Enter the number of Silver Pieces (SP) you have...");

            int sP = Convert.ToInt32(Console.ReadLine());
            hold = Convert.ToSingle(sP * 0.1);
            thank = Convert.ToInt32(hold);
            float SD = hold;

            Thread.Sleep(1500);
            t.TypeLine(s.Thank(thank));
            Thread.Sleep(2000);
            return SD;
        }
        public float ElectrumDeposit()
        {
            t.TypeFast("Please Enter the number of Electrum Pieces (EP) you have...");

            int eP = Convert.ToInt32(Console.ReadLine());
            hold = Convert.ToSingle(eP * 0.5);
            thank = Convert.ToInt32(hold);
            float ED = hold;

            Thread.Sleep(1500);
            t.TypeLine(s.Thank(thank));
            Thread.Sleep(2000);
            return ED;
        }
        public float GoldDeposit()
        {
            t.TypeFast("Please Enter the number of Gold Pieces (GP) you have...");

            int gP = Convert.ToInt32(Console.ReadLine());
            thank = gP;
            float GD = Convert.ToSingle(thank);

            Thread.Sleep(1500);
            t.TypeLine(s.Thank(thank));
            Thread.Sleep(2000);
            return GD;
        }
        public float PlatinumDeposit()
        {
            t.TypeFast("Please Enter the number of Platinum Pieces (PP) you have...");

            int pP = Convert.ToInt32(Console.ReadLine());
            hold = Convert.ToSingle(pP * 5);
            thank = Convert.ToInt32(hold);
            float PD = hold;

            Thread.Sleep(1500);
            t.TypeLine(s.Thank(thank));
            Thread.Sleep(1500);
            return PD;
        }

        public string DepositAmount(float cP, float sP, float eP, float gP, float pP, string name)
        {
            float CurrentBalance = CSV.GetBalance(name);
            float newtotal = Convert.ToSingle(c.CountCoins(cP, sP, eP, gP, pP)) + CurrentBalance;
            t.TypeLine("Please wait while we count your coins.");
            t.WaitLine(newtotal);
            Thread.Sleep(100);

            CSV.SaveToCsv(name, newtotal);
            return $"Your total is: {Convert.ToString(newtotal)} gold";
        }
        /*public float CurrentDeposit()
        {
            return c.Total;
        }*/
        public float CopperWithdraw()
        {
            t.TypeFast("Please Enter the number of Copper Pieces (CP) you want to withdra..");

            int cP = Convert.ToInt32(Console.ReadLine());
            hold = Convert.ToSingle(cP * 0.01);
            thank = Convert.ToInt32(hold);
            float CD = hold;

            Thread.Sleep(1500);
            t.TypeLine(s.Thank(thank));
            Thread.Sleep(2000);
            return CD;
        }
        public float SilverWithdraw()
        {
            t.TypeFast("Please Enter the number of Silver Pieces (SP) you want to withdra..");

            int sP = Convert.ToInt32(Console.ReadLine());
            hold = Convert.ToSingle(sP * 0.1);
            thank = Convert.ToInt32(hold);
            float SD = hold;

            Thread.Sleep(1500);
            t.TypeLine(s.Thank(thank));
            Thread.Sleep(2000);
            return SD;
        }
        public float ElectrumWithdraw()
        {
            t.TypeFast("Please Enter the number of Electrum Pieces (EP) you want to withdra..");

            int eP = Convert.ToInt32(Console.ReadLine());
            hold = Convert.ToSingle(eP * 0.5);
            thank = Convert.ToInt32(hold);
            float ED = hold;

            Thread.Sleep(1500);
            t.TypeLine(s.Thank(thank));
            Thread.Sleep(2000);
            return ED;
        }
        public float GoldWithdraw()
        {
            t.TypeFast("Please Enter the number of Gold Pieces (GP) you want to withdra..");

            int gP = Convert.ToInt32(Console.ReadLine());
            thank = gP;
            float GD = Convert.ToSingle(thank);

            Thread.Sleep(1500);
            t.TypeLine(s.Thank(thank));
            Thread.Sleep(2000);
            return GD;
        }
        public float PlatinumWithdraw()
        {
            t.TypeFast("Please Enter the number of Platinum Pieces (PP) you want to withdra..");

            int pP = Convert.ToInt32(Console.ReadLine());
            hold = Convert.ToSingle(pP * 5);
            thank = Convert.ToInt32(hold);
            float PD = hold;

            Thread.Sleep(1500);
            t.TypeLine(s.Thank(thank));
            Thread.Sleep(1500);
            return PD;
        }
        public string WithdrawAmount(float cP, float sP, float eP, float gP, float pP, string name)
        {
            float CurrentBalance = CSV.GetBalance(name);
            float newtotal = CurrentBalance - Convert.ToSingle(c.CountCoins(cP, sP, eP, gP, pP));
            t.TypeLine("Please wait while we count your coins.");
            t.WaitLine(newtotal);
            Thread.Sleep(100);

            CSV.SaveToCsv(name, newtotal);
            return $"Your total is: {Convert.ToString(newtotal)} gold";
        }
        public float BalanceTotal(string name)
        {
            return CSV.GetBalance(name);
        }

        public void Deposit(string AccountNameD)
        {


            CSV.GetBalance(AccountNameD);

            t.TypeFast("How would you like to make a deposit today??");
            t.TypeFast("1) Full Deposit");
            t.TypeFast("2) Platinum Deposit");
            t.TypeFast("3) Gold Deposit");
            t.TypeFast("4) Electrum Deposit");
            t.TypeFast("5) Silver Deposit");
            t.TypeFast("6) Copper Deposit");
            t.TypeFast("Please enter the number of the option you require.");

            string Option = Console.ReadLine();

            int option = 0;

            if (Option == "")
            {
                option = 0;
            }
            else
            {
                int parsedOption;
                if (Int32.TryParse(Option, out parsedOption))
                {
                    option = parsedOption;
                }
            }

            switch (option)
            {
                case (1):
                    {
                        t.TypeFast(DepositAmount(CopperDeposit(), SilverDeposit(), ElectrumDeposit(), GoldDeposit(), PlatinumDeposit(), AccountNameD));
                    }
                    break;
                case (2):
                    {
                        t.TypeFast(DepositAmount(0, 0, 0, 0, PlatinumDeposit(), AccountNameD));
                    }
                    break;
                case (3):
                    {
                        t.TypeFast(DepositAmount(0, 0, 0, GoldDeposit(), 0, AccountNameD));
                    }
                    break;
                case (4):
                    {
                        t.TypeFast(DepositAmount(0, 0, ElectrumDeposit(), 0, 0, AccountNameD));
                    }
                    break;
                case (5):
                    {
                        t.TypeFast(DepositAmount(0, SilverDeposit(), 0, 0, 0, AccountNameD));
                    }
                    break;
                case (6):
                    {
                        t.TypeFast(DepositAmount(CopperDeposit(), 0, 0, 0, 0, AccountNameD));
                    }
                    break;
                default:
                    {
                        t.TypeFast("please select one of the options avalible by typing the number.");
                    }
                    break;

            }
        }
        public void Withdraw(string AccountNameW)
        {

            CSV.GetBalance(AccountNameW);

            t.TypeFast("What kind of withdrawal would you like to make today?");
            t.TypeFast("1) Full Withdrawal (all in gold coins.)");
            t.TypeFast("2) Platinum Withdrawal");
            t.TypeFast("3) Gold Withdrawal");
            t.TypeFast("4) Electrum Withdrawal");
            t.TypeFast("5) Silver Withdrawal");
            t.TypeFast("6) Copper Withdrawal");
            t.TypeFast("Please enter the number of the option you require.");

            string Option = Console.ReadLine();

            int option = 0;

            if (Option == "")
            {
                option = 0;
            }
            else
            {
                int parsedOption;
                if (Int32.TryParse(Option, out parsedOption))
                {
                    option = parsedOption;
                }
            }

            switch (option)
            {
                case (1):
                    {
                        t.TypeFast(WithdrawAmount(CopperWithdraw(), SilverWithdraw(), ElectrumWithdraw(), GoldWithdraw(), PlatinumWithdraw(), AccountNameW));
                    }
                    break;
                case (2):
                    {
                        t.TypeFast(WithdrawAmount(0, 0, 0, 0, PlatinumWithdraw(), AccountNameW));
                    }
                    break;
                case (3):
                    {
                        t.TypeFast(WithdrawAmount(0, 0, 0, GoldWithdraw(), 0, AccountNameW));
                    }
                    break;
                case (4):
                    {
                        t.TypeFast(WithdrawAmount(0, 0, ElectrumWithdraw(), 0, 0, AccountNameW));
                    }
                    break;
                case (5):
                    {
                        t.TypeFast(WithdrawAmount(0, SilverWithdraw(), 0, 0, 0, AccountNameW));
                    }
                    break;
                case (6):
                    {
                        t.TypeFast(WithdrawAmount(CopperWithdraw(), 0, 0, 0, 0, AccountNameW));
                    }
                    break;
                default:
                    {
                        t.TypeFast("please select one of the options avalible by typing the number.");

                    }
                    break;
            }
        }
    }
        


}


