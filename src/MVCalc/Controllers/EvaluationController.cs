using System;
using MVCalc.Models;

namespace MVCalc.Controllers
{
    class EvaluationController
    {
        // Разделил операции по отдельным методам.
        // Исключения разных типов обрабатываются по отдельности.

        ///<summary>
        ///Вычисляет сумму двух операндов. 
        ///</summary>
        public static DataModel Sum(string op1, string op2)
        {
            string result;
            double resultDouble;
            bool isResultOk = false;
            DataModel model = new DataModel();
            try
            {
                resultDouble = (double.Parse(op1) + double.Parse(op2));
                result = double.IsNaN(resultDouble) ? "Результат операции неопределен." : resultDouble.ToString();
                isResultOk = !double.IsNaN(resultDouble);
            }
            catch (FormatException)
            { result = "Неверный формат операнда."; }
            catch (OverflowException)
            { result = "Значение операнда выходит за допустимые пределы."; }
            catch (Exception ex)
            { result = "Неизвестная ошибка: " + ex.Message; }
            model.Result = result;
            model.IsResultOk = isResultOk;
            return model;
        }

        ///<summary>
        ///Вычисляет разность двух операндов. 
        ///</summary>
        public static DataModel Subtract(string op1, string op2)
        {
            string result;
            double resultDouble;
            bool isResultOk = false;
            DataModel model = new DataModel();
            try
            {
                resultDouble = (double.Parse(op1) - double.Parse(op2));
                result = double.IsNaN(resultDouble) ? "Результат операции неопределен." : resultDouble.ToString();
                isResultOk = !double.IsNaN(resultDouble);
            }
            catch (FormatException)
            { result = "Неверный формат операнда."; }
            catch (OverflowException)
            { result = "Значение операнда выходит за допустимые пределы."; }
            catch (Exception ex)
            { result = "Неизвестная ошибка: " + ex.Message; }
            model.Result = result;
            model.IsResultOk = isResultOk;
            return model;
        }

        ///<summary>
        ///Вычисляет произведение двух операндов. 
        ///</summary>
        public static DataModel Multiply(string op1, string op2)
        {
            string result;
            double resultDouble;
            bool isResultOk = false;
            DataModel model = new DataModel();
            try
            {
                resultDouble = (double.Parse(op1) * double.Parse(op2));
                result = double.IsNaN(resultDouble) ? "Результат операции неопределен." : resultDouble.ToString();
                isResultOk = !double.IsNaN(resultDouble);
            }
            catch (FormatException)
            { result = "Неверный формат операнда."; }
            catch (OverflowException)
            { result = "Значение операнда выходит за допустимые пределы."; }
            catch (Exception ex)
            { result = "Неизвестная ошибка: " + ex.Message; }
            model.Result = result;
            model.IsResultOk = isResultOk;
            return model;
        }

        ///<summary>
        ///Вычисляет частное двух операндов. 
        ///</summary>
        public static DataModel Divide(string op1, string op2)
        {
            string result;
            double resultDouble;
            bool isResultOk = false;
            DataModel model = new DataModel();
            try
            {
                resultDouble = (double.Parse(op1) / double.Parse(op2));
                result = double.IsNaN(resultDouble) ? "Результат операции неопределен." : resultDouble.ToString();
                isResultOk = !double.IsNaN(resultDouble);
            }
            catch (FormatException)
            { result = "Неверный формат операнда."; }
            catch (OverflowException)
            { result = "Значение операнда выходит за допустимые пределы."; }
            catch (Exception ex)
            { result = "Неизвестная ошибка: " + ex.Message; }
            model.Result = result;
            model.IsResultOk = isResultOk;
            return model;
        }

        ///<summary>
        ///Вычисляет возведение в степень первого операнда. Второй операнд определяет показатель степени.
        ///</summary>
        public static DataModel Power(string op1, string op2)
        {
            string result;
            double resultDouble;
            bool isResultOk = false;
            DataModel model = new DataModel();
            try
            {
                resultDouble = Math.Pow(double.Parse(op1), double.Parse(op2)); 
                result = double.IsNaN(resultDouble) ? "Результат операции неопределен." : resultDouble.ToString();
                isResultOk = !double.IsNaN(resultDouble);
            }
            catch (FormatException)
            { result = "Неверный формат операнда."; }
            catch (OverflowException)
            { result = "Значение операнда выходит за допустимые пределы."; }
            catch (Exception ex)
            { result = "Неизвестная ошибка: " + ex.Message; }
            model.Result = result;
            model.IsResultOk = isResultOk;
            return model;
        }

        ///<summary>
        ///Определяет результат при неизвестном символе оператора.
        ///</summary>
        public static DataModel Undefined(string op)
        {
            // присваиваем значения сразу при инициализации объекта
            DataModel model = new DataModel
            {
                Result = $"Неизвестный символ оператора ({op}).\n",
                IsResultOk = false
            };
            return model;
        }
    }
}
