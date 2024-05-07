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
	/// Asynchronously maps the result value of the <see cref="Result{T}"/> using the provided mapper function,
	/// or returns a default value if the result is not successful.
	/// </summary>
	/// <typeparam name="T">The type of the result value in the input <see cref="Result{T}"/>.</typeparam>
	/// <typeparam name="U">The type of the result value returned.</typeparam>
	/// <param name="self">The input <see cref="Result{T}"/> instance.</param>
	/// <param name="mapper">The asynchronous function used to map the result value.</param>
	/// <param name="defaultValue">The default value to return if the input <see cref="Result{T}"/> is not successful.</param>
	/// <returns>
	/// A <see cref="Task{U}"/> representing the asynchronous operation with the mapped result value
	/// if the input <see cref="Result{T}"/> is successful; otherwise, returns the specified default value.
	/// </returns>
	/// <remarks>
	/// If the input <see cref="Result{T}"/> is successful, the mapper function is applied to the result value,
	/// and the method returns the mapped value. If the input <see cref="Result{T}"/> is not successful,
	/// the method returns the specified default value.
	/// </remarks>
	public static async Task<U> MapOr<T, U>(this Result<T> self, Func<T, Task<U>> mapper, U defaultValue)
		=> self.IsSucceed
			? await mapper(self.Value)
			: defaultValue;

	/// <summary>
	/// Maps the value of the result to a new value using the specified mapper function,
	/// or returns a default value if the result is not successful.
	/// </summary>
	/// <typeparam name="T">The type of the value contained in the result.</typeparam>
	/// <typeparam name="U">The type of the mapped result value.</typeparam>
	/// <param name="self">The result object.</param>
	/// <param name="mapper">The function to map the value of the result.</param>
	/// <param name="predicate">The function that return a value based on the error if the result is not successful.</param>
	/// <returns>
	/// The mapped value if the result is successful; otherwise, the value based on the error object.
	/// </returns>
	public static U MapOrElse<T, U>(this Result<T> self, Func<T, U> mapper, Func<Error, U> predicate)
		=> self.IsSucceed
			? mapper(self.Value)
			: predicate(self.Error()!);
	
	/// <summary>
	/// Asynchronously maps the result value of the <see cref="Result{T}"/> using the provided mapper function,
	/// or computes a default value based on the error if the result is not successful.
	/// </summary>
	/// <typeparam name="T">The type of the result value in the input <see cref="Result{T}"/>.</typeparam>
	/// <typeparam name="U">The type of the result value returned.</typeparam>
	/// <param name="self">The input <see cref="Result{T}"/> instance.</param>
	/// <param name="mapper">The asynchronous function used to map the result value.</param>
	/// <param name="predicate">The function used to compute a default value based on the error.</param>
	/// <returns>
	/// A <see cref="Task{U}"/> representing the asynchronous operation with the mapped result value
	/// if the input <see cref="Result{T}"/> is successful; otherwise, returns the result of the predicate function applied to the error.
	/// </returns>
	/// <remarks>
	/// If the input <see cref="Result{T}"/> is successful, the mapper function is applied to the result value,
	/// and the method returns the mapped value. If the input <see cref="Result{T}"/> is not successful,
	/// the method returns the result of the predicate function applied to the error.
	/// </remarks>
	public static async Task<U> MapOrElseAsync<T, U>(this Result<T> self, Func<T, Task<U>> mapper, Func<Error, U> predicate)
		=> self.IsSucceed
			? await mapper(self.Value)
			: predicate(self.Error()!);
	
	/// <summary>
	/// Asynchronously maps the result value of the <see cref="Result{T}"/> using the provided mapper function,
	/// or computes a default value asynchronously based on the error if the result is not successful.
	/// </summary>
	/// <typeparam name="T">The type of the result value in the input <see cref="Result{T}"/>.</typeparam>
	/// <typeparam name="U">The type of the result value returned.</typeparam>
	/// <param name="self">The input <see cref="Result{T}"/> instance.</param>
	/// <param name="mapper">The asynchronous function used to map the result value.</param>
	/// <param name="predicate">The asynchronous function used to compute a default value based on the error.</param>
	/// <returns>
	/// A <see cref="Task{U}"/> representing the asynchronous operation with the mapped result value
	/// if the input <see cref="Result{T}"/> is successful; otherwise, returns the result of the predicate function applied to the error.
	/// </returns>
	/// <remarks>
	/// If the input <see cref="Result{T}"/> is successful, the mapper function is applied to the result value,
	/// and the method returns the mapped value. If the input <see cref="Result{T}"/> is not successful,
	/// the method returns the result of the predicate function applied to the error.
	/// </remarks>
	public static async Task<U> MapOrElseAsync<T, U>(this Result<T> self, Func<T, Task<U>> mapper, Func<Error, Task<U>> predicate)
		=> self.IsSucceed
			? await mapper(self.Value)
			: await predicate(self.Error()!);
}