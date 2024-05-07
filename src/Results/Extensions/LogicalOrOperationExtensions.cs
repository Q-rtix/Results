using Results.ResultTypes;
// ReSharper disable InconsistentNaming

namespace Results.Extensions;

/// <summary>
/// Extensions for performing logical OR operations on <see cref="Result{TValue}"/> objects.
/// </summary>
public static class LogicalOrOperationExtensions
{
	/// <summary>
	/// Performs a logical OR operation between <see cref="Results.Result{TValue}"/> objects.
	/// </summary>
	/// <typeparam name="T">The type of the value associated with this result and the result received as parameter.</typeparam>
	/// <param name="self">The first <see cref="Result{T}"/> object.</param>
	/// <param name="result">The second <see cref="Result{T}"/> object.</param>
	/// <returns>
	/// A new <see cref="Result{T}"/> object that is the result of the logical OR operation.
	/// If the first <see cref="Result{T}"/> is faulted, the second <see cref="Result{T}"/> is returned.
	/// Otherwise, the first <see cref="Result{T}"/> object is returned.
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