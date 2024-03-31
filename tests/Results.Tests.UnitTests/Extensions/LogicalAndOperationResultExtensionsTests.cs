using Results.Extensions;
using Results.ResultTypes;

namespace Results.Tests.UnitTests.Extensions;

public class LogicalAndOperationResultExtensionsTests
{
    [Fact]
    public void And_ShouldReturnSecondResult_WhenBothResultsAreSucceed()
    {
        // Arrange
        Result firstResult = new Ok();
        Result secondResult = new Ok();

        // Act
        var actual = firstResult.And(secondResult);

        // Assert
        Assert.Equal(typeof(Ok), actual.ResultType);
    }

    [Fact]
    public void And_ShouldReturnSecondResult_WhenFirstResultIsSucceed_And_SecondResultIsFailed()
    {
        // Arrange
        Result firstResult = new Ok();
        Result secondResult = new Error("Error from second result");

        // Act
        var actual = firstResult.And(secondResult);

        // Assert
        Assert.Equal(typeof(Error), actual.ResultType);
        Assert.Equal(["Error from second result"], actual.Errors);
    }

    [Fact]
    public void And_ShouldReturnFirstResult_WhenFirstResultIsFailed_And_SecondResultIsSucceed()
    {
        // Arrange
        Result firstResult = new Error("Error from first result");
        Result secondResult = new Ok();

        // Act
        var actual = firstResult.And(secondResult);

        // Assert
        Assert.Equal(typeof(Error), actual.ResultType);
        Assert.Equal(["Error from first result"], actual.Errors);
    }

    [Fact]
    public void And_ShouldReturnFirstResult_WhenBothResultsAreFailed()
    {
        // Arrange
        Result firstResult = new Error("Error from first result");
        Result secondResult = new Error("Error from second result");

        // Act
        var actual = firstResult.And(secondResult);

        // Assert
        Assert.Equal(typeof(Error), actual.ResultType);
        Assert.Equal(["Error from first result"], actual.Errors);
    }

    [Fact]
    public void AndWithGenericResult_ShouldReturnSecondResult_WhenBothResultsAreSucceed()
    {
        // Arrange
        Result firstResult = new Ok();
        Result<string> secondResult = new Ok<string>("Success");

        // Act
        var actual = firstResult.And(secondResult);

        // Assert
        Assert.Equal(typeof(Ok<string>), actual.ResultType);
        Assert.Equal("Success", actual.Value);
    }

    [Fact]
    public void AndWithGenericResult_ShouldReturnSecondResult_WhenFirstResultIsSucceed_And_SecondResultIsFailed()
    {
        // Arrange
        Result firstResult = new Ok();
        Result<string> secondResult = new Error("Error from second result");

        // Act
        var actual = firstResult.And(secondResult);

        // Assert
        Assert.Equal(typeof(Error), actual.ResultType);
        Assert.Equal(["Error from second result"], actual.Errors);
    }

    [Fact]
    public void AndWithGenericResult_ShouldReturnFirstResult_WhenFirstResultIsFailed_And_SecondResultIsSucceed()
    {
        // Arrange
        Result firstResult = new Error("Error from first result");
        Result<string> secondResult = new Ok<string>("Success");

        // Act
        var actual = firstResult.And(secondResult);

        // Assert
        Assert.Equal(typeof(Error), actual.ResultType);
        Assert.Equal(["Error from first result"], actual.Errors);
    }

    [Fact]
    public void AndWithGenericResult_ShouldReturnFirstResult_WhenBothResultsAreFailed()
    {
        // Arrange
        Result firstResult = new Error("Error from first result");
        Result<string> secondResult = new Error("Error from second result");

        // Act
        var actual = firstResult.And(secondResult);

        // Assert
        Assert.Equal(typeof(Error), actual.ResultType);
        Assert.Equal(["Error from first result"], actual.Errors);
    }
}
