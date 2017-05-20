using System;

namespace MVCalc.Models
{
    ///<summary>
    ///Содержит структуру хранения данных в базе данных.
    ///</summary> 
    public class LogModel
    {
        public int ID { get; set; }
        public string ResultLog { get; set; }
        public DateTimeOffset DateTimeLog { get; set; }

        public LogModel(int id, string resultLog, DateTimeOffset dateTimeLog)
        {
            ID = id;
            ResultLog = resultLog;
            DateTimeLog = dateTimeLog;
        }
    }
}
