using System;

namespace MVCalc
{
    public class Data
    {
        public double Operand1;
        public double Operand2;
        public double Result;
        
        public bool ParseOperand(string s, int i)
        {
            if (i == 1) return double.TryParse(s, out Operand1); 
            if (i == 2) return double.TryParse(s, out Operand2); 
            return false;
        }

        public char? ParseOperator(string s)
        {
            if (s.Length!=1) return null;
            return s[0];
        }

    }
}
