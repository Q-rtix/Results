using Results.Extensions;
using Results.ResultTypes;

namespace Results.Tests.UnitTests.Extensions;

public class CheckResultExtensionsTests
{
	[Fact]
	public void IsSucceedAnd_ShouldReturnTrue_WhenResultIsSucceed_And_FunctionReturnsTrue()
	{
		// Arrange
		Result<string> result = new Ok<string>("Success");

		// Act
		var actual = result.IsSucceedAnd(value => true);

		// Assert
		Assert.True(actual);
	}

	[Fact]
	public void IsSucceedAnd_ShouldReturnFalse_WhenResultIsSucceed_And_FunctionReturnsFalse()
	{
		// Arrange
		Result<string> result = new Ok<string>("Success");

		// Act
		var actual = result.IsSucceedAnd(value => false);

		// Assert
		Assert.False(actual);
	}

	[Fact]
	public void IsSucceedAnd_ShouldReturnFalse_WhenResultIsNotSucceed_RegardlessOfFunction()
	{
		// Arrange
		Result<string> result = new Error("Failure");

		// Act
		var actualTrueFunc = result.IsSucceedAnd(value => true);
		var actualFalseFunc = result.IsSucceedAnd(value => false);

		// Assert
		Assert.False(actualTrueFunc);
		Assert.False(actualFalseFunc);
	}

	[Fact]
	public void IsFailedAnd_ShouldReturnTrue_WhenResultIsFailed_And_FunctionReturnsTrue()
	{
		// Arrange
		Result result = new Error("Error");

		// Act
		var actual = result.IsFailedAnd(error => true);

		// Assert
		Assert.True(actual);
	}

	[Fact]
	public void IsFailedAnd_ShouldReturnFalse_WhenResultIsFailed_And_FunctionReturnsFalse()
	{
		// Arrange
		Result result = new Error("Error");

		// Act
		var actual = result.IsFailedAnd(error => false);

		// Assert
		Assert.False(actual);
	}

	[Fact]
	public void IsFailedAnd_ShouldReturnFalse_WhenResultIsSucceed_RegardlessOfFunction()
	{
		// Arrange
		Result result = new Ok();

		// Act
		var actualTrueFunc = result.IsFailedAnd(error => true);
		var actualFalseFunc = result.IsFailedAnd(error => false);

		// Assert
		Assert.False(actualTrueFunc);
		Assert.False(actualFalseFunc);
	}
}