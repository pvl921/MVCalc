using System;
using System.Text;
using System.Collections.Generic;

namespace MVCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exiting = false;
            char? operator_symbol;
            Data data = new Data();

            Greetings.ShowWelcomeScreen();

            while (true)
            {
                data.Operand1 = double.NaN;
                data.Operand2 = double.NaN;
                data.Result = double.NaN;
                operator_symbol = null;
 
                // get operand 1 or quit if "exit"
                Validation.GetAndCheckOperands(data, 1, ref exiting);
                if (exiting) break;

                // get operator or quit if "exit"
                Validation.GetAndCheckOperator(data, Transformation.AvailOps, ref operator_symbol, ref exiting);
                if (exiting) break;

                // get operand 2 or quit if "exit"
                Validation.GetAndCheckOperands(data, 2, ref exiting);
                if (exiting) break;

                // apply transform functions + check for exceptions in operands                
                if (!Transformation.AvailOps.TryGetValue(operator_symbol, out Dlgt SelectedTrans)) throw new Exception("Unknown operator");
                data.Result = SelectedTrans(data.Operand1, data.Operand2);
                if (double.IsNaN(data.Result)) continue; 

            
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