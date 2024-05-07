using Results.ResultTypes;
using Results.WellKnownErrors;

namespace Results.Extensions;

/// <summary>
/// Extensions for ensuring that a <see cref="Results.Result{TValue}"/> satisfies a given predicate.
/// </summary>
public static class EnsureResultOfTExtensions
{
	/// <summary>
	/// Ensures that the result satisfies a given predicate. If the result is already faulted, it returns the original result. 
	/// Otherwise, it evaluates the predicate with the value of the result. 
	/// If the predicate evaluates to true, the original result is returned; otherwise, a new result with the specified error is returned.
	/// </summary>
	/// <typeparam name="T">The type of the result value.</typeparam>
	/// <param name="self">The original result to be validated.</param>
	/// <param name="predicate">A function that defines the condition to be checked against the result value.</param>
	/// <param name="error">The error to be used if the predicate evaluates to false.</param>
	/// <returns>The original result if the predicate is satisfied, otherwise a new result containing the specified error.</returns>
	public static Result<T> Ensure<T>(this Result<T> self, Func<T, bool> predicate, Error error)
	{
		if (self.IsFaulted)
			return self;

		return predicate(self.Value)
			? self
			: new Result<T>(error);
	}

	/// <summary>
	/// Ensures that the result satisfies a given predicate. If the result is already faulted, it returns the original result. 
	/// Otherwise, it evaluates the predicate with the value of the result. 
	/// If the predicate evaluates to true, the original result is returned; otherwise, a new result with the specified errors is returned.
	/// </summary>
	/// <typeparam name="T">The type of the result value.</typeparam>
	/// <param name="self">The original result to be validated.</param>
	/// <param name="predicate">A function that defines the condition to be checked against the result value.</param>
	/// <param name="errors">The error messages or objects to be used if the predicate evaluates to false.</param>
	/// <returns>The original result if the predicate is satisfied, otherwise a new result containing the specified errors.</returns>
	public static Result<T> Ensure<T>(this Result<T> self, Func<T, bool> predicate, params object[] errors)
		=> self.Ensure(predicate, new Error(errors));
}