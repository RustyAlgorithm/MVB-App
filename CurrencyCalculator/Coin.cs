﻿using System;

namespace CurrencyCalculator
{
	public class Coin
	{
        public float Total;
        float runningTotal = 0;
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
