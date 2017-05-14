using System;
using MVCalc.Enums;
using MVCalc.Controllers;
using MVCalc.Views;
using MVCalc.Models;
using MVCalc.Constants;
using System.Data.SqlClient;

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
                if (String.Equals(consoleOp1, Commands.EXIT, StringComparison.OrdinalIgnoreCase)) { DisplayExitMessage(); break; }
                if (String.Equals(consoleOp1, Commands.LOG, StringComparison.OrdinalIgnoreCase)) { DisplayLog(); continue; }
                if (consoleOp1.StartsWith(Commands.LOG_ID, StringComparison.OrdinalIgnoreCase))
                {
                    string _idToDisplay = consoleOp1.Replace(Commands.LOG_ID, "").Trim();
                    if (!DisplayLogId(_idToDisplay)) 
                    { View.Render(MessageTypesEnum.MessageTypes.Warning, $"ОШИБКА! Запись с номером [{_idToDisplay}] отсутствует.\n\n"); }
                    continue;
                }
                if (consoleOp1.StartsWith (Commands.DEL,StringComparison.OrdinalIgnoreCase))
                {
                    string _idToDelete = consoleOp1.Replace(Commands.DEL, "").Trim();
                    if (LogController.DeleteFromLog(_idToDelete) == 0)
                    { View.Render(MessageTypesEnum.MessageTypes.Warning, $"ОШИБКА! Невозможно удалить запись с номером [{_idToDelete}]\n\n"); }
                    else { View.Render(MessageTypesEnum.MessageTypes.Default, $"Из журнала событий удалена запись с номером [{_idToDelete}]\n\n"); };
                    continue;
                }

                // get operator or quit if "exit" or display log if "log" or delete from log if "del ..."
                View.Render(MessageTypesEnum.MessageTypes.Operator, ($"Введите оператор:\t\t"));
                consoleOp = Console.ReadLine();
                if (String.Equals(consoleOp, Commands.EXIT, StringComparison.OrdinalIgnoreCase)) { DisplayExitMessage(); break; }
                if (String.Equals(consoleOp, Commands.LOG, StringComparison.OrdinalIgnoreCase)) { DisplayLog(); continue; }
                if (consoleOp.StartsWith(Commands.LOG_ID, StringComparison.OrdinalIgnoreCase))
                {
                    string _idToDisplay = consoleOp.Replace(Commands.LOG_ID, "").Trim();
                    if (!DisplayLogId(_idToDisplay))
                    { View.Render(MessageTypesEnum.MessageTypes.Warning, $"ОШИБКА! Запись с номером [{_idToDisplay}] отсутствует.\n\n"); }
                    continue;
                }
                if (consoleOp.StartsWith(Commands.DEL, StringComparison.OrdinalIgnoreCase))
                {
                    string _idToDelete = consoleOp.Replace(Commands.DEL, "").Trim();
                    if (LogController.DeleteFromLog(_idToDelete) == 0)
                    { View.Render(MessageTypesEnum.MessageTypes.Warning, $"ОШИБКА! Невозможно удалить запись с номером [{_idToDelete}]\n\n"); }
                    else { View.Render(MessageTypesEnum.MessageTypes.Default, $"Из журнала событий удалена запись с номером [{_idToDelete}]\n\n"); };
                    continue;
                }

                // get operand 2 or quit if "exit" or display log if "log" or delete from log if "del ..."              
                View.Render(MessageTypesEnum.MessageTypes.Operand, ($"Введите второй операнд:\t\t"));
                consoleOp2 = Console.ReadLine();
                if (String.Equals(consoleOp2, Commands.EXIT, StringComparison.OrdinalIgnoreCase)) { DisplayExitMessage(); break; }
                if (String.Equals(consoleOp2, Commands.LOG, StringComparison.OrdinalIgnoreCase)) { DisplayLog(); continue; }
                if (consoleOp2.StartsWith(Commands.LOG_ID, StringComparison.OrdinalIgnoreCase))
                {
                    string _idToDisplay = consoleOp2.Replace(Commands.LOG_ID, "").Trim();
                    if (!DisplayLogId(_idToDisplay))
                    { View.Render(MessageTypesEnum.MessageTypes.Warning, $"ОШИБКА! Запись с номером [{_idToDisplay}] отсутствует.\n\n"); }
                    continue;
                }
                if (consoleOp2.StartsWith(Commands.DEL, StringComparison.OrdinalIgnoreCase))
                {
                    string _idToDelete = consoleOp2.Replace(Commands.DEL, "").Trim();
                    if (LogController.DeleteFromLog(_idToDelete) == 0)
                    { View.Render(MessageTypesEnum.MessageTypes.Warning, $"ОШИБКА! Невозможно удалить запись с номером [{_idToDelete}]\n\n"); }
                    else { View.Render(MessageTypesEnum.MessageTypes.Default, $"Из журнала событий удалена запись с номером [{_idToDelete}]\n\n"); };
                    continue;
                }

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
                LogController.WriteToLog(model, consoleOp1, consoleOp, consoleOp2);
            }
         }

        // отдельный метод для упрощения записи
        static void DisplayExitMessage ()
        {
            View.Render(MessageTypesEnum.MessageTypes.Default, "...quitting...\n");
        }

        // метод для отображения записи из лога по ID через метод view 
        static bool DisplayLogId (string input)
        {
            if (!int.TryParse(input, out int id)) return false;

            using (var conn = new SqlConnection(Commands.CONNECTION_STRING))
            using (var command = new SqlCommand("LogViewId", conn))
            {
                conn.Open();
                command.Parameters.AddWithValue("@pID", id);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        View.Render(MessageTypesEnum.MessageTypes.Default, $"[Запись из журнала событий ID={id}]\n");
                        View.Render(MessageTypesEnum.MessageTypes.Default, $"ID: {dr[0]}\tДействие: {dr[1]}\tВремя: {dr[2]}\n\n");
                    }
                    return dr.HasRows;
                }
                catch
                {
                    return false;
                }
            }
        }

        // метод для отображения всего лога через метод view 
        static void DisplayLog()
        {
            using (var conn = new SqlConnection(Commands.CONNECTION_STRING))
            using (var command = new SqlCommand("LogView", conn))
            {
                conn.Open();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                View.Render(MessageTypesEnum.MessageTypes.Default, "[Журнал событий]\n");
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    View.Render(MessageTypesEnum.MessageTypes.Default, $"ID: {dr[0]}\tДействие: {dr[1]}\tВремя: {dr[2]}\n");
                }
                View.Render(MessageTypesEnum.MessageTypes.Default, "[Конец журнала событий]\n\n");
            }
        }
     }
}