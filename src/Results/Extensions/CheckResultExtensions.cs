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
	/// <param name="predicate">The condition function to apply on the result value.</param>
	/// <returns>True if the result is successful and satisfies the condition, otherwise false.</returns>
	public static bool IsSucceedAnd<TValue>(this Result<TValue> self, Func<TValue, bool> predicate)
		=> self.IsSucceed && predicate(self.Value);
	
	/// <summary>
	/// Checks if the result is failed and satisfies the given condition.
	/// </summary>
	/// <typeparam name="TValue">The type of the value contained in case of successful result.</typeparam>
	/// <param name="self">The result object to check.</param>
	/// <param name="predicate">The condition function to apply on the result value.</param>
	/// <returns>True if the result is failed and satisfies the condition, otherwise false.</returns>
	public static bool IsFaultedAnd<TValue>(this Result<TValue> self, Func<Error, bool> predicate)
		=> self.IsFaulted && predicate(self.Error()!);
}
