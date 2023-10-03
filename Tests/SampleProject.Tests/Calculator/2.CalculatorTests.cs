using SampleProject;

namespace Fundamental.Tests;

public class SecondCalculatorTests 
{
    [Theory]
    [InlineData(3, true)]
    [InlineData(2, false)]
    [InlineData(0,false)]
    [InlineData(-5, true)]
    [InlineData(-4, false)]
    public void IsOdd_WhenCalled_ReturnsExpected(int number, bool expected)
    {
        //Act
        bool result = Calculator.IsOdd(number);
        
        //Assert
        Assert.Equal(expected , result);
    }
}