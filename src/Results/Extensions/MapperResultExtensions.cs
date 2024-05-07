using Results.ResultTypes;

// ReSharper disable InconsistentNaming

namespace Results.Extensions;

/// <summary>
/// Extension methods for mapping <see cref="Result{TValue}"/> objectes with different value.
/// </summary>
public static class MapperResultExtensions
{
	/// <summary>
	/// Maps a <see cref="Result{T}"/> object to a new <see cref="Result{U}"/> with a different value using the specified mapper function.
	/// </summary>
	/// <typeparam name="T">The type of value contained in the input result.</typeparam>
	/// <typeparam name="U">The type of value contained in the output result.</typeparam>
	/// <param name="self">The input result object.</param>
	/// <param name="mapper">The function that maps the input value to the output value.</param>
	/// <returns>
	/// A new <see cref="Result{U}"/> object with the mapped value if the input <see cref="Result{T}"/> is succeeded;
	/// otherwise, returns a new <see cref="Result{U}"/> object with the error of the <see cref="Result{T}"/> input object.
	/// </returns>
	public static Result<U> Map<T, U>(this Result<T> self, Func<T, U> mapper)
		=> self.IsSucceed
			? new Ok<U>(mapper(self.Value))
			: new Error(self.Errors);

	/// <summary>
	/// Asynchronously maps the result value of the <see cref="Result{T}"/> using the provided mapper function.
	/// </summary>
	/// <typeparam name="T">The type of the result value in the input <see cref="Result{T}"/>.</typeparam>
	/// <typeparam name="U">The type of the result value in the output <see cref="Result{U}"/>.</typeparam>
	/// <param name="self">The input <see cref="Result{T}"/> instance.</param>
	/// <param name="mapper">The asynchronous function used to map the result value.</param>
	/// <returns>
	/// A <see cref="Task{TResult}"/> where the result is a <see cref="Result{U}"/> representing the asynchronous operation with the mapped result value.
	/// </returns>
	/// <remarks>
	/// If the input <see cref="Result{T}"/> is successful, the mapper function is applied to the result value,
	/// and the method returns a new successful <see cref="Result{U}"/> with the mapped value. If the input
	/// <see cref="Result{T}"/> is not successful, the method returns a new <see cref="Error"/> with the same errors.
	/// </remarks>
	public static async Task<Result<U>> MapAsync<T, U>(this Result<T> self, Func<T, Task<U>> mapper)
		=> self.IsSucceed
			? new Ok<U>(await mapper(self.Value))
			: new Error(self.Errors);
	
}