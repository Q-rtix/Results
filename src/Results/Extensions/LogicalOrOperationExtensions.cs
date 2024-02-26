using Results.ResultTypes;
// ReSharper disable InconsistentNaming

namespace Results.Extensions;

/// <summary>
/// Extensions for performing logical OR operations on <see cref="Result"/> and <see cref="Result{TValue}"/> objects.
/// </summary>
public static class LogicalOrOperationExtensions
{
	/// <summary>
	/// Performs a logical OR operation between two <see cref="Result"/> objects.
	/// </summary>
	/// <param name="self">The first <see cref="Result"/> object.</param>
	/// <param name="result">The second <see cref="Result"/> object.</param>
	/// <returns>
	/// A new <see cref="Result"/> object that is the result of the logical OR operation.
	/// If the first <see cref="Result"/> is faulted, the second <see cref="Result"/> is returned.
	/// Otherwise, a new <see cref="Ok"/> object is returned.
	/// </returns>
	/// <remarks>
	///		<code>
	///			Result x = new Ok();
	///			Result y = new Ok();
	///			Assert.Equal(x.Or(y), new Ok());
	///
	/// 
	///			Result x = new Ok();
	///			Result y = new Error("late error");
	///			Assert.Equal(x.Or(y), new Ok());
	/// 
	///			Result x = new Error("early error");
	///			Result y = new Ok();
	///			Assert.Equal(x.Or(y), new Ok());
	/// 
	///			Result x = new Error("early error");
	///			Result y = new Error("late error");
	///			Assert.Equal(x.Or(y), new Error("late error"));
	///		</code>
	/// </remarks>
	public static Result Or(this Result self, Result result)
		=> self.IsFaulted
			? result
			: new Ok();

	/// <summary>
	/// Performs a logical OR operation between <see cref="Result{TValue}"/> and <see cref="Result"/> objects.
	/// </summary>
	/// <typeparam name="T">The type of the value associated with this result and the result received as parameter.</typeparam>
	/// <param name="self">The first <see cref="Result"/> object.</param>
	/// <param name="result">The second <see cref="Result"/> object.</param>
	/// <returns>
	/// A new <see cref="Result"/> object that is the result of the logical OR operation.
	/// If the first <see cref="Result"/> is faulted, the second <see cref="Result"/> is returned.
	/// Otherwise, a new <see cref="Ok"/> object is returned.
	/// </returns>
	/// <remarks>
	///		<code>
	///			Result&lt;int&gt; x = new Ok(2);
	///			Result&lt;int&gt; y = new Ok(3);
	///			Assert.Equal(x.Or(y), new Ok(2));
	///
	/// 
	///			Result&lt;int&gt; x = new Ok(2);
	///			Result&lt;int&gt; y = new Error("late error");
	///			Assert.Equal(x.Or(y), new Ok(2));
	/// 
	///			Result&lt;int&gt; x = new Error("early error");
	///			Result&lt;int&gt; y = new Ok(3);
	///			Assert.Equal(x.Or(y), new Ok(3));
	/// 
	///			Result&lt;int&gt; x = new Error("early error");
	///			Result&lt;int&gt; y = new Error("late error");
	///			Assert.Equal(x.Or(y), new Error("late error"));
	///		</code>
	/// </remarks>
	public static Result<T> Or<T>(this Result<T> self, Result<T> result)
		=> self.IsFaulted
			? result
			: self;
}