using static Results.ResultFactory;
// ReSharper disable InconsistentNaming

namespace Results.Extensions;

/// <summary>
/// Extensions for performing logical operations on <see cref="Result{TValue}"/> objects.
/// </summary>
public static class LogicalOperationResultExtensions
{
	/// <summary>
	/// Performs a logical AND operation between <see cref="Result{TValue}"/> objects.
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
			: Error<U>(self.Error()!, self.StatusCode);
	
	/// <summary>
	/// Performs a logical OR operation between <see cref="Result{TValue}"/> objects.
	/// </summary>
	/// <typeparam name="T">The type of the value associated with this result and the result received as parameter.</typeparam>
	/// <param name="self">The first <see cref="Result{TValue}"/> object.</param>
	/// <param name="result">The second <see cref="Result{TValue}"/> object.</param>
	/// <returns>
	/// A new <see cref="Result{TValue}"/> object that is the result of the logical OR operation.
	/// If the first <see cref="Result{TValue}"/> is faulted, the second <see cref="Result{TValue}"/> is returned.
	/// Otherwise, the first <see cref="Result{TValue}"/> object is returned.
	/// </returns>
	/// <remarks>
	///		<code>
	///			Result&lt;int&gt; x = new Ok(2);
	///			Result&lt;int&gt; y = new Ok(3);
	///			Assert.Equal(x.Or(y), x);
	///
	/// 
	///			Result&lt;int&gt; x = new Ok(2);
	///			Result&lt;int&gt; y = new Error("late error");
	///			Assert.Equal(x.Or(y), x);
	/// 
	///			Result&lt;int&gt; x = new Error("early error");
	///			Result&lt;int&gt; y = new Ok(3);
	///			Assert.Equal(x.Or(y), y);
	/// 
	///			Result&lt;int&gt; x = new Error("early error");
	///			Result&lt;int&gt; y = new Error("late error");
	///			Assert.Equal(x.Or(y), y);
	///		</code>
	/// </remarks>
	public static Result<T> Or<T>(this Result<T> self, Result<T> result)
		=> self.IsFaulted
			? result
			: self;
}