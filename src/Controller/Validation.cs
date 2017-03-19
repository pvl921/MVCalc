using System;

namespace MVCalc
{
    class Validation
    {
        const string exit = "exit";

        public static void GetAndCheckOperands(Data data, int i, ref string s_temp, ref bool exiting)
        {
            bool validating = false;
            do
            {
                s_temp = ReadInputData.GetOperand(i).Replace(".", ",");
                if (s_temp == exit) exiting = true;
                validating = data.ParseOperand(s_temp, i);
                if (!validating && !exiting) DisplayWarning.ShowWarning("ERROR: Wrong value. Please enter a valid decimal value.");
            } while (!validating && !exiting);
        }

        public static void GetAndCheckOperator(Data data, ref int operator_id, ref string s_temp, ref bool exiting)
        {
            do
            {
                s_temp = ReadInputData.GetOperator();
                if (s_temp.ToLower() == exit) exiting = true;
                operator_id = data.ParseOperator(s_temp);
                if (operator_id < 0 && !exiting) DisplayWarning.ShowWarning("ERROR: Wrong operator. Please enter a valid symbol.");
            } while (operator_id < 0 && !exiting);
        }
    }
}
