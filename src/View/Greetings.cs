using System;

namespace MVCalc
{
    class Greetings
    {
        public static void ShowWelcomeScreen()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Welcome to MVC Calculator.\nEnter first operand (x), then a math operator to be applied, and then the second operand (y).\nType \"Exit\" to quit the program.");
            Console.WriteLine("Available operators:\nx+y\nx-y\nx*y\nx/y\nx^y\n");
            Console.WriteLine("********\n");
        }

        public static void ShowFarewellScreen()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nThank you for choosing MVC Calculator. Quitting...");
        }
    }
}
