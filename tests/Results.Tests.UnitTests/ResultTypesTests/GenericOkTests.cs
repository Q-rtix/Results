using Results.ResultTypes;

namespace Results.Tests.UnitTests.ResultTypesTests;

public class GenericOkTests
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
}