using Results.Extensions;
using Results.ResultTypes;

namespace Results.Tests.UnitTests.Extensions;

public class MapperSuccessfulResultValueExtensionsTests
{
	[Fact]
	public void MapOr_ShouldReturnMappedValue_WhenResultIsSucceed()
	{
		// Arrange
		Result<int> initialResult = new Ok<int>(5);
		const string defaultValue = "Default value";

		// Act
		var actual = initialResult.MapOr(i => $"Mapped value: {i}", defaultValue);

		// Assert
		Assert.Equal("Mapped value: 5", actual);
	}

	[Fact]
	public void MapOr_ShouldReturnDefaultValue_WhenResultIsFailed()
	{
		// Arrange
		Result<int> initialResult = new Error("Error from initial result");
		const string defaultValue = "Default value";

		// Act
		var actual = initialResult.MapOr(i => $"Mapped value: {i}", defaultValue);

		// Assert
		Assert.Equal(defaultValue, actual);
	}

	[Fact]
	public void MapOrElse_ShouldReturnMappedValue_WhenResultIsSucceed()
	{
		// Arrange
		Result<int> initialResult = new Ok<int>(5);

		// Act
		var actual = initialResult.MapOrElse(
			i => $"Mapped value: {i}", 
			e => "Default value");

		// Assert
		Assert.Equal("Mapped value: 5", actual);
	}

	[Fact]
	public void MapOrElse_ShouldReturnDefaultFunctionValue_WhenResultIsFailed()
	{
		// Arrange
		Result<int> initialResult = new Error("Error from initial result");

		// Act
		var actual = initialResult.MapOrElse(
			i => $"Mapped value: {i}", 
			e => $"Default function value: {e}");

		// Assert
		Assert.Equal("Default function value: Error from initial result", actual);
	}
}