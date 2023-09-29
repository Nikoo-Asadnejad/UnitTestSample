using Fundamental.Tests.TestData;

namespace Fundamental.Tests;

public class ThirdCalculatorTests 
{
    [Theory]
    [MemberData(nameof(CalculatorDataGenerator.IsOddData), MemberType = typeof(CalculatorDataGenerator))]
    public void IsOdd_WhenCalled_ReturnsExpected(int number, bool expected)
    {
        //Act
        bool result = Calculator.IsOdd(number);
        
        //Assert
        Assert.Equal(expected , result);
    }
}