using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Shared.RoundUp
{
    public static class ConvertToTwoDecimal
    {
        public static double RoundUp(double input)
        {
            double multiplier = Math.Pow(10, Convert.ToDouble(2));
            return Math.Ceiling(input * multiplier) / multiplier;
        }
    }
}
