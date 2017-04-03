using System;
using System.Text;
using System.Collections.Generic;

namespace MVCalc
{
    public class Program
    {
        //TODO Общее замечание: немного не соблюдена концепция MVC - метод контроллера должен возвращать модель, а уже Listner должен передавать ее во View. Иначе контроллеры будет сложно тестировать.
        // Я быхотел что-то типа такого (ну и учеть плюшки типа прерывания ввода - выход из программы, приветственное сообщение и т.п.
        //static void l()
        //{
        //    while (true)
        //    {
        //        var op1 = Console.ReadLine();
        //        var op2 = Console.ReadLine();
        //        var op  = Console.ReadLine();
        //
        //        try
        //        {
        //            var result = Controller.Evaluate(op1, op2, op);
        //            View.Render(result);
        //        }
        //        catch (Exception e)
        //        {
        //            View.Render(e);
        //        }
        //    }
        //    
        //}


        ///<summary>
        ///Преобразует строку в численный тип (double).
        /// </summary> 
        static (bool, double) TryParseOperand(string stringInput) //TODO Не понял, зачем ты возвращаешь parsingSuccess - если операция не выполнилась, то будет exception. Не понял зачем вообще этот метод, если есть Double.TryParse()
        {
            bool parsingSuccess = true;
            double parsedValue = double.NaN;

            try
            {
                parsedValue = double.Parse(stringInput);
            }
            catch (FormatException ex) //TODO переменная ex в данном случае не нужна
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
        static void Main(string[] args) //TODO Даже в нашей небольшой коммнде нет принятого решения по поводу писать var или типы/классы, но ИМХО var лучше, т.к. позволяет более быстро в дальнейшем рефакторить код.
        {
            //TODO Почему ты эти переменные объявляешь все вне while, хотя они используются только там?
            char operator_symbol; //TODO В C# принято использовать camelCase для локальных переменных, ALL_UPPER - для констант, _camalCase - для приватных переменных и PascalCase - для публичных и внутренних методов и свойств
            string consoleInput;
            double operand1, operand2, result;
            const string exit = "exit"; //TODO Это должно быть константой
            bool operand1OK, operand2OK, operatorOK, resultOK; //TODO Приняо использовать приставки Is/Are/Has/Allow для bool переменных
            OperatorDelegate SelectedTransformation;
            bool firstTime = true;
            Data data = new Data(); //TODO Модель должна создаватсья в контроллере - Listner, которым является Program.cs ничего не знает про модель

            while (true)
            {
                operand1OK = false;
                operand2OK = false;
                operatorOK = false;
                operator_symbol = ' ';

                // get operand 1 or quit if "exit"
                DisplayController.GetInput(firstTime, 0); //TODO Для отображения приветственного сообщения лучше сделать отдельный метод в контроллере и вынести его вообще за пределы цикла
                if (firstTime) firstTime = false;
                consoleInput = Console.ReadLine().Replace(".", ","); //TODO Это бует работать только на ПК с определенной локалью. Если ты поменяешь региональные настройки, все сломается. см. CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
                if (consoleInput.ToLower() == exit) { DisplayController.Quit(); break; }
                try
                {
                    (operand1OK, operand1) = TryParseOperand(consoleInput);
                }
                catch (Exception ex)
                {
                    DisplayController.ParseException(ex.Message); continue;
                }

                // get operator or quit if "exit"
                DisplayController.GetInput(firstTime, 1);
                consoleInput = Console.ReadLine();
                if (consoleInput.ToLower() == exit) { DisplayController.Quit(); break; };
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
                DisplayController.GetInput(firstTime, 0, "второй");
                consoleInput = Console.ReadLine().Replace(".", ",");
                if (consoleInput.ToLower() == exit) { DisplayController.Quit(); break; };
                try
                {
                    (operand2OK, operand2) = TryParseOperand(consoleInput);
                }
                catch (Exception ex)
                {
                    DisplayController.ParseException(ex.Message); continue;
                }                

                // apply selected operator to operands
                if (operand1OK && operand2OK && operatorOK)
                {
                    SelectedTransformation = TransformationService.AvailableOperators[operator_symbol];
                    result = SelectedTransformation(operand1, operand2);
                    resultOK = (double.IsNaN(result)) ? false : true; //TODO Так короче (!double.IsNaN(result))
                }
                else
                {
                    result = double.NaN;
                    resultOK = false;
                }

                // update Model fields
                DisplayController.UpdateModel(data, result, resultOK);

                // bring the result or error message to the user
                DisplayController.ProcessResult(data);
                }
         }
     }
}