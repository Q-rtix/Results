using Results.ResultTypes;

namespace Results.Tests.UnitTests.ResultTypesTests;

public class ErrorTests
{
    [Fact]
    public void Error_ParameterizedConstructor_ShouldCreateInstanceWith1Error()
    {
        // Arrange
        const string expectedOutcome = "Some error message";

        // Act
        var errorInstance = new Error(expectedOutcome); 

        // Assert
        Assert.Equal(expectedOutcome, errorInstance.Errors[0]);
    }
    
    [Fact]
    public void Error_ParameterizedConstructor_ShouldCreateInstanceWith2Errors()
    {
        // Arrange
        const string errorMessage = "Some error message";
        const int errorNumber = 1;

        // Act
        var errorInstance = new Error(errorMessage, errorNumber);

        // Assert
        Assert.Equal(errorMessage, errorInstance.Errors[0]);
        Assert.Equal(errorNumber, errorInstance.Errors[1]);
    }

    [Fact]
    public void Error_ParameterizedConstructor_ShouldCreateInstanceWithListErrors()
    {
        // Arrange
        var expectedErrors = new List<string> {"Error 1", "Error 2", "Error 3"};

        // Act
        var errorInstance = new Error(expectedErrors);

        // Assert
        Assert.Equal(expectedErrors, errorInstance.Errors);
    }
    
    [Fact]
	public void Error_ImplicitOperator_ShouldCreateInstanceWithExceptionError()
	{
		// Arrange
		var exception = new Exception("Some exception");
		// Act
		Error errorInstance = exception;
		// Assert
		Assert.Equal(exception, errorInstance.Errors[0]);
	}

    [Fact]
    public void Error_ImplicitOperator_ShouldCreateInstanceWithListExceptionError()
	{
		// Arrange
		var exceptions = new List<Exception>
		{
			new("Some exception"),
			new("Some exception 2")
		};
		// Act
		Error errorInstance = exceptions;
		// Assert
		Assert.Equal(exceptions[0], errorInstance.Errors[0]);
		Assert.Equal(exceptions[1], errorInstance.Errors[1]);
	}
	
	[Fact]
	public void Error_ToString_ShouldReturnErrorMessage()
	{
		// Arrange
		var expectedErrors = new object[] { "Error 1", "Error 2", "Error 3" };
		var errorInstance = new Error(expectedErrors);
		// Act
		var result = errorInstance.ToString();
		// Assert
		Assert.Equal($"Error Result: {string.Join(", ", expectedErrors.Select(err => err.ToString()))}", result);
	}
}