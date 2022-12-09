using System;
using System.Runtime.Intrinsics.X86;

namespace CurrencyCalculator
{
	public class SmallTalk
	{
        public SmallTalk()
        {
        }

        public string Greeting(int Num)
        {
            switch (Num)
            {
                case 0:
                    {
                        return "Glad tidings,";
                    }
                    break;
                 case 1:
                    {
                        return "Hello,";
                    }
                    break;
                case 2:
                    {
                        return "Greetings,";
                    }
                    break;
                case 3:
                    {
                        return "Good timings,";
                    }
                    break;
                case 4:
                    {
                        return "G'day,";
                    }
                    break;
                case 5:
                    {
                        return "Hugaabugore,";
                    }
                    break;
                case 6:
                    {
                        return "Gublobleoorrre,";
                    }
                    break;
                default:
                    {
                        return "Welcome,";
                    }
                    break;
            }

           
        }

        Random r = new Random();

        public string Thank(int Num)
        {
            if (Num == 0)
            {
                return "Very well.";
            }
            else if (Num <= 5)
            {
                return "Oh, how nice.";
            }
            else if (Num <= 10)
            {
                return "Wow, good job!";
            }
            else if (Num <= 15)
            {
                return "Hey, look at you bringing in the big bucks I see.";
            }
            else if (Num <= 20)
            {
                return "Ta.";
            }
            else if (Num <= 99)
            {
                int rand = r.Next(1, 3);
                switch (rand)
                {
                    case 1:
                        {
                            return "Thank you muchly.";
                        }
                        break;
                    case 2:
                        {
                            return "Thank you kindly.";
                        }
                        break;
                    default:
                        {
                            return "Thank you.";
                        }
                        break;
                }
            }
            else if (Num >= 100)
            {
                return "Thank you, indeed.";
            }
            else
            {
                return "Hmm.";
            }
        }
    }
}

