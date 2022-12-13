using System;
using System.Threading.Tasks;

namespace CurrencyCalculator
{
    public class Deposits
    {


        TypeOut t = new TypeOut();
        SmallTalk s = new SmallTalk();
        Coin c = new Coin();
        SaveToCSV csv = new SaveToCSV();
        Actions a = new Actions();

        int total;
        float hold;
        int thank;
        float currentGold = 0; 

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
            float newtotal = Convert.ToSingle(c.CountCoins(cP, sP, eP, gP, pP)) + a.CurrentBalance;
            t.TypeLine("Please wait while we count your coins.");
            t.WaitLine(newtotal);
            Thread.Sleep(100);  

            return $"Your total is: {Convert.ToString(newtotal)} gold.";
        }
        public float CurrentDeposit()
        {
            return c.Total;
        }
        
    }
}

