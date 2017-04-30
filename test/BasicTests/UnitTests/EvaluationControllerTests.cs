using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCalc.Models;
using MVCalc.Controllers;
using BasicTests.Mock;

namespace BasicTests.UnitTests
{
    
    [TestClass]
    public class EvaluationControllerTests
    {
        // testing Sum method
        [TestMethod]
        public async Task ShouldSumTwoDoubles()
        {
            DataModel testModel;
            testModel = EvaluationController.Sum(OperandMock.operand_6_1, OperandMock.operand_minus2_4);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsTrue(testModel.IsResultOk);
            Assert.AreEqual(ResultMock.resultSum_6_1_and_minus2_4, actualResult);
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task SumShouldReturnWrongFormatMessage()
        {
            DataModel testModel;
            testModel = EvaluationController.Sum(OperandMock.operand_WrongFormat, OperandMock.operand_minus2_4);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result,EvaluationController.MSG_WRONG_OPERAND_FORMAT);
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task SumShouldReturnOperandOverflowMessage()
        {
            DataModel testModel;
            testModel = EvaluationController.Sum(OperandMock.operand_TooBig, OperandMock.operand_minus2_4);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, EvaluationController.MSG_OVERFLOW_OPERAND);
            await Task.CompletedTask;
        }

        // testing Subtract method
        [TestMethod]
        public async Task ShouldSubtractTwoDoubles()
        {
            DataModel testModel;
            testModel = EvaluationController.Subtract(OperandMock.operand_6_1, OperandMock.operand_minus2_4);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsTrue(testModel.IsResultOk);
            Assert.AreEqual(ResultMock.resultSubtract_6_1_by_minus2_4, actualResult);
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task SubtractShouldReturnWrongFormatMessage()
        {
            DataModel testModel;
            testModel = EvaluationController.Subtract(OperandMock.operand_WrongFormat, OperandMock.operand_minus2_4);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, EvaluationController.MSG_WRONG_OPERAND_FORMAT);
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task SubtractShouldReturnOperandOverflowMessage()
        {
            DataModel testModel;
            testModel = EvaluationController.Subtract(OperandMock.operand_TooBig, OperandMock.operand_minus2_4);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, EvaluationController.MSG_OVERFLOW_OPERAND);
            await Task.CompletedTask;
        }

        // testing Multiply method
        [TestMethod]
        public async Task ShouldMultiplyTwoDoubles()
        {
            DataModel testModel;
            testModel = EvaluationController.Multiply(OperandMock.operand_6_1, OperandMock.operand_minus2_4);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsTrue(testModel.IsResultOk);
            Assert.AreEqual(ResultMock.resultMultiply_6_1_by_minus2_4, actualResult);
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task MultiplyShouldReturnWrongFormatMessage()
        {
            DataModel testModel;
            testModel = EvaluationController.Multiply(OperandMock.operand_WrongFormat, OperandMock.operand_minus2_4);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, EvaluationController.MSG_WRONG_OPERAND_FORMAT);
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task MultiplyShouldReturnOperandOverflowMessage()
        {
            DataModel testModel;
            testModel = EvaluationController.Multiply(OperandMock.operand_TooBig, OperandMock.operand_minus2_4);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, EvaluationController.MSG_OVERFLOW_OPERAND);
            await Task.CompletedTask;
        }

        // testing Divide method
        [TestMethod]
        public async Task ShouldDivideTwoDoubles()
        {
            DataModel testModel;
            testModel = EvaluationController.Divide(OperandMock.operand_6_1, OperandMock.operand_minus2_4);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsTrue(testModel.IsResultOk);
            Assert.AreEqual(ResultMock.resultDivide_6_1_by_minus2_4, actualResult);
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task DivideShouldReturnWrongFormatMessage()
        {
            DataModel testModel;
            testModel = EvaluationController.Divide(OperandMock.operand_WrongFormat, OperandMock.operand_minus2_4);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, EvaluationController.MSG_WRONG_OPERAND_FORMAT);
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task DivideShouldReturnOperandOverflowMessage()
        {
            DataModel testModel;
            testModel = EvaluationController.Divide(OperandMock.operand_TooBig, OperandMock.operand_minus2_4);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, EvaluationController.MSG_OVERFLOW_OPERAND);
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task DivideShouldReturnInfinityWhenDivideByZero()
        {
            DataModel testModel;
            testModel = EvaluationController.Divide(OperandMock.operand_6_1, OperandMock.operand_0);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsTrue(testModel.IsResultOk);
            Assert.AreEqual(ResultMock.resultDivide_6_1_by_0, actualResult);
            await Task.CompletedTask;
        }

        // testing Power method
        [TestMethod]
        public async Task ShouldPowerTwoDoubles()
        {
            DataModel testModel;
            testModel = EvaluationController.Power(OperandMock.operand_6_1, OperandMock.operand_minus2_4);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsTrue(testModel.IsResultOk);
            Assert.AreEqual(ResultMock.resultPower_6_1_by_minus2_4, actualResult);
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task PowerShouldReturnWrongFormatMessage()
        {
            DataModel testModel;
            testModel = EvaluationController.Power(OperandMock.operand_WrongFormat, OperandMock.operand_minus2_4);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, EvaluationController.MSG_WRONG_OPERAND_FORMAT);
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task PowerShouldReturnOperandOverflowMessage()
        {
            DataModel testModel;
            testModel = EvaluationController.Power(OperandMock.operand_TooBig, OperandMock.operand_minus2_4);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, EvaluationController.MSG_OVERFLOW_OPERAND);
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task PowerShouldReturnInfinityWhenResultOverflow()
        {
            DataModel testModel;
            testModel = EvaluationController.Power(OperandMock.operand_1e308, OperandMock.operand_6_1);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsTrue(testModel.IsResultOk);
            Assert.AreEqual(ResultMock.resultPower_1e308_by_6_1, actualResult);
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task PowerShouldReturnUndefinedMessageWhenResultIsComplexNumber()
        {
            DataModel testModel;
            testModel = EvaluationController.Power(OperandMock.operand_minus2_4, OperandMock.operand_minus0_4);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, EvaluationController.MSG_UNDEFINED_RESULT);
            await Task.CompletedTask;
        }


        // testing method for processing unknown operators  
        [TestMethod]
        public async Task WhenUnknownOperatorShouldReturnUndefinedOperatorMessage()
        {
            DataModel testModel;
            testModel = EvaluationController.Undefined(OperatorMock.operatorDoublePlus);
            string actualResult = testModel.Result;
            Assert.IsNotNull(testModel);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, EvaluationController.MSG_WRONG_OPERATOR);
            await Task.CompletedTask;
        }

    }
}
