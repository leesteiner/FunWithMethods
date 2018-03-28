using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Methods *****");

            //Pass two variables in by value.
            int x = 9, y = 10;
            
            Console.WriteLine("Before call: X: {0}, Y: {1}", x, y);
            Console.WriteLine("Answer is: {0}", Add(x, y));
            Console.WriteLine("After call: X: {0}, Y: {1}", x, y);
            OutAdd(x, y, out int ans);
            Console.WriteLine("Using Add with out keyword: {0} + {1} = {2}", x, y, ans);

           // int i;string str; bool b;
            FillTheseValues(out int i, out string str, out bool b);

            Console.WriteLine($"Variables are: i = {i}, str = {str}, b = {b}");

            string str1 = "Flip";
            string str2 = "Flop";
            Console.WriteLine("Before: {0}, {1} ", str1, str2);
            SwapStrings(ref str1, ref str2);
            Console.WriteLine($"After: {str1}, {str2}");

            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            int ans = x + y;
            //Caller will not see these changes, as you are modifying
            //a copy of the original data.
            x = 10000;
            y = 88888;
            return ans;
        }

        static void OutAdd(int x, int y, out int ans)
        {
            ans = x + y;
        }

        static void FillTheseValues(out int a, out string b, out bool c)
        {
            a = 9;
            b = "Enjoy your string.";
            c = true;
        }

        static void SwapStrings(ref string s1, ref string s2)
        {
            string tempStr = s1;
            s1 = s2;
            s2 = tempStr;
        }
    }
}
