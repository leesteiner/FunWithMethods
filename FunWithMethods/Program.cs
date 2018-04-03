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

            #region Ref locals and params
            string[] stringArray = { "one", "two", "three" };
            int pos = 1;
            Console.WriteLine("=> Use Simple Return");
            Console.WriteLine("Before: {0}, {1}, {2}", stringArray[0], stringArray[1], stringArray[2]);

            var output = SimpleReturn(stringArray, pos);
            output = "new";
            Console.WriteLine("After: {0}, {1}, {2}", stringArray[0], stringArray[1], stringArray[2]);

            Console.WriteLine("=> Use Ref Return");
            Console.WriteLine("Before: {0}, {1}. {2}", stringArray[0], stringArray[1], stringArray[2]);
            ref var refOutput = ref SampleRefReturn(stringArray, pos);
            refOutput = "new";
            Console.WriteLine("After: {0}, {1}, {2} ", stringArray[0], stringArray[1], stringArray[2]);
            #endregion

            Console.WriteLine("Params test");
            //Pass in a comma-delimited list
            double average;
            average = CalculateAverage(4.0, 3.2, 5.7, 64.22, 87.2);
            Console.WriteLine("Average of data is: {0}", average);

            //Pass in an array of doubles
            double[] data = { 4.0, 3.2, 5.7 };
            average = CalculateAverage(data);
            Console.WriteLine("Average of data is {0}", average);

            //Average of 0 is 0!
            Console.WriteLine("average of data is: {0}", CalculateAverage());
            Console.ReadLine();

            Console.WriteLine("*****Error Ownership*****");
            EnterLogData("Oh no! Grid can't find data!");
            EnterLogData("Oh no! I can't find the payroll data", "CFO");
            Console.ReadLine();

            Console.WriteLine("*****Passing by Names Parameters*****");
            DisplayFancyMessage(message: "Wow! Very Fancy Indeed!", backgroundColor: ConsoleColor.White, textColor: ConsoleColor.DarkRed);
            DisplayFancyMessage(backgroundColor: ConsoleColor.Magenta, message: "Testing.... testing....", textColor: ConsoleColor.DarkYellow);

            Console.WriteLine("Testing mix of named arguments and positional arguments");
            DisplayFancyMessage(ConsoleColor.Cyan, message: "More testing", backgroundColor: ConsoleColor.Black);

            Console.WriteLine("Fancy message with mix of default value and named args");
            DisplayFancierMessage(message: "Test this!");
            DisplayFancierMessage(backgroundColor: ConsoleColor.Red);
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

        public static string SimpleReturn(string[] strArray, int position)
        {
            return strArray[position];
        }

        public static ref string SampleRefReturn(string[] strArray, int position)
        {
            return ref strArray[position];
        }

        static double CalculateAverage(params double[] values)
        {
            Console.WriteLine("You sent me {0} doubles", values.Length);

            double sum = 0;
            if(values.Length == 0)
            {
                return sum;
            }
            for (int i = 0; i <values.Length;i++)
            {
                sum += values[i];
            }
            return (sum / values.Length);
        }

        static void EnterLogData(string message, string owner = "Lee")
        {
            Console.Beep();
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
        }

        static void DisplayFancyMessage(ConsoleColor textColor, ConsoleColor backgroundColor, string message)
        {
            //Store old color to restore after message is printed.
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldBackgroundColor = Console.BackgroundColor;

            //Set new colors and print message
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);

            //Restore Previous colors
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldBackgroundColor;
        }

        static void DisplayFancierMessage(ConsoleColor textColor = ConsoleColor.Blue, ConsoleColor backgroundColor = ConsoleColor.DarkBlue, string message = "Fancy testing....")
        {
            //Store old color to restore after message is printed.
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldBackgroundColor = Console.BackgroundColor;

            //Set new colors and print message
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(message);

            //Restore Previous colors
            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldBackgroundColor;

        }
    }
}
