using JetBrains.Annotations;
using Results.ResultTypes;
using Results.WellKnownErrors;

namespace Results.Tests.UnitTests.Factories;

[TestSubject(typeof(ResultFactory))]
public class ResultFactoryTest
{
	[Fact]
	public void Result_FailureStaticConstructor_CreatesInstanceWithExpectedError()
	{
		// Act
		var result = ResultFactory.Failure("Error message");
		
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
		var result = ResultFactory.Failure(new Error("Error message"));
		
		// Assert
		Assert.Equal(typeof(Error), result.ResultType);
		Assert.False(result.IsSucceed);
		Assert.True(result.IsFaulted);
		Assert.Equal(["Error message"], result.Errors);
	}
	
	[Fact]
	public void Result_FailureStaticConstructorUsingErrorInstanceAndStatusCode_CreatesInstanceWithExpectedError()
	{
		// Act
		var result = ResultFactory.Failure(new Error("Error message"), 400);
		
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
		var result = ResultFactory.Success();
		
		// Assert
		Assert.Equal(typeof(Ok), result.ResultType);
		Assert.True(result.IsSucceed);
		Assert.False(result.IsFaulted);
	}
	
	[Fact]
	public void Result_SuccessStaticConstructorWithStatusCode_CreatesInstanceWithOutValues()
	{
		// Act
		var result = ResultFactory.Success(statusCode: 200);
		
		// Assert
		Assert.Equal(typeof(Ok), result.ResultType);
		Assert.True(result.IsSucceed);
		Assert.False(result.IsFaulted);
		Assert.Equal(200, result.StatusCode);
	}
	
	[Fact]
	public void ResultOfT_CreateStaticConstructor_WhenValueIsNull_CreateInstanceWithExpectedErrors()
	{
		// Act
		var result = ResultFactory.Create<string>();
		
		// Assert
		Assert.True(result.IsFaulted);
		Assert.Equal([WellKnownError.NullValue], result.Errors);
	}
	
	[Fact]
	public void ResultOfT_CreateStaticConstructor_WhenValueIsNullAndStatusCodeIs400_CreateInstanceWithExpectedErrors()
	{
		// Act
		var result = ResultFactory.Create<string>(statusCode: 400);
		
		// Assert
		Assert.True(result.IsFaulted);
		Assert.Equal([WellKnownError.NullValue], result.Errors);
		Assert.Equal(400, result.StatusCode);
	}
	
	[Fact]
	public void ResultOfT_CreateStaticConstructor_WhenValueIsNotNull_CreateInstanceWithExpectedErrors()
	{
		// Act
		var result = ResultFactory.Create<string>("value");
		
		// Assert
		Assert.True(result.IsSucceed);
		Assert.Equal("value", result.Value);
	}
	
	[Fact]
	public void ResultOfT_CreateStaticConstructor_WhenValueIsNotNullAndStatusCodeIs200_CreateInstanceWithExpectedErrors()
	{
		// Act
		var result = ResultFactory.Create<string>("value", 200);
		
		// Assert
		Assert.True(result.IsSucceed);
		Assert.Equal("value", result.Value);
		Assert.Equal(200, result.StatusCode);
	}

	[Fact]
	public void ResultOfT_FailureStaticConstructor_UsingErrors_CreateInstanceWithExpectedErrors()
	{
		// Act
		var result = ResultFactory.Failure<int>(new Error("error 1", "error 2"));
		
		// Assert
		Assert.True(result.IsFaulted);
		Assert.Equal(["error 1", "error 2"], result.Errors);
	}
	
	[Fact]
	public void ResultOfT_FailureStaticConstructor_UsingErrorsAndStatusCode400_CreateInstanceWithExpectedErrors()
	{
		// Act
		var result = ResultFactory.Failure<int>(new Error("error 1", "error 2"), 400);
		
		// Assert
		Assert.True(result.IsFaulted);
		Assert.Equal(["error 1", "error 2"], result.Errors);
		Assert.Equal(400, result.StatusCode);
	}

	[Fact]
	public void ResultOfT_FailureStaticConstructor_UsingObjectListAsErrors_CreateInstanceWithExpectedErrors()
	{
		// Act
		var result = ResultFactory.Failure<int>("error 1", "error 2");
		
		// Assert
		Assert.True(result.IsFaulted);
		Assert.Equal(["error 1", "error 2"], result.Errors);
	}

	[Fact]
	public void ResultOfT_SuccessStaticConstructor_WithValuesAndStatusCode200_CreatesInstanceWithValues()
	{
		// Act
		var result = ResultFactory.Success<string>("value", 200);
		
		// Assert
		Assert.True(result.IsSucceed);
		Assert.Equal("value", result.Value);
		Assert.Equal(200, result.StatusCode);
	}
}