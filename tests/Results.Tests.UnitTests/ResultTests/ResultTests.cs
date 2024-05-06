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
		Assert.Equal(typeof(Error), result.ResultType);
		Assert.Equal([error], result.Errors);
	}
	
	[Fact]
	public void Result_ImplicitOperator_WhenResultIsOk()
	{
		// Act
		Result result = new Ok();
		
		// Assert
		Assert.Equal(typeof(Ok), result.ResultType);
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
    public void Result_Constructor_WhenResultTypeIsOkAndStatusCode_CreatesInstanceWithoutValues()
    {
	    // Act
	    var result = new Result(new Ok(), 200);

	    // Assert
	    Assert.Equal(typeof(Ok), result.ResultType);
	    Assert.True(result.IsSucceed);
	    Assert.False(result.IsFaulted);
	    Assert.Equal(200, result.StatusCode);
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
	public void Result_Constructor_WhenResultTypeIsErrorAndStatusCode_CreatesInstanceWithExpectedError()
	{
		// Act
		var result = new Result(new Error("Error message"), 400);
		
		// Assert
		Assert.Equal(typeof(Error), result.ResultType);
		Assert.False(result.IsSucceed);
		Assert.True(result.IsFaulted);
		Assert.Equal(["Error message"], result.Errors);
		Assert.Equal(400, result.StatusCode);
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
	public void Result_Error_ReturnsNull_WhenTheResultIsSucceed()
	{
		// Arrange
		Result result = new Ok();
		
		// Act
		var error = result.Error();
		
		// Assert
		Assert.Null(error);
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
	public void Result_GetErrorsOr_WhenResultIsFaulted_ReturnErrors()
	{
		// Arrange
		Result result = new Error("Error message");
		
		// Act
		var errors = result.GetErrorsOr();
		
		// Assert
		Assert.NotNull(errors);
		Assert.Equal(["Error message"], errors);	
	}
	
	[Fact]
	public void Result_GetErrorsOr_WhenResultIsSucceed_ReturnsValues()
	{
		// Arrange
		Result result = new Ok();
		
		// Act
		var errors = result.GetErrorsOr("Message if succeed");
		
		// Assert
		Assert.NotNull(errors);
		Assert.Equal(["Message if succeed"], errors);	
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
	public void Result_OnFail_DoesNotExecuteFunction_WhenResultIsSuccess()
	{
		// Arrange
		Result result = new Ok();  

		// Act
		var output = result.OnFail(e => "Function was executed");

		// Assert
		Assert.Null(output); 
	}
	
	[Fact]
	public void Result_OnFail_TestFunctionRuns_WhenIsFaulted()
	{
		// Arrange
		Result result = new Error("Some error");

		// Act
		var output = result.OnFail(e => "Function was executed");

		// Assert
		Assert.Equal("Function was executed", output);
	}

	[Fact]
	public void Result_OnSuccess_TestFunctionRuns_WhenResultIsSucceed()
	{
		// Arrange
		Result result = new Ok();
		
		// Act
		var output = result.OnSuccess(() => "Function was executed");
		
		// Assert
		Assert.Equal("Function was executed", output);
	}
	
	[Fact]
	public void Result_OnSuccess_DoesNotExecuteFunction_WhenResultIsFaulted()
	{
		// Arrange
		Result result = new Error("Some error");
		
		// Act
		var output = result.OnSuccess(() => "Function was executed");
		
		// Assert
		Assert.Null(output);
	}

	[Fact]
	public void Result_InspectError_TestActionRuns_WhenResultIsFaulted()
	{
		// Arrange
		Result result = new Error("Some error");
		
		// Act & Assert
		var exception = Assert.Throws<Exception>(() => result.InspectError(e => throw new Exception("Function was executed")));
		Assert.Equal("Function was executed", exception.Message);
	}

	[Fact]
	public void Result_InspectError_DoesNotExecuteAction_WhenResultIsSucceed()
	{
		// Arrange
		Result result = new Ok();
		
		// Act & Assert
		result.InspectError(e => throw new Exception("Function was executed"));
	}
	
	[Fact]
	public void Result_Match_TestSuccessFunctionRuns_WhenResultIsSucceed()
	{
		// Arrange
		Result result = new Ok();
		
		// Act
		var output = result.Match(() => "Success function was executed", e => "Error function was executed");
		
		// Assert
		Assert.Equal("Success function was executed", output);
	}

	[Fact]
	public void Result_Match_TesFailureFunctionRuns_WhenResultIsFaulted()
	{
		// Arrange
		Result result = new Error("Some error");

		// Act
		var output = result.Match(() => "Success function was executed", e => "Error function was executed");

		// Assert
		Assert.Equal("Error function was executed", output);
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