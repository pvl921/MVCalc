using System;
using System.Text;

namespace MVCalc
{
    class Program
    {

        static void Main(string[] args)
        {
            bool exiting = false, validating = false;
            int operator_id = -1;
            Data data = new Data();

            Greetings.ShowWelcomeScreen();

            while (true)
            {
                data.Operand1 = double.NaN;
                data.Operand2 = double.NaN;
                data.Result = double.NaN;
                string s_temp = "";

                // get operand 1 or quit if "exit"
                Validation.GetAndCheckOperands(data, 1, ref s_temp, ref exiting);
                if (exiting) break;

                // get operator or quit if "exit"
                Validation.GetAndCheckOperator(data, ref operator_id, ref s_temp, ref exiting);
                if (exiting) break;

                // get operand 2 or quit if "exit"
                Validation.GetAndCheckOperands(data, 2, ref s_temp, ref exiting);
                if (exiting) break;

                // apply transform functions + check for exceptions in operands
                switch (operator_id)
                {
                    case 0: 
                        data.Result = Transformation.Sum(data.Operand1, data.Operand2);
                        break;
                    case 1:
                        data.Result = Transformation.Subtract(data.Operand1, data.Operand2);
                        break;
                    case 2:
                        data.Result = Transformation.Multiply(data.Operand1, data.Operand2);
                        break;
                    case 3:
                        if (data.Operand2 == 0)
                        {
                            DisplayWarning.ShowWarning("ERROR: Cannot divide by zero. Expression has not been evaluated.\n");
                            continue;
                        }
                        else
                        {
                            data.Result = Transformation.Divide(data.Operand1, data.Operand2);
                        }
                        break;
                    case 4:
                        if (data.Operand1 < 0 && data.Operand2 < 1 && data.Operand2 > 0)
                        {
                            DisplayWarning.ShowWarning("ERROR: Complex numbers are not supported. Expression has not been evaluated.\n");
                            continue;
                        }
                        else
                        {
                            data.Result = Transformation.Power(data.Operand1, data.Operand2);
                        }
                        break;
                    default:
                        break;
                }
 
                // display result
                if (double.IsNegativeInfinity(data.Result))
                {
                    DisplayResult.ShowResult("-Infinity");
                }
                else if (double.IsPositiveInfinity(data.Result))
                {
                    DisplayResult.ShowResult("+Infinity");
                 }
                else DisplayResult.ShowResult(data.Result.ToString());
            }
                       
            Greetings.ShowFarewellScreen();
         }
     }
}