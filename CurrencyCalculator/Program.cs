using System;
using CurrencyCalculator;
using System.Threading;
using System.Threading.Tasks;
using System.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        Random rng = new Random();
        TypeOut t = new TypeOut();
        SmallTalk s = new SmallTalk();
        Deposits d = new Deposits();

        bool finished = false;
        string PersonOrOrganisation = "";

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

        // future fuctionality party funds or accounts for specific people
        /*while (PersonOrOrganisation == null)
        {
            t.TypeWait("Now, ");
            t.TypeFast("are you an idividual or an organisation/party/guild/business or abyssal entity?");
            PersonOrOrganisation = Console.ReadLine();
        }

        PersonOrOrganisation.ToLower(); */



        //switch (PersonOrOrganisation)
        //{
        //case("")
        //{
        //;
        //}
        //break;
        //}

        // future functionality name for accounts
        t.TypeFast("may I please have a name for the account.");
        string customerName = Console.ReadLine();
        t.TypeLine($"Thank you, {customerName}.");
        t.TypeLine("How can we help you today?");
        //test

        // main section.
        while(finished == false)
        {

            int option = 0;

            t.TypeFast("1) Full Deposit");
            t.TypeFast("2) Platinum Deposit");
            t.TypeFast("3) Gold Deposit");
            t.TypeFast("4) Electrum Deposit");
            t.TypeFast("5) Silver Deposit");
            t.TypeFast("6) Copper Deposit");
            t.TypeFast("7) Exit");
            t.TypeFast("Please enter the number of the option you require.");

            option = Convert.ToInt16(Console.ReadLine());

            string continueActions = "no";

            switch (option)
            {
                case (1):
                    {
                        t.TypeFast(d.DepositTotal(d.CopperDeposit(), d.SilverDeposit(), d.ElectrumDeposit(), d.GoldDeposit(), d.PlatinumDeposit()));
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
                        t.TypeFast(d.DepositTotal(0, 0, 0, 0, d.PlatinumDeposit()));
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
                        t.TypeFast(d.DepositTotal(0, 0, 0, d.GoldDeposit(), 0));
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
                        t.TypeFast(d.DepositTotal(0, 0, d.ElectrumDeposit(), 0, 0));
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
                case (5):
                    {
                        t.TypeFast(d.DepositTotal(0, d.SilverDeposit(), 0, 0, 0));
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
                case (6):
                    {
                        t.TypeFast(d.DepositTotal(d.CopperDeposit(), 0, 0, 0, 0));
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
                case (7):
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