using Results.Extensions;
using Results.ResultTypes;

namespace Results.Tests.UnitTests.Extensions;

public class MapperResultExtensionsTests
{
    [Fact]
    public void MapWithNonGeneric_ShouldReturnMappedResult_WhenPriorResultIsSucceed()
    {
        // Arrange
        Result firstResult = new Ok();

        // Act
        var actual = firstResult.Map(() => "Mapped to string");

        // Assert
        Assert.Equal(typeof(Ok<string>), actual.ResultType);
        Assert.Equal("Mapped to string", actual.Value);
    }

    [Fact]
    public void MapWithNonGeneric_ShouldReturnFirstResult_WhenPriorResultIsFailed()
    {
        // Arrange
        Result firstResult = new Error("Error from first result");

        // Act
        var actual = firstResult.Map(() => "Mapped to string");

        // Assert
        Assert.Equal(typeof(Error), actual.ResultType);
        Assert.Equal(["Error from first result"], actual.Errors);
    }

    [Fact]
    public void MapWithGeneric_ShouldReturnMappedResult_WhenPriorResultIsSucceed()
    {
        // Arrange
        Result<int> firstResult = new Ok<int>(5);

        // Act
        var actual = firstResult.Map(i => $"Mapped to string: {i}");

        // Assert
        Assert.Equal(typeof(Ok<string>), actual.ResultType);
        Assert.Equal("Mapped to string: 5", actual.Value);
    }

    [Fact]
    public void MapWithGeneric_ShouldReturnFirstResult_WhenPriorResultIsFailed()
    {
        // Arrange
        Result<int> firstResult = new Error("Error from first result");

        // Act
        var actual = firstResult.Map(i => $"Mapped to string: {i}");

        // Assert
        Assert.Equal(typeof(Error), actual.ResultType);
        Assert.Equal("Error: Error from first result", actual.ToString());
    }

    [Fact]
    public void MapError_ShouldReturnMappedError_WhenResultIsFailed()
    {
        // Arrange
        Result initialResult = new Error("Error from initial result");

        // Act
        var actual = initialResult.MapError(error => new Error($"Mapped error: {error}"));

        // Assert
        Assert.Equal("Error: Mapped error: Error from initial result", actual.ToString());
    }

    [Fact]
    public void MapError_ShouldReturnInitialOkResult_WhenResultIsSucceed()
    {
        // Arrange
        Result initialResult = new Ok();

        // Act
        var actual = initialResult.MapError(error => new Error($"Mapped error: {error.Errors}"));

        // Assert
        Assert.Equal(typeof(Ok), actual.ResultType);
    }

    [Fact]
    public void MapErrorWithGeneric_ShouldReturnMappedError_WhenResultIsFailed()
    {
        // Arrange
        Result<string> initialResult = new Error("Error from initial result");

        // Act
        var actual = initialResult.MapError(error => new Error($"Mapped error: {error}"));

        // Assert
        Assert.Equal(typeof(Error), actual.ResultType);
        Assert.Equal("Error: Mapped error: Error from initial result", actual.ToString());
    }

    [Fact]
    public void MapErrorWithGeneric_ShouldReturnInitialOkResult_WhenResultIsSucceed()
    {
        // Arrange
        Result<string> initialResult = new Ok<string>("Success from initial result");

        // Act
        var actual = initialResult.MapError(error => new Error($"Mapped error: {error}"));

        // Assert
        Assert.Equal(typeof(Ok<string>), actual.ResultType);
        Assert.Equal("Success from initial result", actual.Value);
    }
}