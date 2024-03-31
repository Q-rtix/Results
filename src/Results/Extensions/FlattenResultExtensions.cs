using Results.ResultTypes;

namespace Results.Extensions;

/// <summary>
/// Extensions for flattening Result objects.
/// </summary>
public static class FlattenResultExtensions
{
	/// <summary>
	/// Flattens a nested result by returning the inner result if it is successful,
	/// otherwise constructs a new error result using the errors from the outer result.
	/// </summary>
	/// <param name="self">The nested result to flatten.</param>
	/// <returns>
	/// The inner result if it is successful,
	/// otherwise a new error result with the errors from the outer result.
	/// </returns>
	public static Result Flatten(this Result<Result> self)
		=> self.IsSucceed
			? self.Value
			: new Error(self.Errors);

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
			: new Error(self.Errors);
}