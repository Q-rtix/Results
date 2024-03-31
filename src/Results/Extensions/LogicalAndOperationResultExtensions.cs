using Results.ResultTypes;
// ReSharper disable InconsistentNaming

namespace Results.Extensions;

/// <summary>
/// Extensions for performing logical AND operations on <see cref="Result"/> and <see cref="Result{TValue}"/> objects.
/// </summary>
public static class LogicalAndOperationResultExtensions
{
	/// <summary>
	/// Performs a logical AND operation between two <see cref="Result"/> objects.
	/// </summary>
	/// <param name="self">The first result to combine.</param>
	/// <param name="result">The other result to combine with this result.</param>
	/// <returns>A new instance of <see cref="Result"/> representing a successful result if both results are successful;
	/// otherwise, returns a new instance representing an error result with the error value from this result.</returns>
	/// <remarks>
	///		<code>
	///			Result x = new Ok();
	///			Result y = new Error("late error");
	///			Assert.Equal(x.And(y), new Error("late error"));
	/// 
	///			Result x = new Ok();
	///			Result y = new Ok();
	///			Assert.Equal(x.And(y), new Ok());
	///
	/// 
	///			Result x = new Error("early error");
	///			Result y = new Error("late error");
	///			Assert.Equal(x.And(y), new Error("early error"));
	/// 
	///			Result x = new Error("early error");
	///			Result y = new Ok();
	///			Assert.Equal(x.And(y), new Error("early error"));
	///		</code>
	/// </remarks>
	public static Result And(this Result self, Result result)
		=> self.IsSucceed
			? result
			: new Error(self.Errors);

	/// <summary>
	/// Performs a logical AND operation between <see cref="Result"/> and <see cref="Result{TValue}"/> objects.
	/// </summary>
	/// <typeparam name="T">The type of the value associated with the result received as parameter.</typeparam>
	/// <param name="self">The first result to combine.</param>
	/// <param name="result">The other result to combine with this result.</param>
	/// <returns>A new instance of <see cref="Result"/> representing a successful result if both results are successful;
	/// otherwise, returns a new instance representing an error result with the error value from this result.</returns>
	/// <remarks>
	///		<code>
	///			Result x = new Ok();
	///			Result&lt;int&gt; y = new Error("late error");
	///			Assert.Equal(x.And(y), new Error("late error"));
	///
	/// 
	///			Result x = new Ok();
	///			Result&lt;int&gt; y = new Ok(3);
	///			Assert.Equal(x.And(y), new Ok(3));
	/// 
	///			Result x = new Error("early error");
	///			Result&lt;int&gt; y = new Error("late error");
	///			Assert.Equal(x.And(y), new Error("early error"));
	///	
	///			Result x = new Error("early error");
	///			Result&lt;int&gt; y = new Ok(3);
	///			Assert.Equal(x.And(y), new Error("early error"));
	///		</code>
	/// </remarks>
	public static Result<T> And<T>(this Result self, Result<T> result)
		=> self.IsSucceed
			? result
			: new Error(self.Errors);
}