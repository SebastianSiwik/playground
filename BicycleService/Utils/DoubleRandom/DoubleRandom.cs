using System;

namespace BicycleService.Utils.DoubleRandom
{
    public static class DoubleRandom
    {
        public static double AddRandomFraction(this int randomValue)
        {
            double fraction = (double)(new Random().Next(100)) / 100;
            return randomValue + fraction;
        }
    }
}
