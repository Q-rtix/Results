using Results.ResultTypes;

namespace Results.Extensions;

/// <summary>
/// Provides extension methods for the Check Result operations.
/// </summary>
public static class CheckResultExtensions
{
	/// <summary>
	/// Checks if the result is successful and satisfies the given condition.
	/// </summary>
	/// <typeparam name="TValue">The type of the value contained in case of successful result.</typeparam>
	/// <param name="self">The result object to check.</param>
	/// <param name="function">The condition function to apply on the result value.</param>
	/// <returns>True if the result is successful and satisfies the condition, otherwise false.</returns>
	public static bool IsSucceedAnd<TValue>(this Result<TValue> self, Func<TValue, bool> function)
		=> self.IsSucceed && function(self.Value);

	/// <summary>
	/// Checks if the result is faulted and satisfies the given condition.
	/// </summary>
	/// <param name="self">The Result object.</param>
	/// <param name="function">The function to check the error condition.</param>
	/// <returns>True if the Result object represents a failed operation and meets the specified condition; otherwise, false.</returns>
	public static bool IsFailedAnd(this Result self, Func<Error, bool> function) =>
		self.IsFaulted && function(self.Error()!);
}
