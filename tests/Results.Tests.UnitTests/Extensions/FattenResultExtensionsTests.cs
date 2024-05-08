using Results.Extensions;
using static Results.ResultFactory;

namespace Results.Tests.UnitTests.Extensions;

public class FlattenResultExtensionsTests
{
	[Fact]
	public void Flatten_OnSuccessfulNestedResult_ReturnsInnerSuccessfulResult()
	{
		// Arrange
		const string expectedResult = "Hello, World!";
		Result<Result<string>> nestedResult = Ok<Result<string>>(Ok<string>(expectedResult));

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
		Result<Result<string>> nestedResult = Error<Result<string>>(outerResult);

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
		Result<Result<string>> nestedResult = Ok<Result<string>>(Error<string>(innerResult));

		// Act
		var actualResult = nestedResult.Flatten();

		// Assert
		Assert.False(actualResult.IsSucceed);
		Assert.Equal(innerResult, actualResult.Errors);
	}
}