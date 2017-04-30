namespace BasicTests.Mock
{
    public static class ResultMock
    {
        public static string resultSum_6_1_and_minus2_4 = (6.1 + (-2.4)).ToString();
        public static string resultSubtract_6_1_by_minus2_4 = (6.1 - (-2.4)).ToString();
        public static string resultMultiply_6_1_by_minus2_4 = (6.1 * (-2.4)).ToString();
        public static string resultDivide_6_1_by_minus2_4 = (6.1 / (-2.4)).ToString();
        public static string resultDivide_6_1_by_0 = (6.1 / 0.0).ToString();
        public static string resultPower_6_1_by_minus2_4 = System.Math.Pow(6.1, (-2.4)).ToString();
        public static string resultPower_1e308_by_6_1 = System.Math.Pow(1e308, 6.1).ToString();
    }
}
