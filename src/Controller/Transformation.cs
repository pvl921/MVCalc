using System;

namespace MVCalc
{
    class Transformation
    {
        public static double Sum(double op1, double op2)
        {
            return op1 + op2;
        }

        public static double Subtract(double op1, double op2)
        {
            return op1 - op2;
        }

        public static double Multiply(double op1, double op2)
        {
            return op1 * op2;
        }

        public static double Divide(double op1, double op2)
        {
            return op1 / op2;
        }

        public static double Power(double op1, double op2)
        {
            return Math.Pow(op1, op2);
        }

    }
}
