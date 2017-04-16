using System;
using MVCalc.Enums;
using MVCalc.Controllers;
using MVCalc.Views;
using MVCalc.Models;

namespace MVCalc
{
    public class Program
    {
        // Удален контроллер DisplayController. Методы View вызываются в Program.cs напрямую.
        // Операции в EvaluationController разделены по отдельным методам.

        ///<summary>
        ///Программа-калькулятор с использованием модулей контроллера (controller), модели (model) и отображения (view).
        /// </summary> 
        static void Main() 
        {
            const string EXIT = "exit";

            View.Render(MessageTypesEnum.MessageTypes.Default, "Welcome to MVC Calculator.\nEnter first operand(x), then a math operator to be applied, and then the second operand(y).\nType \"Exit\" to quit the program.\n" +
                                "Available operators:\nx + y\nx - y\nx * y\nx / y\nx ^ y\n\n");

            while (true)
            {
                string consoleOp1, consoleOp2, consoleOp;

                // get operand 1 or quit if "exit"
                View.Render(MessageTypesEnum.MessageTypes.Operand, ($"Введите первый операнд:\t\t")); // вместо DisplayController вывод на экран выполняем здесь
                consoleOp1 = Console.ReadLine();
                if (String.Equals(consoleOp1, EXIT, StringComparison.OrdinalIgnoreCase)) { DisplayExitMessage(); break; } // используем String.Equals c методом сравнения StringComparison.OrdinalIgnoreCase

                // get operator or quit if "exit"
                View.Render(MessageTypesEnum.MessageTypes.Operator, ($"Введите оператор:\t\t"));
                consoleOp = Console.ReadLine();
                if (String.Equals(consoleOp, EXIT, StringComparison.OrdinalIgnoreCase)) { DisplayExitMessage(); break; }

                // get operand 2 or quit if "exit"               
                View.Render(MessageTypesEnum.MessageTypes.Operand, ($"Введите второй операнд:\t\t"));
                consoleOp2 = Console.ReadLine();
                if (String.Equals(consoleOp2, EXIT, StringComparison.OrdinalIgnoreCase)) { DisplayExitMessage(); break; }

                // calculate the result and check for undefined operator
                DataModel model;
                switch (consoleOp)
                    {
                        case "+":
                            model = EvaluationController.Sum(consoleOp1, consoleOp2); 
                            break;
                        case "-":
                            model = EvaluationController.Subtract(consoleOp1, consoleOp2); 
                        break;
                        case "*":
                            model = EvaluationController.Multiply(consoleOp1, consoleOp2); 
                        break;
                        case "/":
                            model = EvaluationController.Divide(consoleOp1, consoleOp2);
                        break;
                        case "^":
                            model = EvaluationController.Power(consoleOp1, consoleOp2); 
                        break;
                        default:
                            model = EvaluationController.Undefined(consoleOp); // уже был в отдельном методе, не меняется
                        break;
                    }

                // bring the result or error message to the user
                if (!model.IsResultOk)
                    View.Render(MessageTypesEnum.MessageTypes.Warning, $"ОШИБКА! {model.Result}\n\n");
                else
                    View.Render(MessageTypesEnum.MessageTypes.Result, $"Результат:\t\t\t{model.Result}\n\n");
            }
         }

        // отдельный метод для упрощения записи
        static void DisplayExitMessage ()
        {
            View.Render(MessageTypesEnum.MessageTypes.Default, "...quitting...\n");
        }
     }
}