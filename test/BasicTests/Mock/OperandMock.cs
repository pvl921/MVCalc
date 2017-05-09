namespace BasicTests.Mock
{
    public static class OperandMock
    {
        public static string operand_6_1 = 6.1.ToString();
        public static string operand_minus2_4 = (-2.4).ToString();
        public static string operand_minus0_4 = (-0.4).ToString();
        public static string operand_WrongFormat = "+";
        public static string operand_0 = 0.0.ToString();
        public static string operand_TooBig = double.MaxValue.ToString() + "0";
        public static string operand_1e308 = 1e308.ToString();
    }     
}
