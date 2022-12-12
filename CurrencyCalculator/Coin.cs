using System;

namespace CurrencyCalculator
{
	class Coin
	{
        public float Total;
        float runningTotal;
        public string CountCoins(float cP, float sP, float eP, float gP, float pP)
        {
            string total;
            

            Total = cP + sP + eP + gP + pP + runningTotal;
            runningTotal = Total;
            total = Convert.ToString(Total);

            return total;
        }
        

    }
}
