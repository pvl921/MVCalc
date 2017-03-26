using System;
using System.Text;
using System.Collections.Generic;

namespace MVCalc
{
    public class Program
    {
        ///<summary>
        ///Преобразует строку в численный тип (double).
        /// </summary> 
        static (bool, double) TryParseOperand(string stringInput)
        {
            bool parsingSuccess = true;
            double parsedValue = double.NaN;

            try
            {
                parsedValue = double.Parse(stringInput);
            }
            catch (FormatException ex)
            {
                parsingSuccess = false;
                throw new FormatException("Неверный формат операнда.");
            }
            catch (OverflowException ex)
            {
                parsingSuccess = false;
                throw new OverflowException("Значение операнда выходит за допустимые границы.");
            }
            return (parsingSuccess, parsedValue);
        }

        ///<summary>
        ///Программа-калькулятор с использованием модулей контроллера (controller), модели (model) и отображения (view).
        /// </summary> 
        static void Main(string[] args)
        {
            char operator_symbol;
            string consoleInput;
            double operand1, operand2, result;
            const string exit = "exit";
            bool operand1OK, operand2OK, operatorOK, resultOK;
            OperatorDelegate SelectedTransformation;
            bool firstTime = true;
            Data data = new Data();

            while (true)
            {
                operand1OK = false;
                operand2OK = false;
                operatorOK = false;
                operator_symbol = ' ';

                // get operand 1 or quit if "exit"
                InputController.GetInput(firstTime, 0);
                if (firstTime) firstTime = false;
                consoleInput = Console.ReadLine().Replace(".", ",");
                if (consoleInput.ToLower() == exit) { OutputController.Quit(); break; }
                try
                {
                    (operand1OK, operand1) = TryParseOperand(consoleInput);
                }
                catch (Exception ex)
                {
                    OutputController.ParseException(ex.Message); continue;
                }

                // get operator or quit if "exit"
                InputController.GetInput(firstTime, 1);
                consoleInput = Console.ReadLine();
                if (consoleInput.ToLower() == exit) { OutputController.Quit(); break; };
                operatorOK = false;
                if (consoleInput.Length == 1)
                    try
                    {
                        operator_symbol = (char)consoleInput[0];
                        operatorOK  = TransformationService.AvailableOperators.ContainsKey(operator_symbol)? true:false;
                    }
                    catch
                    {
                        operatorOK = false;
                    }

                // get operand 2 or quit if "exit"
                InputController.GetInput(firstTime, 0, "второй");
                consoleInput = Console.ReadLine().Replace(".", ",");
                if (consoleInput.ToLower() == exit) { OutputController.Quit(); break; };
                try
                {
                    (operand2OK, operand2) = TryParseOperand(consoleInput);
                }
                catch (Exception ex)
                {
                    OutputController.ParseException(ex.Message); continue;
                }                

                // apply selected operator to operands
                if (operand1OK && operand2OK && operatorOK)
                {
                    SelectedTransformation = TransformationService.AvailableOperators[operator_symbol];
                    result = SelectedTransformation(operand1, operand2);
                    if (!double.IsNaN(result)) { resultOK = true; } else { resultOK = false; };
                }
                else
                {
                    result = double.NaN;
                    resultOK = false;
                }

                // update Model fields
                OutputController.UpdateModel(data, result, resultOK);

                // bring the result or error message to the user
                OutputController.ProcessResult(data);
                }
         }
     }
}