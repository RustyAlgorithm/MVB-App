using System;
using CurrencyCalculator;
using System.Threading;
using System.Threading.Tasks;
using System.Data;

internal class Program
{

    private static void Main(string[] args)
    {
        string customerName = "";

        Random rng = new Random();
        TypeOut t = new TypeOut();
        SmallTalk s = new SmallTalk();
      
        SaveToCSV CSV = new SaveToCSV();
        Actions a = new Actions();
        


        bool finished = false;
        
        

        // Clear console of defualt text and then verify ready to start then clear again
        Console.Clear();
        t.PauseLine("Are you Ready?");
        Console.Clear();

        // Opener
        Thread.Sleep(1000);
        t.TypeFast($"{s.Greeting(rng.Next(0, 7))} Adventurer!");
        Thread.Sleep(1500);
        t.TypeFast("Welcome to the Multiversal Bank Automated Transaction Portal!");
        Thread.Sleep(1500);
        t.TypeFast("Please ensure all your coins are seperated into Copper, Silver, Electrum, Gold and Platinum pieces.");
        Thread.Sleep(1500);
        t.TypeFast("Thank you.");
        Thread.Sleep(1500);

        // future functionality name for accounts
        t.TypeFast("May we please have a name for the account.");
        customerName = Console.ReadLine();
        if (customerName == "ClearAll")
        {
            t.TypeFast("This action will delete all data please confirm this is what you want to do.");
            string ConfirmDelete = Console.ReadLine();
            if (ConfirmDelete == "")
            {
                CSV.ClearCSV("user-data.csv");
                t.TypeFast("ALL DATA CLEARED");
                t.TypeFast("Press any key to exit the app...");
                Console.ReadKey();
                return;
            }
            else
            {
                t.TypeFast("Very well no data has been deleted.");
                t.TypeFast("The console will now close.");
                Console.ReadLine();
                return;
            }
            
        }
        t.TypeLine($"Thank you, {customerName}.");
        t.TypeLine("How can we help you today?");
        

        // main section.
        while (finished == false)
        {

            
            string Option;
            t.TypeFast("1) Deposit");
            t.TypeFast("2) Withdraw");
            t.TypeFast("3) Balance");
            t.TypeFast("4) Exit");
            t.TypeFast("Please enter the number of the option you require.");

            Option = Console.ReadLine();

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


            string continueActions = "no";

            switch (option)
            {
                case (1):
                    {
                        a.Deposit(customerName);
                        t.TypeFast("Have you 'found' anymore you want to include?");
                        t.TypeFast("please enter yes or no.");

                        continueActions = Console.ReadLine();
                        if (continueActions == "")
                        {
                            continueActions = "no";
                        }

                        continueActions.ToLower();
                    }
                    break;
                case (2):
                    {
                        a.Withdraw(customerName);
                        t.TypeFast("Have you 'found' anymore you want to include?");
                        t.TypeFast("please enter yes or no.");

                        continueActions = Console.ReadLine();
                        if (continueActions == "")
                        {
                            continueActions = "no";
                        }

                        continueActions.ToLower();
                    }
                    break;
                case (3):
                    {
                        t.TypeFast("Please wait while we count your gold.");
                        t.WaitLine(CSV.GetBalance(customerName));
                        t.TypeFast($"You currently have: {Convert.ToString(CSV.GetBalance(customerName))} gold.");
                        t.TypeFast("Have you 'found' anymore you want to include?");
                        t.TypeFast("please enter yes or no.");

                        continueActions = Console.ReadLine();
                        if (continueActions == "")
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
                
                
                t.TypeFast("Very well, Thank you for using Multiversal Bank Automated Transaction Portal.");
                t.TypeFast($"Have a nice day {customerName}.");
                Console.ReadLine();
                return;
            }
        }
    }
}