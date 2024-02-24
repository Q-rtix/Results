using Results.ResultTypes;

namespace Results.Tests.UnitTests.ResultTests;

public class ResultTests
{
	[Fact]
	public void Result_ImplicitOperator_WhenResultIsError()
	{
		// Arrange
		const string error = "Test exception";
		
		// Act
		Result result = new Error(error);
		
		// Assert
		Assert.True(result.IsFaulted);
		Assert.False(result.IsSucceed);
		Assert.Equal(typeof(Error), result.GetType());
		Assert.Equal([error], result.Errors);
	}
	
	[Fact]
	public void Result_ImplicitOperator_WhenResultIsOk()
	{
		// Act
		Result result = new Ok();
		
		// Assert
		Assert.Equal(typeof(Ok), result.GetType());
		Assert.True(result.IsSucceed);
		Assert.False(result.IsFaulted);
	}
	
    [Fact]
    public void Result_Constructor_WhenResultTypeIsOk_CreatesInstanceWithoutValues()
    {
        // Act
        var result = new Result(new Ok());

        // Assert
        Assert.Equal(typeof(Ok), result.ResultType);
        Assert.True(result.IsSucceed);
        Assert.False(result.IsFaulted);
    }
    
    [Fact]
	public void Result_Constructor_WhenResultTypeIsError_CreatesInstanceWithExpectedError()
	{
		// Act
		var result = new Result(new Error("Error message"));
		
		// Assert
		Assert.Equal(typeof(Error), result.ResultType);
		Assert.False(result.IsSucceed);
		Assert.True(result.IsFaulted);
		Assert.Equal(["Error message"], result.Errors);
	}
	
	[Fact]
	public void Result_Constructor_WhenResultTypeIsErrorWithMultipleErrors_CreatesInstanceWithExpectedErrors()
	{
		// Act
		var result = new Result(new Error("Error message 1", "Error message 2"));
		
		// Assert
		Assert.Equal(typeof(Error), result.ResultType);
		Assert.False(result.IsSucceed);
		Assert.True(result.IsFaulted);
		Assert.Equal(["Error message 1", "Error message 2"], result.Errors);
	}
	
	[Fact]
	public void Result_Error_ReturnsErrorObject()
	{
		// Arrange
		Result result = new Error("Error message");
		
		// Act
		var error = result.Error();
		
		// Assert
		Assert.NotNull(error);
		Assert.Equal(typeof(Error), error.GetType());
		Assert.Equal(["Error message"], error.Errors);
	}
	
	[Fact]
	public void Result_GetErrorsOrDefault_WhenResultIsFaulted_ReturnsErrors()
	{
		// Arrange
		Result result = new Error("Error message");
		
		// Act
		var errors = result.GetErrorsOrDefault();
		
		// Assert
		Assert.NotNull(errors);
		Assert.Equal(["Error message"], errors);
	}
	
	[Fact]
	public void Result_GetErrorsOrDefault_WhenResultIsSucceed_ReturnsDefaultValue()
	{
		// Arrange
		Result result = new Ok();
		
		// Act
		var errors = result.GetErrorsOrDefault();
		
		// Assert
		Assert.Null(errors);
	}
	
	[Fact]
	public void Result_GetErrors_WhenResultIsFaulted_ReturnsErrors()
	{
		// Arrange
		Result result = new Error("Error message");
		
		// Act
		var errors = result.Errors;
		
		// Assert
		Assert.Equal(["Error message"], errors);
	}
	
	[Fact]
	public void Result_GetResultType_WhenResultTypeIsOk_ReturnsOkType()
	{
		// Arrange
		Result result = new Ok();
		
		// Act
		var resultType = result.ResultType;
		
		// Assert
		Assert.Equal(typeof(Ok), resultType);
	}
	
	[Fact]
	public void Result_GetResultType_WhenResultTypeIsError_ReturnsErrorType()
	{
		// Arrange
		Result result = new Error("Error message");
		
		// Act
		var resultType = result.ResultType;
		
		// Assert
		Assert.Equal(typeof(Error), resultType);
	}
}