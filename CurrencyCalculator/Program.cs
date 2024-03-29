﻿using System;
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

        // future functionality name for accounts
        t.TypeFast("May we please have a name for the account.");
        customerName = Console.ReadLine();
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
                        t.TypeLine($"You currently have: {Convert.ToString(CSV.GetBalance(customerName))} gold.");
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