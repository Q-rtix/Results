using Results.Factories;
using Results.ResultTypes;

namespace Results.Tests.UnitTests.ResultTests;

public class ResultTests
{
    [Fact]
    public void Result_Constructor_WhenResultTypeIsOk_CreatesInstanceWithoutValues()
    {
        // Act
        var result = TypedResult.Ok();

        // Assert
        Assert.Equal(typeof(Ok), result.ResultType);
        Assert.True(result.IsSucceed);
        Assert.False(result.IsFaulted);
    }
    
    [Fact]
	public void Result_Constructor_WhenResultTypeIsError_CreatesInstanceWithExpectedError()
	{
		// Act
		var result = TypedResult.Error("Error message");
		
		// Assert
		Assert.Equal(typeof(Error), result.ResultType);
		Assert.False(result.IsSucceed);
		Assert.True(result.IsFaulted);
		Assert.Equal(new object[] { "Error message" }, result.Errors);
	}
	
	[Fact]
	public void Result_Constructor_WhenResultTypeIsErrorWithMultipleErrors_CreatesInstanceWithExpectedErrors()
	{
		// Act
		var result = TypedResult.Error("Error message 1", "Error message 2");
		
		// Assert
		Assert.Equal(typeof(Error), result.ResultType);
		Assert.False(result.IsSucceed);
		Assert.True(result.IsFaulted);
		Assert.Equal(new object[] { "Error message 1", "Error message 2" }, result.Errors);
	}
	
	[Fact]
	public void Result_Error_ReturnsErrorObject()
	{
		// Arrange
		var result = TypedResult.Error("Error message");
		
		// Act
		var error = result.Error();
		
		// Assert
		Assert.NotNull(error);
		Assert.Equal(typeof(Error), error.GetType());
		Assert.Equal(new object[] { "Error message" }, error.Errors);
	}
	
	[Fact]
	public void Result_GetErrorsOrDefault_WhenResultIsFaulted_ReturnsErrors()
	{
		// Arrange
		var result = TypedResult.Error("Error message");
		
		// Act
		var errors = result.GetErrorsOrDefault();
		
		// Assert
		Assert.NotNull(errors);
		Assert.Equal(new object[] { "Error message" }, errors);
	}
	
	[Fact]
	public void Result_GetErrorsOrDefault_WhenResultIsSucceed_ReturnsDefaultValue()
	{
		// Arrange
		var result = TypedResult.Ok();
		
		// Act
		var errors = result.GetErrorsOrDefault();
		
		// Assert
		Assert.Null(errors);
	}
	
	[Fact]
	public void Result_GetErrors_WhenResultIsFaulted_ReturnsErrors()
	{
		// Arrange
		var result = TypedResult.Error("Error message");
		
		// Act
		var errors = result.Errors;
		
		// Assert
		Assert.Equal(new object[] { "Error message" }, errors);
	}
	
	[Fact]
	public void Result_GetResultType_WhenResultTypeIsOk_ReturnsOkType()
	{
		// Arrange
		var result = TypedResult.Ok();
		
		// Act
		var resultType = result.ResultType;
		
		// Assert
		Assert.Equal(typeof(Ok), resultType);
	}
	
	[Fact]
	public void Result_GetResultType_WhenResultTypeIsError_ReturnsErrorType()
	{
		// Arrange
		var result = TypedResult.Error("Error message");
		
		// Act
		var resultType = result.ResultType;
		
		// Assert
		Assert.Equal(typeof(Error), resultType);
	}

	[Fact]
	public void Result_ImplicitOperator_WhenResultIsException()
	{
		// Arrange
		var exception = new Exception("Test exception");
		
		// Act
		Error error = exception;
		
		// Assert
		Assert.Equal(typeof(Error), error.GetType());
		Assert.Equal(new object[] { exception }, error.Errors);
	}
	
	[Fact]
	public void Result_ImplicitOperator_WhenResultIsListOfExceptions()
	{
		// Arrange
		var exceptions = new List<Exception> { new("Exception 1"), new("Exception 2") };
		
		// Act
		Error error = exceptions;
		
		// Assert
		Assert.Equal(typeof(Error), error.GetType());
		Assert.Equal(exceptions, error.Errors);
	}
}