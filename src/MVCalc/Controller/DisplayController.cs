namespace MVCalc //TODO MVCalc.Controllers
{
    class DisplayController
    {
        enum InputTypes { Operand, Operator };

        ///<summary>
        ///Формирует текстовые сообщения для ввода данных и пояснения для пользователя.
        ///</summary>
        public static void GetInput(bool firstTime, int inputType, string operandNumber = "первый")
        {
            if (firstTime)
            {
                View.Render(0, "Welcome to MVC Calculator.\nEnter first operand(x), then a math operator to be applied, and then the second operand(y).\nType \"Exit\" to quit the program.\n" +
                    "Available operators:\nx + y\nx - y\nx * y\nx / y\nx ^ y\n\n");
            };

            InputTypes _inputType = (InputTypes)inputType; //TODO локальные переменные - camalCase
            switch (_inputType) //TODO Будь ленивым - так короче switch ((InputTypes)_inputType)
            {
                case InputTypes.Operand:
                    View.Render(1, ($"Введите {operandNumber} операнд:\t\t"));
                    break;
                case InputTypes.Operator:
                    View.Render(2, ($"Введите оператор:\t\t"));
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
            View.Render(4, $"ОШИБКА!\t{message}\n\n");
        }

        ///<summary>
        ///Передает данные в модель.
        /// </summary>
        public static void UpdateModel(Data data, double result, bool resultOK) //TODO Мы пока остановились на том, что все абривиатуры, кроме ID и должны писаться в camalCase  -  resultOk
        {
            data.Result = result;
            data.ResultOK = resultOK;
        }

        ///<summary>
        ///Формирует текстовые сообщения для вывода результата.
        /// </summary>
        public static void ProcessResult(Data data)
        {
            if (!data.ResultOK)
            {
                View.Render(4, "ОШИБКА! Недопустимый символ оператора или несовместимое значение операнда. Выражение не вычислено.\n\n");
                return;
            }
            View.Render(3, $"Результат:\t\t\t{data.Result}\n\n");
        }

        ///<summary>
        ///Формирует текстовое сообщение о завершении программы.
        /// </summary>
        public static void Quit()
        {
            View.Render(0, "...quitting...\n");
        }

    }
}
