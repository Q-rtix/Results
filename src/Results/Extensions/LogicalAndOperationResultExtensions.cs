using Results.ResultTypes;
// ReSharper disable InconsistentNaming

namespace Results.Extensions;

/// <summary>
/// Extensions for performing logical AND operations on <see cref="Results.Result{TValue}"/> objects.
/// </summary>
public static class LogicalAndOperationResultExtensions
{
	/// <summary>
	/// Performs a logical AND operation between <see cref="Results.Result{TValue}"/> objects.
	/// </summary>
	/// <typeparam name="T">The type of the value associated with the self result.</typeparam>
	/// <typeparam name="U">The type of the value associated with the result received as parameter.</typeparam>
	/// <param name="self">The first result to combine.</param>
	/// <param name="result">The other result to combine with this result.</param>
	/// <returns>A new instance of <see cref="Result{TValue}"/> representing a successful result if both results are successful;
	/// otherwise, returns a new instance representing an error result with the error value from this result.</returns>
	/// <remarks>
	///		<code>
	///			Result&lt;int&gt; x = new Ok(1);
	///			Result&lt;int&gt; y = new Error("late error");
	///			Assert.Equal(x.And(y), new Error("late error"));
	///
	/// 
	///			Result&lt;int&gt; x = new Ok(1);
	///			Result&lt;int&gt; y = new Ok(3);
	///			Assert.Equal(x.And(y), new Ok(3));
	/// 
	///			Result&lt;int&gt; x = new Error("early error");
	///			Result&lt;int&gt; y = new Error("late error");
	///			Assert.Equal(x.And(y), new Error("early error"));
	///	
	///			Result&lt;int&gt; x = new Error("early error");
	///			Result&lt;int&gt; y = new Ok(3);
	///			Assert.Equal(x.And(y), new Error("early error"));
	///		</code>
	/// </remarks>
	public static Result<U> And<T, U>(this Result<T> self, Result<U> result)
		=> self.IsSucceed
			? result
			: new Error(self.Errors);
}