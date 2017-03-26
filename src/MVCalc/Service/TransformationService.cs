using System;
using System.Collections.Generic;

namespace MVCalc
{
    public delegate double OperatorDelegate(double x, double y);

    ///<summary>
    ///Содержит набор математических операций над передаваемыми операндами.
    /// </summary>
    class TransformationService
    {

        ///<summary>
        ///Определяет соответствие методов символам математических операций.
        /// </summary>
        public static Dictionary<char, OperatorDelegate> AvailableOperators = new Dictionary<char, OperatorDelegate>
            {
                { '+', new OperatorDelegate(Sum) },
                { '-', new OperatorDelegate(Subtract) },
                { '*', new OperatorDelegate(Multiply) },
                { '/', new OperatorDelegate(Divide) },
                { '^', new OperatorDelegate(Power) }
            };

        ///<summary>
        ///Вычисляет сумму операндов.
        /// </summary>
        public static double Sum(double op1, double op2)
        {
            return op1 + op2;
        }

        ///<summary>
        ///Вычисляет разность операндов.
        /// </summary>
        public static double Subtract(double op1, double op2)
        {
            return op1 - op2;
        }

        ///<summary>
        ///Вычисляет произведение операндов.
        /// </summary>
        public static double Multiply(double op1, double op2)
        {
            return op1 * op2;
        }

        ///<summary>
        ///Вычисляет частное операндов.
        /// </summary>
        public static double Divide(double op1, double op2)
        {
            return op1 / op2;
        }

        ///<summary>
        ///Вычисляет возведение в степень первого операнда. Показатель степени равен второму операнду.
        /// </summary>
        public static double Power(double op1, double op2)
        {
            return Math.Pow(op1, op2);
        }

    }
}
