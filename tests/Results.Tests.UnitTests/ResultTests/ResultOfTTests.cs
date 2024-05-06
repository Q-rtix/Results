using Results.ResultTypes;
using Results.WellKnownErrors;

namespace Results.Tests.UnitTests.ResultTests;

public class ResultOfTTests
{
	[Fact]
	public void ResultOfT_ImplicitOperator_WhenResultIsError()
	{
		// Arrange
		const string error = "Test exception";

		// Act
		Result<int> result = new Error(error);

		// Assert
		Assert.True(result.IsFaulted);
		Assert.False(result.IsSucceed);
		Assert.Equal(typeof(Error), result.ResultType);
		Assert.Equal([error], result.Errors);
	}

	[Fact]
	public void ResultOfT_ImplicitOperator_WhenResultIsOk()
	{
		// Act
		Result<int> result = new Ok<int>(2);

		// Assert
		Assert.Equal(typeof(Ok<int>), result.ResultType);
		Assert.True(result.IsSucceed);
		Assert.False(result.IsFaulted);
	}

	[Fact]
	public void ResultOfT_Constructor_WhenResultTypeIsOk_CreatesInstanceWithExpectedValues()
	{
		// Arrange
		const string value = "successful value";

		// Act
		Result<string> result = new Ok<string>(value);

		// Assert
		Assert.Equal(value, result.Value);
		Assert.True(result.IsSucceed);
	}

	[Fact]
	public void ResultOfT_Constructor_WhenResultTypeIsError_CreatesInstanceWithExpectedError()
	{
		// Arrange
		var errors = new List<object> { "error 1", "error 2" };

		// Act
		Result<string> result = new Error(errors);

		// Assert
		Assert.Equal(errors, result.Errors);
		Assert.True(result.IsFaulted);
	}

	[Fact]
	public void ResultOfT_Ok_WhenCalled_ReturnsResultWithOkResultType()
	{
		// Arrange
		const string value = "successful value";

		// Act
		Result<string> result = new Ok<string>(value);

		// Assert
		Assert.Equal(typeof(Ok<string>), result.ResultType);
	}

	[Fact]
	public void ResultOfT_Error_WhenCalled_ReturnsResultWithErrorResultType()
	{
		// Arrange
		var errors = new List<object> { "error 1", "error 2" };
		// Act
		Result<string> result = new Error(errors);
		// Assert
		Assert.Equal(typeof(Error), result.ResultType);
	}

	[Fact]
	public void ResultOfT_Value_WhenResultTypeIsOk_ReturnsExpectedValue()
	{
		// Arrange
		const string value = "successful value";
		Result<string> result = new Ok<string>(value);

		// Act
		var resultValue = result.Value;

		// Assert
		Assert.Equal(value, resultValue);
	}

	[Fact]
	public void ResultOfT_Value_WhenResultTypeIsError_ThrowsInvalidOperationException()
	{
		// Arrange
		var errors = new List<object> { "error 1", "error 2" };
		Result<int> result = new Error(errors);

		// Act & Assert
		Assert.Throws<InvalidOperationException>(() => result.Value);
	}

	[Fact]
	public void ResultOfT_GetValueOrDefault_WhenResultTypeIsOk_ReturnsExpectedValue()
	{
		// Arrange
		const string value = "successful value";
		Result<string> result = new Ok<string>(value);

		// Act
		var resultValue = result.GetValueOrDefault();

		// Assert
		Assert.Equal(value, resultValue);
	}

	[Fact]
	public void ResultOfT_GetValueOrDefault_WhenResultTypeIsError_ReturnsDefaultValue()
	{
		// Arrange
		var errors = new List<object> { "error 1", "error 2" };
		Result<int> result = new Error(errors);

		// Act
		var resultValue = result.GetValueOrDefault();

		// Assert
		Assert.Equal(default, resultValue);
	}

	[Fact]
	public void ResultOfT_GetValueOr_WhenResultTypeIsOk_ReturnsExpectedValue()
	{
		// Arrange
		const string value = "successful value";
		Result<string> result = new Ok<string>(value);

		// Act
		var resultValue = result.GetValueOr("default value");

		// Assert
		Assert.Equal(value, resultValue);
	}

