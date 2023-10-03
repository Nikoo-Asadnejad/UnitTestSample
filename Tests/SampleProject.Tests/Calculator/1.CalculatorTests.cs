using SampleProject;

/// <summary>
/// Namings, arrange act assert, why should we use parameterized tests
/// </summary>
public class FirstCalculatorTests
{
    [Fact]
    public void IsOdd_NumIsOdd_ReturnsTrue()
    {
        //Arrange 
        int number = 3;
        
        //Act 
        bool result  = Calculator.IsOdd(number);
        
        //Assert
        Assert.True(result);
    }
    
    [Fact]
    public void IsOdd_NumIsNotOdd_ReturnsFalse()
    {
        //Arrange 
        int number = 2;
        
        //Act 
        bool result  = Calculator.IsOdd(number);
        
        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void IsOdd_NumIsZero_ReturnsFalse()
    {
        //Arrange 
        int number = 0;
        
        //Act 
        bool result  = Calculator.IsOdd(number);
        
        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void IsOdd_NumIsNegativeOdd_ReturnsTrue()
    {
        //Arrange 
        int number = -3;
        
        //Act 
        bool result  = Calculator.IsOdd(number);
        
        //Assert
        Assert.False(result);
    }
    
    [Fact]
    public void IsOdd_NumIsNegativeEven_ReturnsTrue()
    {
        //Arrange 
        int number = -2;
        
        //Act 
        bool result  = Calculator.IsOdd(number);
        
        //Assert
        Assert.True(result);
    }
    
    
    
}