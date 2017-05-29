using System;
using MVCalc.Enums;
using MVCalc.Controllers;
using MVCalc.Views;
using MVCalc.Models;
using MVCalc.Constants;
using System.Collections.Generic;

namespace MVCalc
{
    public class Program
    {
        ///<summary>
        ///Программа-калькулятор с использованием модулей контроллера (controller), модели (model) и отображения (view).
        /// </summary> 
        static void Main() 
        {
            View.Render(MessageTypesEnum.MessageTypes.Default, "Welcome to MVC Calculator.\nEnter first operand(x), then a math operator to be applied, and then the second operand(y).\nType \"Exit\" to quit the program.\n" +
                                "Available operators:\nx + y\nx - y\nx * y\nx / y\nx ^ y\n" +
                                "Type \"LOG\" to view the log.\n" +
                                "Type \"RECORD x\" to view the log record number x.\n" +
                                "Type \"DEL x\" to delete the log record number x.\n\n");

            while (true)
            {
                string consoleOp1, consoleOp2, consoleOp;

                // get operand 1 or quit if "exit" or display log if "log" or delete from log if "del ..."
                View.Render(MessageTypesEnum.MessageTypes.Operand, ($"Введите первый операнд:\t\t")); 
                consoleOp1 = Console.ReadLine();
                var flowControl = ProcessInput(consoleOp1);
                if (flowControl == FlowControlEnum.FlowControl.Break) break;
                if (flowControl == FlowControlEnum.FlowControl.Continue) continue;

                // get operator or quit if "exit" or display log if "log" or delete from log if "del ..."
                View.Render(MessageTypesEnum.MessageTypes.Operator, ($"Введите оператор:\t\t"));
                consoleOp = Console.ReadLine();
                flowControl = ProcessInput(consoleOp);
                if (flowControl == FlowControlEnum.FlowControl.Break) break;
                if (flowControl == FlowControlEnum.FlowControl.Continue) continue;

                // get operand 2 or quit if "exit" or display log if "log" or delete from log if "del ..."              
                View.Render(MessageTypesEnum.MessageTypes.Operand, ($"Введите второй операнд:\t\t"));
                consoleOp2 = Console.ReadLine();
                flowControl = ProcessInput(consoleOp2);
                if (flowControl == FlowControlEnum.FlowControl.Break) break;
                if (flowControl == FlowControlEnum.FlowControl.Continue) continue;

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
                            model = EvaluationController.Undefined(consoleOp); 
                        break;
                    }

                // bring the result or error message to the user
                if (!model.IsResultOk)
                    View.Render(MessageTypesEnum.MessageTypes.Warning, $"ОШИБКА! {model.Result}\n\n");
                else
                    View.Render(MessageTypesEnum.MessageTypes.Result, $"Результат:\t\t\t{model.Result}\n\n");

                // logging result to database
                if (LogController.Add(model, consoleOp1, consoleOp, consoleOp2) == 0) View.Render(MessageTypesEnum.MessageTypes.Warning, $"ОШИБКА! {Messages.MSG_DB_FAILURE}\n\n"); ;
            }
         }

        // отдельный метод для упрощения записи
        static void DisplayExitMessage ()
        {
            View.Render(MessageTypesEnum.MessageTypes.Default, "...quitting...\n");
        }

        // вспомогательный метод для распознавания команд при вводе
        // возвращает значения FlowControlEnum для выхода из программы, прерывания текущего цикла, нормального продолжения цикла
        static FlowControlEnum.FlowControl ProcessInput(string input)
        {
            if (String.Equals(input, Commands.EXIT, StringComparison.OrdinalIgnoreCase)) { DisplayExitMessage(); return FlowControlEnum.FlowControl.Break; }

            if (String.Equals(input, Commands.LOG, StringComparison.OrdinalIgnoreCase)) {
                try
                {
                    List<LogModel> logToDisplay = LogController.List();
                    View.Render(MessageTypesEnum.MessageTypes.Default, "[Журнал событий]\n");
                    foreach (var row in logToDisplay)
                    {
                        View.Render(MessageTypesEnum.MessageTypes.Default, $"ID: {row.ID}\tДействие: {row.ResultLog}\tВремя: {row.DateTimeLog}\n");
                    }
                    View.Render(MessageTypesEnum.MessageTypes.Default, "[Конец журнала событий]\n\n");
                }
                catch { View.Render(MessageTypesEnum.MessageTypes.Warning, $"ОШИБКА! {Messages.MSG_DB_FAILURE}\n\n"); };
                return FlowControlEnum.FlowControl.Continue;
            }

            if (input.StartsWith(Commands.LOG_ID, StringComparison.OrdinalIgnoreCase))
            {
                if (!int.TryParse(input.Replace(Commands.LOG_ID, "").Trim(), out int id))
                {
                    View.Render(MessageTypesEnum.MessageTypes.Warning, $"ОШИБКА! Необходимо ввести целое число.\n\n");
                    return FlowControlEnum.FlowControl.Continue;
                };
                try
                {
                    LogModel row = LogController.Get(id);
                    if (row.ID > 0)
                    { View.Render(MessageTypesEnum.MessageTypes.Default, $"[Запись из журнала событий ID={row.ID}]\n" +
                        $"ID: {row.ID}\tДействие: {row.ResultLog}\tВремя: {row.DateTimeLog}\n\n"); }
                    else
                    { View.Render(MessageTypesEnum.MessageTypes.Warning, $"ОШИБКА! Запись с номером [{id}] отсутствует.\n\n"); }
                }
                catch { View.Render(MessageTypesEnum.MessageTypes.Warning, $"ОШИБКА! {Messages.MSG_DB_FAILURE}\n\n"); }
                return FlowControlEnum.FlowControl.Continue;
            }

            if (input.StartsWith(Commands.DEL, StringComparison.OrdinalIgnoreCase))
            {
                if (!int.TryParse(input.Replace(Commands.DEL, "").Trim(), out int idToDelete))
                {
                    View.Render(MessageTypesEnum.MessageTypes.Warning, $"ОШИБКА! Необходимо ввести целое число.\n\n");
                    return FlowControlEnum.FlowControl.Continue;
                };
                if (LogController.Delete(idToDelete) == 0)
                { View.Render(MessageTypesEnum.MessageTypes.Warning, $"ОШИБКА! Невозможно удалить запись с номером [{idToDelete}]\n\n"); }
                else { View.Render(MessageTypesEnum.MessageTypes.Default, $"Из журнала событий удалена запись с номером [{idToDelete}]\n\n"); };
                return FlowControlEnum.FlowControl.Continue;
            }
            return FlowControlEnum.FlowControl.Normal;
        }


     }
}