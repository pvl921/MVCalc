using System;
using System.Text;

namespace MVCalc
{
    class DisplayResult
    {
        public static void ShowResult(string s)
        {
            Console.ForegroundColor = ConsoleColor.White;           
            Console.WriteLine("Result:\t\t\t\t{0}\n", s);
        }
    }
}
