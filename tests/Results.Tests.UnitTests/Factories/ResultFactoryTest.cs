using JetBrains.Annotations;
using Results.ResultTypes;
using static Results.ResultFactory;

namespace Results.Tests.UnitTests.Factories;

[TestSubject(typeof(ResultFactory))]
public class ResultTest
{
	[Fact]
	public void Result_FailureStaticConstructor_CreatesInstanceWithExpectedError()
	{
		// Act
		var result = Error<int>("Error message");
		
		// Assert
		Assert.Equal(typeof(Error), result.ResultType);
		Assert.False(result.IsSucceed);
		Assert.True(result.IsFaulted);
		Assert.Equal(["Error message"], result.Errors);
	}
	
	[Fact]
	public void Result_FailureStaticConstructorUsingListErrorInstance_CreatesInstanceWithExpectedError()
	{
		// Arrange
		List<string> errors = ["Error message"];
		
		// Act
		var result = Error<int>(errors);
		
		// Assert
		Assert.Equal(typeof(Error), result.ResultType);
		Assert.False(result.IsSucceed);
		Assert.True(result.IsFaulted);
		Assert.Equal(["Error message"], result.Errors);
	}
	
	[Fact]
	public void Result_FailureStaticConstructorUsingErrorInstance_CreatesInstanceWithExpectedError()
	{
		// Act
		var result = Error<int>(new Error("Error message"), 400);
		
		// Assert
		Assert.Equal(typeof(Error), result.ResultType);
		Assert.False(result.IsSucceed);
		Assert.True(result.IsFaulted);
		Assert.Equal(["Error message"], result.Errors);
		Assert.Equal(400, result.StatusCode);
	}
	
	[Fact]
	public void Result_SuccessStaticConstructor_CreatesInstanceWithOutValues()
	{
		// Act
		var result = Ok();
		
		// Assert
		Assert.Equal(typeof(Ok<Empty>), result.ResultType);
		Assert.True(result.IsSucceed);
		Assert.False(result.IsFaulted);
	}
	
	[Fact]
	public void Result_SuccessStaticConstructorWithStatusCode_CreatesInstanceWithOutValues()
	{
		// Act
		var result = Ok(statusCode: 200);
		
		// Assert
		Assert.Equal(typeof(Ok<Empty>), result.ResultType);
		Assert.True(result.IsSucceed);
		Assert.False(result.IsFaulted);
		Assert.Equal(200, result.StatusCode);
	}
	
	[Fact]
	public void ResultOfT_FailureStaticConstructor_UsingErrors_CreateInstanceWithExpectedErrors()
	{
		// Act
		var result = Error<int>(new Error("error 1", "error 2"));
		
		// Assert
		Assert.True(result.IsFaulted);
		Assert.Equal(["error 1", "error 2"], result.Errors);
	}
	
	[Fact]
	public void ResultOfT_FailureStaticConstructor_UsingErrorsAndStatusCode400_CreateInstanceWithExpectedErrors()
	{
		// Act
		var result = Error<int>(new Error("error 1", "error 2"), 400);
		
		// Assert
		Assert.True(result.IsFaulted);
		Assert.Equal(["error 1", "error 2"], result.Errors);
		Assert.Equal(400, result.StatusCode);
	}

	[Fact]
	public void ResultOfT_FailureStaticConstructor_UsingObjectListAsErrors_CreateInstanceWithExpectedErrors()
	{
		// Act
		var result = Error<int>("error 1", "error 2");
		
		// Assert
		Assert.True(result.IsFaulted);
		Assert.Equal(["error 1", "error 2"], result.Errors);
	}

	[Fact]
	public void ResultOfT_SuccessStaticConstructor_WithValuesAndStatusCode200_CreatesInstanceWithValues()
	{
		// Act
		var result = Ok<string>("value", 200);
		
		// Assert
		Assert.True(result.IsSucceed);
		Assert.Equal("value", result.Value);
		Assert.Equal(200, result.StatusCode);
	}
}