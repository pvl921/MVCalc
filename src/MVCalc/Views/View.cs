using System;
using System.Text;


namespace MVCalc.Views
{
    enum Messages {Default, Operand, Operator, Result, Warning}; 

    class View
    {
        ///<summary>
        ///Отображает переданное текстовое сообщение на консоли. Цвет текста определяется типом сообщения. 
        ///</summary> 
        public static void Render(int messageType, string message) //TODO Параметры - camalCase
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
                case Messages.Default:
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
            Console.OutputEncoding=Encoding.Unicode;
            Console.Write(message);           
        }
    }
}
