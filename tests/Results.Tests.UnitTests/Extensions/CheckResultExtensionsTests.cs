using Results.Extensions;
using static Results.ResultFactory;

namespace Results.Tests.UnitTests.Extensions;

public class CheckResultExtensionsTests
{
	[Fact]
	public void IsSucceedAnd_ShouldReturnTrue_WhenResultIsSucceed_And_FunctionReturnsTrue()
	{
		// Arrange
		Result<string> result = Ok<string>("Success");

		// Act
		var actual = result.IsSucceedAnd(value => true);

		// Assert
		Assert.True(actual);
	}

	[Fact]
	public void IsSucceedAnd_ShouldReturnFalse_WhenResultIsSucceed_And_FunctionReturnsFalse()
	{
		// Arrange
		Result<string> result = Ok<string>("Success");

		// Act
		var actual = result.IsSucceedAnd(value => false);

		// Assert
		Assert.False(actual);
	}

	[Fact]
	public void IsSucceedAnd_ShouldReturnFalse_WhenResultIsNotSucceed_RegardlessOfFunction()
	{
		// Arrange
		Result<string> result = Error<string>("Failure");

		// Act
		var actualTrueFunc = result.IsSucceedAnd(value => true);
		var actualFalseFunc = result.IsSucceedAnd(value => false);

		// Assert
		Assert.False(actualTrueFunc);
		Assert.False(actualFalseFunc);
	}

	[Fact]
	public void IsFaultedAnd_ShouldReturnTrue_WhenResultIsFaulted_And_FunctionReturnsTrue()
	{
		// Arrange
		Result<string> result = Error<string>("Failure");

		// Act
		var actual = result.IsFaultedAnd(error => true);

		// Assert
		Assert.True(actual);
	}
}