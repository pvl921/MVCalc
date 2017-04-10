using System;

namespace MVCalc
{
    // Enum не позволяет перечислять символы операций, поэтому преобразование символа с консоли в Enum через TryParse не делаем.
    enum Operations { Sum, Subtract, Multiply, Divide, Power };

    public class Program
    {
        // Не вполне получилось сделать именно так - исключения обрабатываются не в Progman.cs, а в контроллере. Следуя принципу что View вызывется только из контроллера.
        // Неправильный символ оператора обратывается не через исключение, а через default в switch(consoleOp).


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
        //            var operation = Enum.TryParse(op, typeof(Operations));
        //
        //            Model model;
        //            switch (operation) 
        //            {
        //                case Operations.Add:
        //                    model = Controller.Add(op1, op2);
        //                    break;
        //                case Operations.Subtract:
        //                    model = Controller.Subtract(op1, op2);
        //                    break;
        //                default:
        //                    throw new UnavailableOperation(op);
        //            }
        //            View.Render(model);
        //        }
        //        catch (Exception e)
        //        {
        //            View.Render(e);
        //        }
        //    }
        //    
        //}

        ///<summary>
        ///Программа-калькулятор с использованием модулей контроллера (controller), модели (model) и отображения (view).
        /// </summary> 
        static void Main() 
        {
            const string EXIT = "exit"; //константа в CAPS
            

            // Создание объекта модели перенесено в контролле EvaluationController. В Progman.cs используется только объявление переменной типа Model перед switch(consoleOp).
            // Замена ',' на '.' при вводе удалено. При вводе чисел в английской раскладке клавиатуры нужно вводить разделить дробной части в соответствии с локальными настройками операционной системы.
            // Делегаты больше не используются. Выбор операции и высов соответствущего метода осуществляется в switch(consoleOp) в Progman.cs и switch(op) в контроллере EvaluationСontroller.
            // Метод TryParseOperand удален, ошибки обрабатываются по исключениям.
            // Раньше был сервис TransformationService, содержащий набор мат.операций, теперь он оказался не нужен - операции выполяются в контроллере.

            // Приветствие вынесено в отдельный метод у контроллера. Правда, он ничего не возвращает, так же как и все остальные методы DisplayController.
            // Методы вычисления контроллера EvaluationController возвращают модель.

            Controllers.DisplayController.Welcome();

            while (true)
            {
            // Объявление локальных переменных перенесено внутрь цикла.

                string consoleOp1, consoleOp2, consoleOp;

                // get operand 1 or quit if "exit"
                Controllers.DisplayController.GetInput(0);
                consoleOp1 = Console.ReadLine();
                if (consoleOp1.ToLower() == EXIT) { Controllers.DisplayController.Quit(); break; }

                // get operator or quit if "exit"
                Controllers.DisplayController.GetInput(1);
                consoleOp = Console.ReadLine();
                if (consoleOp.ToLower() == EXIT) { Controllers.DisplayController.Quit(); break; };

                // get operand 2 or quit if "exit"               
                Controllers.DisplayController.GetInput(0, "второй");
                consoleOp2 = Console.ReadLine();
                if (consoleOp2.ToLower() == EXIT) { Controllers.DisplayController.Quit(); break; }
                
                // calculate the result and check for undefined operator
                Models.DataModel model;
                switch (consoleOp)
                    {
                        case "+":
                            model = Controllers.EvaluationController.Operation(consoleOp1, consoleOp2, Operations.Sum);
                            break;
                        case "-":
                            model = Controllers.EvaluationController.Operation(consoleOp1, consoleOp2, Operations.Subtract);
                            break;
                        case "*":
                            model = Controllers.EvaluationController.Operation(consoleOp1, consoleOp2, Operations.Multiply);
                            break;
                        case "/":
                            model = Controllers.EvaluationController.Operation(consoleOp1, consoleOp2,Operations.Divide);
                            break;
                        case "^":
                            model = Controllers.EvaluationController.Operation(consoleOp1, consoleOp2, Operations.Power);
                            break;
                        default:
                            model = Controllers.EvaluationController.Undefined(consoleOp);
                            break;
                    }

                // bring the result or error message to the user
                Controllers.DisplayController.ProcessResult(model);
                }
         }
     }
}