using Results.Factories;
using Results.ResultTypes;

namespace Results.Tests.UnitTests.ResultTests;

public class GenericResultTests
{
	[Fact]
	public void GenericResult_Constructor_WhenResultTypeIsOk_CreatesInstanceWithExpectedValues()
	{
		// Arrange
		const string value = "successful value";
		
		// Act
		var result = TypedResult.Ok(value);
		
		// Assert
		Assert.Equal(value, result.Value);
		Assert.True(result.IsSucceed);
	}
	
	[Fact]
	public void GenericResult_Constructor_WhenResultTypeIsError_CreatesInstanceWithExpectedError()
	{
		// Arrange
		var errors = new List<object> { "error 1", "error 2" };
		
		// Act
		var result = TypedResult.Error<string>(errors);
		
		// Assert
		Assert.Equal(errors, result.Errors);
		Assert.True(result.IsFaulted);
	}
	
	[Fact]
	public void GenericResult_Ok_WhenCalled_ReturnsResultWithOkResultType()
	{
		// Arrange
		const string value = "successful value";
		
		// Act
		var result = TypedResult.Ok(value);
		
		// Assert
		Assert.IsType<Ok<string>>(result.ResultType);
	}
	
	[Fact]
	public void GenericResult_Error_WhenCalled_ReturnsResultWithErrorResultType()
	{
		// Arrange
		var errors = new List<object> { "error 1", "error 2" };
		// Act
		var result = TypedResult.Error<string>(errors);
		// Assert
		Assert.IsType<Error>(result.ResultType);
	}
	
	[Fact]
	public void GenericResult_Value_WhenResultTypeIsOk_ReturnsExpectedValue()
	{
		// Arrange
		const string value = "successful value";
		var result = TypedResult.Ok(value);
		
		// Act
		var resultValue = result.Value;
		
		// Assert
		Assert.Equal(value, resultValue);
	}
	
	[Fact]
	public void GenericResult_Value_WhenResultTypeIsError_ThrowsInvalidOperationException()
	{
		// Arrange
		var errors = new List<object> { "error 1", "error 2" };
		var result = TypedResult.Error<string>(errors);
		
		// Act & Assert
		Assert.Throws<InvalidOperationException>(() => result.Value);
	}
	
	[Fact]
	public void GenericResult_GetValueOrDefault_WhenResultTypeIsOk_ReturnsExpectedValue()
	{
		// Arrange
		const string value = "successful value";
		var result = TypedResult.Ok(value);
		
		// Act
		var resultValue = result.GetValueOrDefault();
		
		// Assert
		Assert.Equal(value, resultValue);
	}
	
	[Fact]
	public void GenericResult_GetValueOrDefault_WhenResultTypeIsError_ReturnsDefaultValue()
	{
		// Arrange
		var errors = new List<object> { "error 1", "error 2" };
		var result = TypedResult.Error<string>(errors);
		
		// Act
		var resultValue = result.GetValueOrDefault();
		
		// Assert
		Assert.Equal(default, resultValue);
	}
	
	[Fact]
	public void GenericResult_GetValueOr_WhenResultTypeIsOk_ReturnsExpectedValue()
	{
		// Arrange
		const string value = "successful value";
		var result = TypedResult.Ok(value);
		
		// Act
		var resultValue = result.GetValueOr("default value");
		
		// Assert
		Assert.Equal(value, resultValue);
	}
	
	[Fact]
	public void GenericResult_GetValueOr_WhenResultTypeIsError_ReturnsDefaultValue()
	{
		// Arrange
		var errors = new List<object> { "error 1", "error 2" };
		var result = TypedResult.Error<string>(errors);
		
		// Act
		var resultValue = result.GetValueOr("default value");
		
		// Assert
		Assert.Equal("default value", resultValue);
	}
	
	[Fact]
	public void GenericResult_Match_WhenResultTypeIsOk_CallsSuccessFunction()
	{
		// Arrange
		const string value = "successful value";
		var result = TypedResult.Ok(value);
		
		// Act
		var resultValue = result.Match(success: val => val,
			fail: err => throw new InvalidOperationException("Match should not call fail function"));
		
		// Assert
		Assert.Equal(value, resultValue);
	}
	
	[Fact]
	public void GenericResult_Match_WhenResultTypeIsError_CallsFailFunction()
	{
		// Arrange
		var errors = new List<object> { "error 1", "error 2" };
		var result = TypedResult.Error<string>(errors);
		
		// Act
		var resultValue =
			result.Match(success: val => throw new InvalidOperationException("Match should not call success function"),
				fail: err => err.Errors);
		
		// Assert
		Assert.Equal(errors, resultValue);
	}
}