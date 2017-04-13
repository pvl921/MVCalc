using System;
using System.Text;


namespace MVCalc.Views
{
    //TODO Это не Messages, а MessageTypes
    enum Messages {Default, Operand, Operator, Result, Warning}; //TODO В корне создай папку Enums и в нее все enum'ы в виде отдельный файлов


    class View
    {
        ///<summary>
        ///Отображает переданное текстовое сообщение на консоли. Цвет текста определяется типом сообщения. 
        ///</summary> 
        public static void Render(int messageType, string message) //TODO Почему параметр messageTypeInt, а не Messages messageTypeInt???
        {
            switch ((Messages)messageType)
            {
                case Messages.Operand:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case Messages.Operator:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case Messages.Result:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Messages.Warning:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case Messages.Default: //TODO это лишнее
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
            Console.OutputEncoding=Encoding.Unicode;
            Console.Write(message);           
        }
    }
}
