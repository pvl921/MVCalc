namespace MVCalc.Controllers
{
    class DisplayController
    {
        enum InputTypes { Operand, Operator };

        ///<summary>
        ///Формирует текстовые сообщения для ввода данных и пояснения для пользователя.
        ///</summary>
        public static void GetInput(int inputType, string operandNumber = "первый")
        {
            switch ((InputTypes)inputType) //TODO Будь ленивым - так короче switch ((InputTypes)_inputType)
            {
                case InputTypes.Operand:
                    Views.View.Render(1, ($"Введите {operandNumber} операнд:\t\t"));
                    break;
                case InputTypes.Operator:
                    Views.View.Render(2, ($"Введите оператор:\t\t"));
                    break;
                default:
                    break;
            }
        }
        
        ///<summary>
        ///Формирует текстовые сообщения об ошибках в типе данных.
        /// </summary>
        public static void ParseException(string message)
        {
            Views.View.Render(4, $"ОШИБКА!\t{message}\n\n");
        }

         ///<summary>
        ///Формирует текстовые сообщения для вывода результата.
        /// </summary>
        public static void ProcessResult(Models.DataModel model)
        {
            if (!model.ResultOk)
                Views.View.Render(4, $"ОШИБКА! {model.Result}\n\n");
            else
                Views.View.Render(3, $"Результат:\t\t\t{model.Result}\n\n");
        }

        ///<summary>
        ///Формирует приветственное сообщение.
        /// </summary>
        public static void Welcome()
        {
            Views.View.Render(0, "Welcome to MVC Calculator.\nEnter first operand(x), then a math operator to be applied, and then the second operand(y).\nType \"Exit\" to quit the program.\n" +
                                "Available operators:\nx + y\nx - y\nx * y\nx / y\nx ^ y\n\n");
        }

        ///<summary>
        ///Формирует текстовое сообщение о завершении программы.
        /// </summary>
        public static void Quit()
        {
            Views.View.Render(0, "...quitting...\n");
        }
    }
}
