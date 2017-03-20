using System;
using System.Collections.Generic;

namespace MVCalc
{
    class Validation
    {
        const string exit = "exit";

        public static void GetAndCheckOperands(Data data, int i, ref bool exiting)
        {
            bool validating = false;
            do
            {
                string s_temp = ReadInputData.GetOperand(i).Replace(".", ",");
                if (s_temp == exit) exiting = true;
                validating = data.ParseOperand(s_temp, i);
                if (!validating && !exiting) DisplayWarning.ShowWarning("ERROR: Wrong value. Please enter a valid decimal value.");
            } while (!validating && !exiting);
        }

        public static void GetAndCheckOperator(Data data, Dictionary<char?, Dlgt> d,  ref char? operator_symbol, ref bool exiting)
        {
            do
            {
                string s_temp = ReadInputData.GetOperator();
                if (s_temp.ToLower() == exit) exiting = true;
                operator_symbol = data.ParseOperator(s_temp);
                if (operator_symbol!=null && !d.ContainsKey(operator_symbol)) operator_symbol = null;
                if (operator_symbol==null && !exiting) DisplayWarning.ShowWarning("ERROR: Wrong operator. Please enter a valid symbol.");
            } while (operator_symbol ==null && !exiting);
        }
    }
}
