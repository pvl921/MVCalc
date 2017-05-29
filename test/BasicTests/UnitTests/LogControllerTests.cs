using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCalc.Controllers;
using MVCalc.Models;
using BasicTests.Mock;

namespace BasicTests.UnitTests
{
    [TestClass]
    public class LogControllerTests
    {
        // testing writing to and reading from the database 
        [TestMethod]
        public void ShouldWriteAndReadValuesFromLog()
        {
            var randomizer = new Random();
            // тестовая строка для записи в БД, состоит из слова "Test" и случайного числа 
            var testString = $"Test" + randomizer.Next().ToString();
            var testModel = new DataModel { IsResultOk = true, Result = testString };
            var currentTime = DateTimeOffset.Now;

            // запись тестовой строки в БД
            int id = LogController.Add(testModel, OperandMock.Operand6_1, 
                OperatorMock.OperatorDoublePlus, OperandMock.OperandMinus0_4);

            // чтение тестовой строки из БД
            var readFromDb = LogController.Get(id);

            // проверка что прочитанное совпадает с записанным
            StringAssert.Contains(readFromDb.ResultLog, testString);
            StringAssert.Contains(readFromDb.ResultLog, OperandMock.Operand6_1);
            StringAssert.Contains(readFromDb.ResultLog, OperatorMock.OperatorDoublePlus);
            StringAssert.Contains(readFromDb.ResultLog, OperandMock.OperandMinus0_4);
            // проверяем совпадение времени с точность до 1 мс (10 000 тиков)
            Assert.AreEqual(currentTime.Ticks, readFromDb.DateTimeLog.Ticks, 10000);

            // удаление тестовой строки из БД
            var deletedRows = LogController.Delete(id);
            
            // проверка что из БД удалили одну строку
            Assert.AreEqual(1, deletedRows);
        }

    }
}
