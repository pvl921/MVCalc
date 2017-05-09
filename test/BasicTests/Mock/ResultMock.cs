namespace BasicTests.Mock
{
    public static class ResultMock
    {
        public static string ResultSum6_1AndMinus2_4 = (6.1 + (-2.4)).ToString();
        public static string ResultSubtract6_1ByMinus2_4 = (6.1 - (-2.4)).ToString();
        public static string ResultMultiply6_1ByMinus2_4 = (6.1 * (-2.4)).ToString();
        public static string ResultDivide6_1ByMinus2_4 = (6.1 / (-2.4)).ToString();
        public static string ResultDivide6_1By0 = (6.1 / 0.0).ToString();
        public static string ResultPower6_1ByMinus2_4 = System.Math.Pow(6.1, (-2.4)).ToString();
        public static string ResultPower1e308By6_1 = System.Math.Pow(1e308, 6.1).ToString();
    }
}
