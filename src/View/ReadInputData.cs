using System;

namespace MVCalc
{

    class ReadInputData
    {
        public static string GetOperand (int i)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            switch (i)
            {
                case 1:
                    Console.Write("Enter the first operand:\t");
                    break;
                case 2:
                    Console.Write("Enter the second operand:\t");
                    break;
                default:
                    break;
            }
            return Console.ReadLine().ToLowerInvariant();
        }

        public static string GetOperator()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter the operator:\t\t");
            return Console.ReadLine().ToLowerInvariant();
        }

    }
}
