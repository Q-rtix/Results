using JetBrains.Annotations;
using Results.Extensions;
using Results.ResultTypes;
using Results.WellKnownErrors;

using static Results.ResultFactory;

namespace Results.Tests.UnitTests.Extensions;

[TestSubject(typeof(EnsureResultOfTExtensions))]
public class EnsureResultOfTExtensionsTest
{

	[Fact]
	public void Ensure_WhenSelfResultIsFaulted_ReturnsSelf()
	{
		// Act
		var result = Error<int>(WellKnownError.NullValue)
			.Ensure(x => x > 0, new Error("Less than zero"));

		// Assert
		Assert.True(result.IsFaulted);
		Assert.Equal([WellKnownError.NullValue], result.Errors);
	}

	[Fact]
	public void Ensure_WhenSelfResultIsSucceedAndPredicateIsTrue_ReturnsSelf()
	{
		// Act
		var result = Ok(1)
			.Ensure(x => x > 0, new Error("Less than zero"));

		// Assert
		Assert.True(result.IsSucceed);
		Assert.Equal(1, result.Value);
	}

	[Fact]
	public void Ensure_WhenSelfResultIsSucceedAndPredicateIsFalse_ReturnsError()
	{
		// Act
		var result = Ok(-1)
			.Ensure(x => x > 0, new Error("Less than zero"));

		// Assert
		Assert.True(result.IsFaulted);
		Assert.Equal(["Less than zero"], result.Errors);
	}

	[Fact]
	public void Ensure_UsingParams()
	{
		// Act
		var result = Ok(-1)
			.Ensure(x => x > 0, "Less than zero");

		// Assert
		Assert.True(result.IsFaulted);
		Assert.Equal(["Less than zero"], result.Errors);
	}
}