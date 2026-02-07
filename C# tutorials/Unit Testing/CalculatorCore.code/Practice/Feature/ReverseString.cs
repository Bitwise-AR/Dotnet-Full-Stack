using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Feature
{
    public class ReverseString
    {
        public string Reverse(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
