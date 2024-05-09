using Results.Extensions;
using Results.ResultTypes;
using static Results.ResultFactory;

namespace Results.Tests.UnitTests.Extensions;

public class LogicalOrOperationExtensionsTests
{
    [Fact]
    public void Or_ShouldReturnFirstResult_WhenBothResultsAreSucceed()
    {
        // Arrange
        var firstResult = Ok();
        var secondResult = Ok();

        // Act
        var actual = firstResult.Or(secondResult);

        // Assert
        Assert.Equal(typeof(Ok<Empty>), actual.ResultType);
    }

    [Fact]
    public void Or_ShouldReturnSecondResult_WhenFirstResultIsFailed_And_SecondResultIsSucceed()
    {
        // Arrange
        var firstResult = Error("Error from first result");
        var secondResult = Ok();

        // Act
        var actual = firstResult.Or(secondResult);

        // Assert
        Assert.Equal(typeof(Ok<Empty>), actual.ResultType);
    }

    [Fact]
    public void Or_ShouldReturnFirstResult_WhenFirstResultIsSucceed_And_SecondResultIsFailed()
    {
        // Arrange
        var firstResult = Ok();
        var secondResult = Error("Error from second result");

        // Act
        var actual = firstResult.Or(secondResult);

        // Assert
        Assert.Equal(typeof(Ok<Empty>), actual.ResultType);
    }

    [Fact]
    public void Or_ShouldReturnSecondResult_WhenBothResultsAreFailed()
    {
        // Arrange
        var firstResult = Error("Error from first result");
        var secondResult = Error("Error from second result");

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
        var firstResult = Ok<string>("Success from first result");
        var secondResult = Ok<string>("Success from second result");

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
        var firstResult = Error<string>("Error from first result");
        var secondResult = Ok<string>("Success from second result");

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
        var firstResult = Ok<string>("Success from first result");
        var secondResult = Error<string>("Error from second result");

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
        var firstResult = Error("Error from first result");
        var secondResult = Error("Error from second result");

        // Act
        var actual = firstResult.Or(secondResult);

        // Assert
        Assert.Equal(typeof(Error), actual.ResultType);
        Assert.Equal(["Error from second result"], actual.Errors);
    }
}