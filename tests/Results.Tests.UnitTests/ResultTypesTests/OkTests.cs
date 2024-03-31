using Results.ResultTypes;

namespace Results.Tests.UnitTests.ResultTypesTests;

public class OkTests
{
	[Fact]
	public void Ok_Constructor_ShouldCreateAnInstanceWithSuccessfulResult()
	{
		// Act
		var result = new Ok();
		
		// Assert
		Assert.True(result.IsSucceed);
	}

	[Fact]
	public void Ok_ToString_ShouldReturnCorrectString()
	{
		// Act
		var result = new Ok();
		
		// Assert
		Assert.Equal(string.Empty, result.ToString());
	}
}