using Results.Extensions;
using Results.ResultTypes;
using static Results.ResultFactory;

namespace Results.Tests.UnitTests.Extensions;

public class LogicalAndOperationResultExtensionsTests
{
    [Fact]
    public void And_ShouldReturnSecondResult_WhenBothResultsAreSucceed()
    {
        // Arrange
        Result<Empty> firstResult = Ok();
        Result<string> secondResult = Ok<string>("Success");

        // Act
        var actual = firstResult.And(secondResult);

        // Assert
        Assert.Equal(typeof(Ok<string>), actual.ResultType);
        Assert.Equal("Success", actual.Value);
    }

    [Fact]
    public void And_ShouldReturnSecondResult_WhenFirstResultIsSucceed_And_SecondResultIsFailed()
    {
        // Arrange
        Result<Empty> firstResult = Ok();
        Result<string> secondResult = Error<string>("Error from second result");

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
        Result<Empty> firstResult = Error("Error from first result");
        Result<string> secondResult = Ok<string>("Success");

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
        Result<Empty> firstResult = Error("Error from first result");
        Result<Empty> secondResult = Error("Error from second result");

        // Act
        var actual = firstResult.And(secondResult);

        // Assert
        Assert.Equal(typeof(Error), actual.ResultType);
        Assert.Equal(["Error from first result"], actual.Errors);
    }
}
