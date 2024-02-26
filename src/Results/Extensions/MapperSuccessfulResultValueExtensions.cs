// ReSharper disable InconsistentNaming

using Results.ResultTypes;

namespace Results.Extensions;

/// <summary>
/// Contains extension methods for the <see cref="Result{TValue}"/> class that deal with mapping successful results.
/// </summary>
public static class MapperSuccessfulResultValueExtensions
{
	/// <summary>
	/// Maps the successful result value to a new value using the provided mapper function, or returns a default value if the result is a failure.
	/// </summary>
	/// <typeparam name="T">The type of the value contained in the result.</typeparam>
	/// <typeparam name="U">The type of the mapped result value.</typeparam>
	/// <param name="self">The result instance.</param>
	/// <param name="mapper">The mapper function to convert the successful result value.</param>
	/// <param name="defaultValue">The default value to be returned if the result is a failure.</param>
	/// <returns>The mapped value if the result is successful; otherwise, the default value.</returns>
	public static U MapOr<T, U>(this Result<T> self, Func<T, U> mapper, U defaultValue)
		=> self.IsSucceed
			? mapper(self.Value)
			: defaultValue;

	/// <summary>
	/// Maps the value of the result to a new value using the specified mapper function,
	/// or returns a default value if the result is not successful.
	/// </summary>
	/// <typeparam name="T">The type of the value contained in the result.</typeparam>
	/// <typeparam name="U">The type of the mapped result value.</typeparam>
	/// <param name="self">The result object.</param>
	/// <param name="mapper">The function to map the value of the result.</param>
	/// <param name="function">The function that return a value based on the error if the result is not successful.</param>
	/// <returns>
	/// The mapped value if the result is successful; otherwise, the value based on the error object.
	/// </returns>
	public static U MapOrElse<T, U>(this Result<T> self, Func<T, U> mapper, Func<Error, U> function)
		=> self.IsSucceed
			? mapper(self.Value)
			: function(self.Error()!);
}