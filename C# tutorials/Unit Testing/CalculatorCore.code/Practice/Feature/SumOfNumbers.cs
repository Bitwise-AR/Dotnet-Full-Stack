using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Feature
{
    public class SumOfNumbers
    {
        public int SumOfN(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Input must be a non-negative integer.");
            }
            return n * (n + 1) / 2;
        }
    }
}
