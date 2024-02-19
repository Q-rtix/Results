using Results.ResultTypes;

namespace Results.Tests.UnitTests.ResultTypesTests;

public class OkTests
{
    [Fact]
    public void Ok_ParameterizedConstructor_ShouldCreateInstanceWithExpectedValue()
    {
        // Arrange
        const string expectedResult = "Test value";
        
        // Act
        var okResult = new Ok<string>(expectedResult);
        
        // Assert
        Assert.True(okResult.IsSucceed);
        Assert.Equal(expectedResult, okResult.Value);
    }

    [Fact]
    public void Ok_ValueProperty_ShouldReturnCorrectValue()
    {
        // Arrange
        const string expectedResult = "Test value";
        
        // Act
        var okResult = new Ok<string>(expectedResult);
        
        // Assert
        Assert.True(okResult.IsSucceed);
        Assert.Equal(expectedResult, okResult.Value);
    }
    
    [Fact]
	public void Ok_ImplicitOperator_ShouldCreateInstanceWithExpectedValue()
	{
        // Arrange
		const string expectedResult = "Test value";
        
        // Act
		Ok<string> okResult = expectedResult;
        
        // Assert
        Assert.True(okResult.IsSucceed);
		Assert.Equal(expectedResult, okResult.Value);
	}
    
    [Fact]
    public void Ok_ToString_ShouldReturnCorrectString()
    {
        // Arrange
        const string value = "Test value";
        
        // Act
        var okResult = new Ok<string>(value);
        
        // Assert
        Assert.Equal($"Ok Result: {value}", okResult.ToString());
    }

    [Fact]
    public void Ok_GetType_ShouldReturnOkType()
    {
        // Arrange
        const string value = "Test value";
        
        // Act
        var okResult = new Ok<string>(value);
        
        // Assert
        Assert.IsType<Ok<string>>(okResult);
    }
}