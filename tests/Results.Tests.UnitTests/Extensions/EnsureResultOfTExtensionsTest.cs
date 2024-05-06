using JetBrains.Annotations;
using Results.Extensions;
using Results.ResultTypes;
using Results.WellKnownErrors;

namespace Results.Tests.UnitTests.Extensions;

[TestSubject(typeof(EnsureResultOfTExtensions))]
public class EnsureResultOfTExtensionsTest
{

	[Fact]
	public void Ensure_WhenSelfResultIsFaulted_ReturnsSelf()
	{
		// Act
		var result = ResultFactory.Create<int>()
			.Ensure(x => x > 0, new Error("Less than zero"));
		
		// Assert
		Assert.True(result.IsFaulted);
		Assert.Equal([WellKnownError.NullValue], result.Errors);
	}

	[Fact]
	public void Ensure_WhenSelfResultIsSucceedAndPredicateIsTrue_ReturnsSelf()
	{
		// Act
		var result = ResultFactory.Create<int>(1)
			.Ensure(x => x > 0, new Error("Less than zero"));
		
		// Assert
		Assert.True(result.IsSucceed);
		Assert.Equal(1, result.Value);
	}

	[Fact]
	public void Ensure_WhenSelfResultIsSucceedAndPredicateIsFalse_ReturnsError()
	{
		// Act
		var result = ResultFactory.Create<int>(-1)
			.Ensure(x => x > 0, new Error("Less than zero"));
		
		// Assert
		Assert.True(result.IsFaulted);
		Assert.Equal(["Less than zero"], result.Errors);
	}

	[Fact]
	public void Ensure_UsingParams()
	{
		// Act
		var result = ResultFactory.Create<int>(-1)
			.Ensure(x => x > 0, "Less than zero");
		
		// Assert
		Assert.True(result.IsFaulted);
		Assert.Equal(["Less than zero"], result.Errors);
	}
}