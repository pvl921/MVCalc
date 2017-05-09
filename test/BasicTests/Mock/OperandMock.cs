namespace BasicTests.Mock
{
    public static class OperandMock
    {
        public static string Operand6_1 = 6.1.ToString();
        public static string OperandMinus2_4 = (-2.4).ToString();
        public static string OperandMinus0_4 = (-0.4).ToString();
        public static string OperandWrongFormat = "+";
        public static string Operand0 = 0.0.ToString();
        public static string OperandTooBig = double.MaxValue.ToString() + "0";
        public static string Operand1E308 = 1e308.ToString();
    }     
}
