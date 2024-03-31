using Results.Extensions;
using Results.ResultTypes;

namespace Results.Tests.UnitTests.Extensions;

public class LogicalOrOperationExtensionsTests
{
    [Fact]
    public void Or_ShouldReturnFirstResult_WhenBothResultsAreSucceed()
    {
        // Arrange
        Result firstResult = new Ok();
        Result secondResult = new Ok();

        // Act
        var actual = firstResult.Or(secondResult);

        // Assert
        Assert.Equal(typeof(Ok), actual.ResultType);
    }

    [Fact]
    public void Or_ShouldReturnSecondResult_WhenFirstResultIsFailed_And_SecondResultIsSucceed()
    {
        // Arrange
        Result firstResult = new Error("Error from first result");
        Result secondResult = new Ok();

        // Act
        var actual = firstResult.Or(secondResult);

        // Assert
        Assert.Equal(typeof(Ok), actual.ResultType);
    }

    [Fact]
    public void Or_ShouldReturnFirstResult_WhenFirstResultIsSucceed_And_SecondResultIsFailed()
    {
        // Arrange
        Result firstResult = new Ok();
        Result secondResult = new Error("Error from second result");

        // Act
        var actual = firstResult.Or(secondResult);

        // Assert
        Assert.Equal(typeof(Ok), actual.ResultType);
    }

    [Fact]
    public void Or_ShouldReturnSecondResult_WhenBothResultsAreFailed()
    {
        // Arrange
        Result firstResult = new Error("Error from first result");
        Result secondResult = new Error("Error from second result");

        // Act
        var actual = firstResult.Or(secondResult);

        // Assert
        Assert.Equal(typeof(Error), actual.ResultType);
        Assert.Equal(["Error from second result"], actual.Errors);
    }

    [Fact]
    public void OrWithGeneric_ShouldReturnFirstResult_WhenBothResultsAreSucceed()
    {
        // Arrange
        Result<string> firstResult = new Ok<string>("Success from first result");
        Result<string> secondResult = new Ok<string>("Success from second result");

        // Act
        var actual = firstResult.Or(secondResult);

        // Assert
        Assert.Equal(typeof(Ok<string>), actual.ResultType);
        Assert.Equal("Success from first result", actual.Value);
    }

    [Fact]
    public void OrWithGeneric_ShouldReturnSecondResult_WhenFirstResultIsFailed_And_SecondResultIsSucceed()
    {
        // Arrange
        Result<string> firstResult = new Error("Error from first result");
        Result<string> secondResult = new Ok<string>("Success from second result");

        // Act
        var actual = firstResult.Or(secondResult);

        // Assert
        Assert.Equal(typeof(Ok<string>), actual.ResultType);
        Assert.Equal("Success from second result", actual.Value);
    }

    [Fact]
    public void OrWithGeneric_ShouldReturnFirstResult_WhenFirstResultIsSucceed_And_SecondResultIsFailed()
    {
        // Arrange
        Result<string> firstResult = new Ok<string>("Success from first result");
        Result<string> secondResult = new Error("Error from second result");

        // Act
        var actual = firstResult.Or(secondResult);

        // Assert
        Assert.Equal(typeof(Ok<string>), actual.ResultType);
        Assert.Equal("Success from first result", actual.Value);
    }

    [Fact]
    public void OrWithGeneric_ShouldReturnSecondResult_WhenBothResultsAreFailed()
    {
        // Arrange
        Result<string> firstResult = new Error("Error from first result");
        Result<string> secondResult = new Error("Error from second result");

        // Act
        var actual = firstResult.Or(secondResult);

        // Assert
        Assert.Equal(typeof(Error), actual.ResultType);
        Assert.Equal(["Error from second result"], actual.Errors);
    }
}