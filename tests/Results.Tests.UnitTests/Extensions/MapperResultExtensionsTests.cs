using Results.Extensions;
using Results.ResultTypes;
using static Results.ResultFactory;

namespace Results.Tests.UnitTests.Extensions;

public class MapperResultExtensionsTests
{
	[Fact]
	public async Task MapAsync_ShouldReturnMappedResult_WhenPriorResultIsSucceed()
	{
		// Arrange
		var firstResult = Ok<int>(5);

		// Act
		var actual = await firstResult.MapAsync(async (v) => "Mapped to string: " + await Task.Run(v.ToString));

		// Assert
		Assert.Equal(typeof(Ok<string>), actual.ResultType);
		Assert.Equal("Mapped to string: 5", actual.Value);
	}

	[Fact]
	public async Task MapAsync_ShouldReturnFirstResult_WhenPriorResultIsFailed()
	{
		// Arrange
		var firstResult = Error<string>("Error from first result");

		// Act
		var actual = await firstResult.MapAsync(async (v) => "Mapped to string" + await Task.Run(v.ToString));

		// Assert
		Assert.Equal(typeof(Error), actual.ResultType);
		Assert.Equal(["Error from first result"], actual.Errors);
	}

	[Fact]
	public void Map_ShouldReturnMappedResult_WhenPriorResultIsSucceed()
	{
		// Arrange
		var firstResult = Ok<int>(5);

		// Act
		var actual = firstResult.Map(i => $"Mapped to string: {i}");

		// Assert
		Assert.Equal(typeof(Ok<string>), actual.ResultType);
		Assert.Equal("Mapped to string: 5", actual.Value);
	}

	[Fact]
	public void Map_ShouldReturnFirstResult_WhenPriorResultIsFailed()
	{
		// Arrange
		var firstResult = Error<int>("Error from first result");

		// Act
		var actual = firstResult.Map(i => $"Mapped to string: {i}");

		// Assert
		Assert.Equal(typeof(Error), actual.ResultType);
		Assert.Equal("Error: Error from first result", actual.ToString());
	}

	[Fact]
	public void MapOr_ShouldReturnMappedValue_WhenResultIsSucceed()
	{
		// Arrange
		var initialResult = Ok<int>(5);
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
		var initialResult = Error<int>("Error from initial result");
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
		var initialResult = Ok<int>(5);

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
		var initialResult = Error<int>("Error from initial result");

		// Act
		var actual = initialResult.MapOrElse(
			i => $"Mapped value: {i}",
			e => $"Default function value: {e}");

		// Assert
		Assert.Equal("Default function value: Error from initial result", actual);
	}

	[Fact]
	public async Task MapOrAsync_ShouldReturnMappedValue_WhenResultIsSucceed()
	{
		// Arrange
		var initialResult = Ok<int>(5);

		// Act
		var actual = await initialResult
			.MapOrAsync(async i => $"Mapped value: " + await Task.Run(i.ToString),  "Default value");

		// Assert
		Assert.Equal("Mapped value: 5", actual);
	}

	[Fact]
	public async Task MapOrAsync_ShouldReturnDefaultValue_WhenResultIsFailed()
	{
		// Arrange
		var initialResult = Error<int>("Error from initial result");

		// Act
		var actual = await initialResult
			.MapOrAsync(async i => $"Mapped value: " + await Task.Run(i.ToString),  "Default value");

		// Assert
		Assert.Equal("Default value", actual);
	}

	[Fact]
	public async Task MapOrElseAsync_ShouldReturnMappedValue_WhenResultIsSucceed()
	{
		// Arrange
		var initialResult = Ok<int>(5);

		// Act
		var actual = await initialResult
			.MapOrElseAsync(async i => $"Mapped value: " + await Task.Run(i.ToString), e => $"Errors: {e}");

		// Assert
		Assert.Equal("Mapped value: 5", actual);
	}

	[Fact]
	public async Task MapOrElseAsync_ShouldReturnDefaultFunctionValue_WhenResultIsFailed()
	{
		// Arrange
		var initialResult = Error<int>("Error from initial result");

		// Act
		var actual = await initialResult
			.MapOrElseAsync(async i => $"Mapped value: " + await Task.Run(i.ToString), e => $"Errors: {e}");

		// Assert
		Assert.Equal("Errors: Error from initial result", actual);
	}

	[Fact]
	public async Task MapOrElseAsync_WithAsyncPredicate_ShouldReturnMappedValue_WhenResultIsSucceed()
	{
		// Arrange
		var initialResult = Ok<int>(5);

		// Act
		var actual = await initialResult
			.MapOrElseAsync(async i => $"Mapped value: " + await Task.Run(i.ToString), async e => $"Errors: " + await Task.Run(e.ToString));

		// Assert
		Assert.Equal("Mapped value: 5", actual);
	}

	[Fact]
	public async Task MapOrElseAsync_WithAsyncPredicate_ShouldReturnDefaultFunctionValue_WhenResultIsFailed()
	{
		// Arrange
		var initialResult = Error<int>("Error from initial result");

		// Act
		var actual = await initialResult
			.MapOrElseAsync(async i => $"Mapped value: " + await Task.Run(i.ToString), async e => $"Errors: " + await Task.Run(e.ToString));

		// Assert
		Assert.Equal("Errors: Error from initial result", actual);
	}
}