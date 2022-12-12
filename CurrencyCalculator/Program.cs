using System;
using CurrencyCalculator;
using System.Threading;
using System.Threading.Tasks;
using System.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        string customerName = "Smith";

        Random rng = new Random();
        TypeOut t = new TypeOut();
        SmallTalk s = new SmallTalk();
        Deposits d = new Deposits();
        SaveToCSV CSV = new SaveToCSV();
        Actions a = new Actions();

        
        bool finished = false;
        
        float CurrentBalance = 0;

        // Clear console of defualt text and then verify ready to start then clear again
        Console.Clear();
        t.PauseLine("Are you Ready?");
        Console.Clear();

        // Opener
        Thread.Sleep(1000);
        t.TypeLine($"{s.Greeting(rng.Next(0, 7))} Adventurer!");
        Thread.Sleep(1500);
        t.TypeLine("Welcome to the Multiverse Bank!");
        Thread.Sleep(1500);
        t.TypeFast("Please ensure all your coins are seperated into Copper, Silver, Electrum, Gold and Platinum pieces.");
        Thread.Sleep(1500);
        t.TypeLine("Thank you.");
        Thread.Sleep(1500);

        // future functionality name for accounts
        t.TypeFast("may I please have a name for the account.");
        customerName = Console.ReadLine();
        t.TypeLine($"Thank you, {customerName}.");
        t.TypeLine("How can we help you today?");
        CurrentBalance = CSV.GetBalance(customerName);

        // main section.
        while (finished == false)
        {

            int option = 0;
            string Option;
            t.TypeFast("1) Deposit");
            t.TypeFast("2) Withdraw");
            t.TypeFast("3) Balance");
            t.TypeFast("4) Exit");
            t.TypeFast("Please enter the number of the option you require.");

            Option = Console.ReadLine();

            if (Option != null)
            {
                option = Convert.ToInt16(Option);
            }
            else
            {
                option = 0;
            }

            string continueActions = "no";

            switch (option)
            {
                case (1):
                    {
                        a.Deposit(customerName);
                        t.TypeLine("Have you 'found' anymore you want to include?");
                        t.TypeFast("please enter yes or no.");

                        continueActions = Console.ReadLine();
                        if (continueActions == null)
                        {
                            continueActions = "no";
                        }

                        continueActions.ToLower();
                    }
                    break;
                case (2):
                    {
                        t.TypeLine("Have you 'found' anymore you want to include?");
                        t.TypeFast("please enter yes or no.");

                        continueActions = Console.ReadLine();
                        if (continueActions == null)
                        {
                            continueActions = "no";
                        }

                        continueActions.ToLower();
                    }
                    break;
                case (3):
                    {
                        t.TypeLine($"You currently have: {Convert.ToString(CurrentBalance)} gold.");
                        t.TypeLine("Have you 'found' anymore you want to include?");
                        t.TypeFast("please enter yes or no.");

                        continueActions = Console.ReadLine();
                        if (continueActions == null)
                        {
                            continueActions = "no";
                        }

                        continueActions.ToLower();
                    }
                    break;
                case (4):
                    {
                        continueActions = "no";
                    }
                    break;
                default:
                    {
                        t.TypeFast("please select one of the options avalible by typing the number.");
                        continueActions = "yes";

                    }
                    break;

            }


            if (continueActions == "no")
            {
                finished = true;
                CurrentBalance = CurrentBalance + d.CurrentDeposit();
                CSV.SaveToCsv(customerName, CurrentBalance);
                t.TypeLine("Very well, Thank you for using Multiversal Bank.");
                t.TypeLine($"Have a nice day {customerName}.");
            }
        }
    }
}