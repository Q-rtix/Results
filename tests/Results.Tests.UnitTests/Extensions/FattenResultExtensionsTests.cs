using Results.Extensions;
using Results.ResultTypes;

namespace Results.Tests.UnitTests.Extensions;

public class FlattenResultExtensionsTests
{
	[Fact]
	public void Flatten_OnSuccessfulNestedResult_ReturnsInnerSuccessfulResult()
	{
		// Arrange
		const string expectedResult = "Hello, World!";
		Result<Result<string>> nestedResult = new Ok<Result<string>>(new Ok<string>(expectedResult));

		// Act
		var actualResult = nestedResult.Flatten();

		// Assert
		Assert.True(actualResult.IsSucceed);
		Assert.Equal(expectedResult, actualResult.Value);
	}

	[Fact]
	public void Flatten_OnFailedOuterResult_ReturnsNewErrorResultWithOuterErrors()
	{
		// Arrange
		var outerResult = new object[] { "OuterError1", "OuterError2" };
		Result<Result<string>> nestedResult = new Error(outerResult);

		// Act
		var actualResult = nestedResult.Flatten();

		// Assert
		Assert.False(actualResult.IsSucceed);
		Assert.Equal(outerResult, actualResult.Errors);
	}

	[Fact]
	public void Flatten_OnSuccessfulOuterButFailedInnerResult_ReturnsFailedInnerResult()
	{
		// Arrange
		var innerResult = new object[] { "InnerError1", "InnerError2" };
		Result<Result<string>> nestedResult = new Ok<Result<string>>(new Error(innerResult));

		// Act
		var actualResult = nestedResult.Flatten();

		// Assert
		Assert.False(actualResult.IsSucceed);
		Assert.Equal(innerResult, actualResult.Errors);
	}

	[Fact]
	public void Flatten_OnSuccessfulOuterButFailedInnerEmptyResult_ReturnsFailedInnerResult()
	{
		// Arrange
		var innerResult = new object[] { "InnerError1", "InnerError2" };
		Result<Result> nestedResult = new Ok<Result>(new Error(innerResult));

		// Act
		var actualResult = nestedResult.Flatten();

		Assert.False(actualResult.IsSucceed);
		Assert.Equal(innerResult, actualResult.Errors);
	}
	
	[Fact]
	public void Flatten_OnSuccessfulOuterAndSuccessfulInnerEmptyResult_ReturnsSuccessfulInnerResult()
	{
		// Arrange
		Result<Result> nestedResult = new Ok<Result>(new Ok());

		// Act
		var actualResult = nestedResult.Flatten();

		Assert.True(actualResult.IsSucceed);
	}
		
	[Fact]
	public void Flatten_OnFailedOuterResultAndEmptyInnerResult_ReturnsNewErrorResultWithOuterErrors()
	{
		// Arrange
		var outerResult = new object[] { "OuterError1", "OuterError2" };
		Result<Result> nestedResult = new Error(outerResult);

		// Act
		var actualResult = nestedResult.Flatten();

		// Assert
		Assert.False(actualResult.IsSucceed);
		Assert.Equal(outerResult, actualResult.Errors);

	}
}