using static Results.ResultFactory;

namespace Results.Extensions;

/// <summary>
/// Extensions for flattening <see cref="Result{TValue}"/> objects.
/// </summary>
public static class FlattenResultExtensions
{
	/// <summary>
	/// Flattens a nested result by extracting the inner result if the outer result is successful,
	/// or creates a new error result containing the errors from the outer result.
	/// </summary>
	/// <typeparam name="T">The type of value contained in the inner result.</typeparam>
	/// <param name="self">The nested result to flatten.</param>
	/// <returns>
	/// The inner result if the outer result is successful,
	/// or a new error result containing the errors from the outer result.
	/// </returns>
	public static Result<T> Flatten<T>(this Result<Result<T>> self)
		=> self.IsSucceed
			? self.Value
			: Error<T>(self.Error()!, self.StatusCode);
}