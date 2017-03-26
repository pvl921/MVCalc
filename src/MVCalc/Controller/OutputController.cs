namespace MVCalc
{
    class OutputController
    {
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
        public static void UpdateModel(Data data, double result, bool resultOK)
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
