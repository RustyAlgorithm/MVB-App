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
      
        SaveToCSV CSV = new SaveToCSV();
        Actions a = new Actions();
        


        bool finished = false;
        
        

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

        // ask if new user or returning
        t.TypeLine("Are you a new customer?");
        t.TypeFast("Please enter Yes or No.");
        string newCustomer = Console.ReadLine();
        if (newCustomer == "")
        {
            newCustomer = "no";
        }
        bool NewCustomer;

        if (newCustomer == "yes")
        {
            NewCustomer = true;
        }
        else
        {
            NewCustomer = false;
        }

        newCustomer.ToLower();
        if (NewCustomer == true)
        {
            t.TypeLine("Welcome to the Multiverse Bank!");
            t.TypeLine("We are happy to have you with us.");
            t.TypeLine("Please follow the instructions on screen to create your account.");
            t.TypeLine("Thank you.");
            t.TypeLine("Please enter your name.");
            customerName = Console.ReadLine();
            if (customerName == "")
            {
                customerName = "Smith";
            }
            
            
            // generate random 4 digit number for PIN
            int PIN = rng.Next(1000, 9999);
            int AccountNumber = rng.Next(1000000, 9999999);
            t.TypeLine($"Thank you, {customerName}.");
            t.TypeLine($"Your account number is {AccountNumber}.");
            t.TypeLine($"Your PIN is {PIN}.");
            CSV.SaveToCsv(customerName, AccountNumber, PIN);
            t.TypeLine("How can we help you today?");
        }
        else
        {
            t.TypeLine("Welcome back to the Multiverse Bank!");
            t.TypeLine("We are happy to have you with us.");
            t.TypeLine("Please follow the instructions on screen to access your account.");
            t.TypeLine("Thank you.");
            t.TypeLine("Please enter your AccountNumber.");
            int ANVerify = Convert.ToInt16(Console.ReadLine());
            if (CSV.CheckAccountNumber(ANVerify) == false)
            {
                while (CSV.CheckAccountNumber(ANVerify) == false)
                {
                    t.TypeLine("Account Number not found.");
                    t.TypeLine("Please try again.");
                    ANVerify = Convert.ToInt16(Console.ReadLine());
                    
                }
            }
            t.TypeLine($"Thank you, {customerName}.");
            t.TypeLine("How can we help you today?");
            //ask for PIN
            t.TypeLine("Please enter your PIN.");
            int PINCheck = Convert.ToInt16(Console.ReadLine());
            const int maxTries = 3;
            int tries = 0;

            while (tries < maxTries)
            {
                t.TypeLine("Please enter your PIN:");
                PINCheck = Convert.ToInt16(Console.ReadLine());

                if (CSV.CheckPIN(ANVerify, PINCheck))
                {
                    // PIN is correct, break out of the loop
                    t.TypeLine("PIN is correct.");
                    break;
                }
                else
                {
                    // PIN is incorrect, increment the number of tries
                    tries++;

                    if (tries < maxTries)
                    {
                        // Prompt the user to try again
                        t.TypeLine("Incorrect PIN. Please try again.");
                    }
                    else
                    {
                        // Max tries reached, exit the program
                        t.TypeLine("Incorrect PIN. Max tries reached. Exiting program.");
                        Environment.Exit(0);
                    }
                }
            }
            
        }

        /*// future functionality name for accounts
        t.TypeFast("May we please have a name for the account.");
        customerName = Console.ReadLine();
        t.TypeLine($"Thank you, {customerName}.");
        t.TypeLine("How can we help you today?");
        */

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
                        t.TypeLine("Have you 'found' anymore you want to include?");
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
                        t.TypeLine("Have you 'found' anymore you want to include?");
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
                        t.TypeLine($"You currently have: {Convert.ToString(CSV.GetBalance(AN))} gold.");
                        t.TypeLine("Have you 'found' anymore you want to include?");
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
                
                
                t.TypeLine("Very well, Thank you for using Multiversal Bank.");
                t.TypeLine($"Have a nice day {customerName}.");
            }
        }
    }
}