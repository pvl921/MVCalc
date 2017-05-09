using BasicTests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCalc.Constants;
using MVCalc.Controllers;
using MVCalc.Models;

namespace BasicTests.UnitTests
{

    [TestClass]
    public class EvaluationControllerTests
    {
        // testing Sum method
        [TestMethod]
        public void ShouldSumTwoDoubles()
        {
            DataModel testModel = EvaluationController.Sum(OperandMock.Operand6_1, OperandMock.OperandMinus2_4);
            Assert.IsNotNull(testModel.Result);
            Assert.IsTrue(testModel.IsResultOk);
            Assert.AreEqual(ResultMock.ResultSum6_1AndMinus2_4, testModel.Result);
        }

        [TestMethod]
        public void SumShouldReturnWrongFormatMessage()
        {
            DataModel testModel = EvaluationController.Sum(OperandMock.OperandWrongFormat, OperandMock.OperandMinus2_4);
            Assert.IsNotNull(testModel.Result);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result,Messages.MSG_WRONG_OPERAND_FORMAT);
        }

        [TestMethod]
        public void SumShouldReturnOperandOverflowMessage()
        {
            DataModel testModel = EvaluationController.Sum(OperandMock.OperandTooBig, OperandMock.OperandMinus2_4);
            Assert.IsNotNull(testModel.Result);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, Messages.MSG_OVERFLOW_OPERAND);
        }

        // testing Subtract method
        [TestMethod]
        public void ShouldSubtractTwoDoubles()
        {
            DataModel testModel = EvaluationController.Subtract(OperandMock.Operand6_1, OperandMock.OperandMinus2_4);
            Assert.IsNotNull(testModel.Result);
            Assert.IsTrue(testModel.IsResultOk);
            Assert.AreEqual(ResultMock.ResultSubtract6_1ByMinus2_4, testModel.Result);
        }

        [TestMethod]
        public void SubtractShouldReturnWrongFormatMessage()
        {
            DataModel testModel = EvaluationController.Subtract(OperandMock.OperandWrongFormat, OperandMock.OperandMinus2_4);
            Assert.IsNotNull(testModel.Result);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, Messages.MSG_WRONG_OPERAND_FORMAT);
        }

        [TestMethod]
        public void SubtractShouldReturnOperandOverflowMessage()
        {
            DataModel testModel = EvaluationController.Subtract(OperandMock.OperandTooBig, OperandMock.OperandMinus2_4);
            Assert.IsNotNull(testModel.Result);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, Messages.MSG_OVERFLOW_OPERAND);
        }

        // testing Multiply method
        [TestMethod]
        public void ShouldMultiplyTwoDoubles()
        {
            DataModel testModel = EvaluationController.Multiply(OperandMock.Operand6_1, OperandMock.OperandMinus2_4);
            Assert.IsNotNull(testModel.Result);
            Assert.IsTrue(testModel.IsResultOk);
            Assert.AreEqual(ResultMock.ResultMultiply6_1ByMinus2_4, testModel.Result);
        }

        [TestMethod]
        public void MultiplyShouldReturnWrongFormatMessage()
        {
            DataModel testModel = EvaluationController.Multiply(OperandMock.OperandWrongFormat, OperandMock.OperandMinus2_4);
            Assert.IsNotNull(testModel.Result);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, Messages.MSG_WRONG_OPERAND_FORMAT);
        }

        [TestMethod]
        public void MultiplyShouldReturnOperandOverflowMessage()
        {
            DataModel testModel = EvaluationController.Multiply(OperandMock.OperandTooBig, OperandMock.OperandMinus2_4);
            Assert.IsNotNull(testModel.Result);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, Messages.MSG_OVERFLOW_OPERAND);
        }

        // testing Divide method
        [TestMethod]
        public void ShouldDivideTwoDoubles()
        {
            DataModel testModel = EvaluationController.Divide(OperandMock.Operand6_1, OperandMock.OperandMinus2_4);
            Assert.IsNotNull(testModel.Result);
            Assert.IsTrue(testModel.IsResultOk);
            Assert.AreEqual(ResultMock.ResultDivide6_1ByMinus2_4, testModel.Result);
        }

        [TestMethod]
        public void DivideShouldReturnWrongFormatMessage()
        {
            DataModel testModel = EvaluationController.Divide(OperandMock.OperandWrongFormat, OperandMock.OperandMinus2_4);
            Assert.IsNotNull(testModel.Result);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, Messages.MSG_WRONG_OPERAND_FORMAT);
        }

        [TestMethod]
        public void DivideShouldReturnOperandOverflowMessage()
        {
            DataModel testModel = EvaluationController.Divide(OperandMock.OperandTooBig, OperandMock.OperandMinus2_4);
            Assert.IsNotNull(testModel.Result);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, Messages.MSG_OVERFLOW_OPERAND);
        }

        [TestMethod]
        public void DivideShouldReturnInfinityWhenDivideByZero()
        {
            DataModel testModel = EvaluationController.Divide(OperandMock.Operand6_1, OperandMock.Operand0);
            Assert.IsNotNull(testModel.Result);
            Assert.IsTrue(testModel.IsResultOk);
            Assert.AreEqual(ResultMock.ResultDivide6_1By0, testModel.Result);
        }

        // testing Power method
        [TestMethod]
        public void ShouldPowerTwoDoubles()
        {
            DataModel testModel = EvaluationController.Power(OperandMock.Operand6_1, OperandMock.OperandMinus2_4);
            Assert.IsNotNull(testModel.Result);
            Assert.IsTrue(testModel.IsResultOk);
            Assert.AreEqual(ResultMock.ResultPower6_1ByMinus2_4, testModel.Result);
        }

        [TestMethod]
        public void PowerShouldReturnWrongFormatMessage()
        {
            DataModel testModel = EvaluationController.Power(OperandMock.OperandWrongFormat, OperandMock.OperandMinus2_4);
            Assert.IsNotNull(testModel.Result);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, Messages.MSG_WRONG_OPERAND_FORMAT);
        }

        [TestMethod]
        public void PowerShouldReturnOperandOverflowMessage()
        {
            DataModel testModel = EvaluationController.Power(OperandMock.OperandTooBig, OperandMock.OperandMinus2_4);
            Assert.IsNotNull(testModel.Result);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, Messages.MSG_OVERFLOW_OPERAND);
        }

        [TestMethod]
        public void PowerShouldReturnInfinityWhenResultOverflow()
        {
            DataModel testModel = EvaluationController.Power(OperandMock.Operand1E308, OperandMock.Operand6_1);
            Assert.IsNotNull(testModel.Result);
            Assert.IsTrue(testModel.IsResultOk);
            Assert.AreEqual(ResultMock.ResultPower1e308By6_1, testModel.Result);
        }

        [TestMethod]
        public void PowerShouldReturnUndefinedMessageWhenResultIsComplexNumber()
        {
            DataModel testModel = EvaluationController.Power(OperandMock.OperandMinus2_4, OperandMock.OperandMinus0_4);
            Assert.IsNotNull(testModel.Result);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, Messages.MSG_UNDEFINED_RESULT);
        }


        // testing method for processing unknown operators  
        [TestMethod]
        public void WhenUnknownOperatorShouldReturnUndefinedOperatorMessage()
        {
            DataModel testModel = EvaluationController.Undefined(OperatorMock.OperatorDoublePlus);
            Assert.IsNotNull(testModel.Result);
            Assert.IsFalse(testModel.IsResultOk);
            StringAssert.Contains(testModel.Result, Messages.MSG_WRONG_OPERATOR);
        }

    }
}
