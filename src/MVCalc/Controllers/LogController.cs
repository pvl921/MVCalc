using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using MVCalc.Constants;
using MVCalc.Models;

namespace MVCalc.Controllers
{
    public class LogController
    {
        ///<summary>
        ///Записывает операнды, результат вычислений и время операции в журнал событий. 
        ///</summary>
        public static int WriteToLog(DataModel model, string consoleOp1, string consoleOp, string consoleOp2)
        {
            var resultString = $"{model.IsResultOk}\t{consoleOp1}\t{consoleOp}\t{consoleOp2}\t{model.Result}";
            using (var conn = new SqlConnection(Commands.CONNECTION_STRING))
            using (var command = new SqlCommand("LogInsert", conn))
            {
                conn.Open();
                command.Parameters.AddWithValue("@pResult", resultString);
                command.Parameters.AddWithValue("@pDate", DateTimeOffset.Now);
                command.CommandType = CommandType.StoredProcedure;
                return command.ExecuteNonQuery();
            }
        }

        ///<summary>
        ///Удаляет запись из журнала событий по номеру записи. 
        ///</summary>
        public static int DeleteFromLog(string input)
        {
            if (!int.TryParse(input, out int id)) return 0;

            try
            {
                using (var conn = new SqlConnection(Commands.CONNECTION_STRING))
                using (var command = new SqlCommand("LogDelete", conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@pID",id);
                    command.CommandType = CommandType.StoredProcedure;
                    return command.ExecuteNonQuery();
                }
            }
            catch 
            {
                return 0;
            }
        }
    }
}