	[Fact]
	public void ResultOfT_GetValueOr_WhenResultTypeIsError_ReturnsDefaultValue()
	{
		// Arrange
		var errors = new List<object> { "error 1", "error 2" };
		Result<string> result = new Error(errors);

		// Act
		var resultValue = result.GetValueOr("default value");

		// Assert
		Assert.Equal("default value", resultValue);
	}

	[Fact]
	public void ResultOfT_GetValueOrElse_WhenResultTypeIsOk_ReturnsExpectedValue()
	{
		// Arrange
		const string value = "successful value";
		Result<string> result = new Ok<string>(value);

		// Act
		var resultValue = result.GetValueOrElse((error) => error.ToString());

		// Assert
		Assert.Equal(value, resultValue);
	}

	[Fact]
	public void ResultOfT_GetValueOrElse_WhenResultTypeIsError_ReturnsExpectedValue()
	{
		// Arrange
		var errors = new List<object> { "error 1", "error 2" };
		Result<string> result = new Error(errors);

		// Act
		var resultValue = result.GetValueOrElse((error) =>
			error.GetType() == typeof(Exception) ? "critical error" : "non critical error");

		// Assert
		Assert.Equal("non critical error", resultValue);
	}

	[Fact]
	public void ResultOfT_Match_WhenResultTypeIsOk_CallsSuccessFunction()
	{
		// Arrange
		const string value = "successful value";
		Result<string> result = new Ok<string>(value);

		// Act
		var resultValue = result.Match(success: val => val,
			fail: err => throw new InvalidOperationException("Match should not call fail function"));

		// Assert
		Assert.Equal(value, resultValue);
	}

	[Fact]
	public void ResultOfT_Match_WhenResultTypeIsError_CallsFailFunction()
	{
		// Arrange
		var errors = new List<object> { "error 1", "error 2" };
		Result<string> result = new Error(errors);

		// Act
		var resultValue =
			result.Match(success: val => throw new InvalidOperationException("Match should not call success function"),
				fail: err => err.Errors);

		// Assert
		Assert.Equal(errors, resultValue);
	}

	[Fact]
	public void ResultOfT_OnSuccess_WhenResultTypeIsOk_CallsSuccessFunction()
	{
		// Arrange
		Result<int> result = new Ok<int>(5);
		
		// Act
		var resultValue = result.OnSuccess(x => x + 1);
		
		// Assert
		Assert.Equal(6, resultValue);
	}
	
	[Fact]
	public void ResultOfT_OnSuccess_WhenResultTypeIsError_ReturnsDefaultValue()
	{
		// Arrange
		Result<int> result = new Error(new List<object> { "error 1", "error 2" });
		
		// Act
		var resultValue = result.OnSuccess(x => x + 1);
		
		// Assert
		Assert.Equal(default, resultValue);
	}

	[Fact]
	public void ResultOfT_Inspect_WhenResultTypeIsOk_CallsSuccessFunction()
	{
		// Arrange
		Result<int> result = new Ok<int>(5);
		
		// Act & Assert
		result.Inspect(x => Assert.Equal(5, x));
	}

	[Fact]
	public void ResultOfT_Inspect_WhenResultTypeIsError_DoesNotCallSuccessFunction()
	{
		// Arrange
		Result<int> result = new Error(new List<object> { "error 1", "error 2" });
		
		// Act & Assert
		result.Inspect(x => throw new Exception("Inspect should not call fail function"));
	}

	[Fact]
	public void ResultOfT_InspectError_WhenResultTypeIsOk_DoesNotCallFailFunction()
	{
		// Arrange
		Result<int> result = new Ok<int>(5);
		
		// Act & Assert
		result.InspectError(x => throw new Exception("InspectError should not call success function"));
	}

	[Fact]
	public void ResultOfT_InspectError_WhenResultTypeIsError_CallsFailFunction()
	{
		// Arrange
		Result<int> result = new Error(new List<object> { "error 1", "error 2" });
		
		// Act & Assert
		result.InspectError(x => Assert.Equal("error 1", x.Errors[0]));
	}
	
}