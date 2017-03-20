using System;
using System.Collections.Generic;

namespace MVCalc
{
    public delegate double Dlgt(double x, double y);

    class Transformation
    {

        public static Dictionary<char?, Dlgt> AvailOps = new Dictionary<char?, Dlgt>
            {
                { '+', new Dlgt(Sum) },
                { '-', new Dlgt(Subtract) },
                { '*', new Dlgt(Multiply) },
                { '/', new Dlgt(Divide) },
                { '^', new Dlgt(Power) }
            };

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
            if (op2 == 0)
            {
                DisplayWarning.ShowWarning("ERROR: Cannot divide by zero. Expression has not been evaluated.\n");
                return double.NaN;
            }
            return op1 / op2;
        }

        public static double Power(double op1, double op2)
        {
            if (op1 < 0 && op2 != 0 && op2 < 1 && op2 > -1)
            {
                DisplayWarning.ShowWarning("ERROR: Complex numbers are not supported. Expression has not been evaluated.\n");
                return double.NaN;
            }
            return Math.Pow(op1, op2);
        }

    }
}
