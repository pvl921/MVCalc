using System;

namespace MVCalc.Controllers
{
    class EvaluationController
    {
        ///<summary>
        ///Вычисляет результат математической операции. Тип операции задается при вызове функции.
        ///</summary>
        public static Models.DataModel Operation(string op1, string op2, Operations op)
        {
            string result;
            double resultDouble;
            bool resultOk;
            Models.DataModel model = new Models.DataModel();
            try
            {
                switch (op)
                {
                    case Operations.Sum:
                        resultDouble = (double.Parse(op1) + double.Parse(op2));
                        break;
                    case Operations.Subtract:
                        resultDouble = (double.Parse(op1) - double.Parse(op2));
                        break;
                    case Operations.Multiply:
                        resultDouble = (double.Parse(op1) * double.Parse(op2));
                        break;
                    case Operations.Divide:
                        resultDouble = (double.Parse(op1) / double.Parse(op2));
                        break;
                    case Operations.Power:
                        resultDouble = Math.Pow(double.Parse(op1), double.Parse(op2));
                        break;
                    default:
                        resultDouble = double.NaN;
                        break;
                }
                result = double.IsNaN(resultDouble) ? "Результат операции неопределен." : resultDouble.ToString();
                resultOk = !double.IsNaN(resultDouble);
            }
            catch (Exception ex)
            {
                switch (ex.GetType().ToString())
                {
                    case "System.FormatException":
                        result = "Неверный формат операнда.";
                        break;
                    case "System.IndexOutOfRangeException":
                        result = "Неверный формат оператора.";
                        break;
                    default:
                        result = "Неизвестная ошибка: " + ex.Message;
                        break;
                }
                resultOk = false;
            }
            model.Result = result;
            model.ResultOk = resultOk;
            return model;
        }

        ///<summary>
        ///Определяет результат при неизвестном символе оператора.
        ///</summary>
        public static Models.DataModel Undefined(string op)
        {
            Models.DataModel model = new Models.DataModel();
            model.Result = $"Неизвестный символ оператора ({op}).\n";
            model.ResultOk = false;
            return model;           
        }
    }
}
