using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    public static class Palindrome
    {
        public static bool IsPalindrome(string s)
        {
            if (s.Length < 1)
            {
                return true;
            }
            
            int a = 0;
            int b = s.Length-1;
            char[] ar = s.ToLower().ToCharArray();

            while (!char.IsLetterOrDigit(ar[a]))
            {
                a++;
            }
            while (!char.IsLetterOrDigit(ar[b]))
            {
                b--;
            }

            while (a < b)
            {
                if (ar[a] == ar[b])
                {
                    a++; b--;
                } else
                {
                    return false;
                }

                while (!char.IsLetterOrDigit(ar[a]))
                {
                    a++;
                }
                while (!char.IsLetterOrDigit(ar[b]))
                {
                    b--;
                }
            }

            return true;
        }
    }
}
