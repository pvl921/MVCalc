using System;
using System.Text;
using MVCalc.Enums;

namespace MVCalc.Views
{
    class View
    {
        ///<summary>
        ///Отображает переданное текстовое сообщение на консоли. Цвет текста определяется типом сообщения. 
        ///</summary> 
        public static void Render(MessageTypesEnum.MessageTypes messageType, string message) // тип параметра int заменил на соответствующий enum
        {
            switch (messageType)
            {
                case MessageTypesEnum.MessageTypes.Operand:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case MessageTypesEnum.MessageTypes.Operator:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case MessageTypesEnum.MessageTypes.Result:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case MessageTypesEnum.MessageTypes.Warning:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
            Console.OutputEncoding=Encoding.Unicode;
            Console.Write(message);           
        }
    }
}
