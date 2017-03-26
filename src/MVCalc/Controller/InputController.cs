namespace MVCalc
{
    enum InputTypes {Operand, Operator};

    ///<summary>
    ///Формирует текстовые сообщения для ввода данных и пояснения для пользователя.
    ///</summary>
    class InputController
    {
        public static void GetInput(bool firstTime, int inputType, string operandNumber = "первый")
        {
            if (firstTime)
            {
                View.Render(0, "Welcome to MVC Calculator.\nEnter first operand(x), then a math operator to be applied, and then the second operand(y).\nType \"Exit\" to quit the program.\n" +
                    "Available operators:\nx + y\nx - y\nx * y\nx / y\nx ^ y\n\n");
            };

            InputTypes _inputType = (InputTypes) inputType;
            switch (_inputType)
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
    }
}
