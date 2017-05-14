using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCalc.Controllers;
using MVCalc.Constants;
using System.Data.SqlClient;
using System.Data;

namespace BasicTests.UnitTests
{
    [TestClass]
    public class LogControllerTests
    {
        // testing writing to and reading from the database 
        [TestMethod]
        public void ShouldWriteAndReadValuesFromLog()
        {
            var insertedRows = 0;
            var randomizer = new Random();
            // тестовая строка для записи в БД, состоит из случайного числа и текущей даты
            var testString = randomizer.Next().ToString();
            var testDateTime = DateTimeOffset.Now;
            // запись тестовой строки в БД
            using (var conn = new SqlConnection(Commands.CONNECTION_STRING))
            using (var command = new SqlCommand("LogInsert", conn))
            {
                conn.Open();
                command.Parameters.AddWithValue("@pResult", testString);
                command.Parameters.AddWithValue("@pDate", testDateTime);
                command.CommandType = CommandType.StoredProcedure;
                insertedRows = command.ExecuteNonQuery();
            }

            // проверка что в БД записана одна строка
            Assert.AreEqual(1,insertedRows);

            // чтение тестовой строки из БД
            var readFromDB = new List<string>();
            using (var conn = new SqlConnection(Commands.CONNECTION_STRING))
            using (var command = new SqlCommand($"SELECT * FROM [TEST] WHERE Result = '{testString}'", conn))
            {
                conn.Open();
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    readFromDB.Add($"{dr[0]}_{dr[1]}_{dr[2]}");
                }
            }

            // проверка что из БД прочитана одна строка
            Assert.AreEqual(1, readFromDB.Count);

            // проверка что прочитанное совпадает с записанным
            StringAssert.Contains(readFromDB[0], string.Concat(testString,"_",testDateTime.ToString()));

            // проверка что id действительно есть целое число
            bool idIsInt = int.TryParse(readFromDB[0].Split('_')[0], out int id);
            Assert.IsTrue(idIsInt);

            // удаление тестовой строки из БД
            var deletedRows = 0;
            using (var conn = new SqlConnection(Commands.CONNECTION_STRING))
            using (var command = new SqlCommand("LogDelete", conn))
            {
                conn.Open();
                command.Parameters.AddWithValue("@pID", id);
                command.CommandType = CommandType.StoredProcedure;
                deletedRows = command.ExecuteNonQuery();
            }
            
            // проверка что из БД удалили одну строку
            Assert.AreEqual(1, deletedRows);
        }

    }
}
