using Fundamental.Tests.TestData;
using SampleProject;

namespace Fundamental.Tests;

public class ForthCalculatorTests 
{
    [Theory]
    [CalculatorData]
    public void IsOdd_WhenCalled_ReturnsExpected(int number, bool expected)
    {
        //Act
        bool result = Calculator.IsOdd(number);
        
        //Assert
        Assert.Equal(expected , result);
    }
}