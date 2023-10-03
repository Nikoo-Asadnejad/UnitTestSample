namespace Fundamental.Tests.TestData;

public static class CalculatorDataGenerator
{
    public static IEnumerable<object[]> IsOddData
    {
        get
        {
            yield return new object[] { 3, true };
            yield return new object[] { 2, false };
            yield return new object[] { 0, false };
            yield return new object[] { -3, true };
            yield return new object[] { -2, false };
        }
    }
        
}