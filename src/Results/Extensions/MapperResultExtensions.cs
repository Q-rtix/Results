using Results.ResultTypes;

// ReSharper disable InconsistentNaming

namespace Results.Extensions;

/// <summary>
/// Extension methods for mapping <see cref="Result{TValue}"/> and <see cref="Result"/> objectes with different value.
/// </summary>
public static class MapperResultExtensions
{
	/// <summary>
	/// Maps a <see cref="Result"/> object to a new <see cref="Result{TValue}"/> with a value using the specified mapper function.
	/// </summary>
	/// <typeparam name="T">The type of the new value.</typeparam>
	/// <param name="self">The result to map.</param>
	/// <param name="mapper">The mapper function to apply to the value of the result.</param>
	/// <returns>
	/// A new <see cref="Result{TValue}"/> object with the mapped value if the input <see cref="Result"/> is succeed;
	/// otherwise, returns a new <see cref="Result{TValue}"/> object with the error of the <see cref="Result"/> input object.
	/// </returns>
	public static Result<T> Map<T>(this Result self, Func<T> mapper)
		=> self.IsSucceed
			? new Ok<T>(mapper())
			: new Error(self.Errors);

	/// <summary>
	/// Maps a <see cref="Result{TValue}"/> object to a new <see cref="Result{TValue}"/> with a different value using the specified mapper function.
	/// </summary>
	/// <typeparam name="T">The type of value contained in the input result.</typeparam>
	/// <typeparam name="U">The type of value contained in the output result.</typeparam>
	/// <param name="self">The input result object.</param>
	/// <param name="mapper">The function that maps the input value to the output value.</param>
	/// <returns>
	/// A new <see cref="Result{TValue}"/> object with the mapped value if the input <see cref="Result{TValue}"/> is succeed;
	/// otherwise, returns a new <see cref="Result{TValue}"/> object with the error of the <see cref="Result{TValue}"/> input object.
	/// </returns>
	public static Result<U> Map<T, U>(this Result<T> self, Func<T, U> mapper)
		=> self.IsSucceed
			? new Ok<U>(mapper(self.Value))
			: new Error(self.Errors);

	/// <summary>
	/// Maps the error of a <see cref="Result"/> or a <see cref="Result{TValue}"/> object to a new <see cref="Result"/> using the specified mapper function.
	/// </summary>
	/// <param name="self">The input result object.</param>
	/// <param name="mapper">The mapper function that transforms the error.</param>
	/// <returns>
	/// A new <see cref="Result"/> object with the mapped error if the input <see cref="Result"/> is faulted;
	/// otherwise, returns the <see cref="Result"/> imput object.
	/// </returns>
	public static Result MapError(this Result self, Func<Error, Error> mapper)
		=> self.IsFaulted
			? new Error(mapper(self.Error()!))
			: new Ok();

	/// <summary>
	/// Maps the error of a <see cref="Result{TValue}"/> object to a new <see cref="Result{TValue}"/> using the provided mapper function.
	/// </summary>
	/// <typeparam name="T">The type of value contained in the input result.</typeparam>
	/// <param name="self">The <see cref="Result{TValue}"/> object.</param>
	/// <param name="mapper">The mapper function that takes the current error and returns a new error.</param>
	/// <returns>
	/// A new <see cref="Result{TValue}"/> object with the mapped error if the input <see cref="Result{TValue}"/> is faulted;
	/// otherwise, returns the <see cref="Result{TValue}"/> imput object.
	/// </returns>
	public static Result<T> MapError<T>(this Result<T> self, Func<Error, Error> mapper)
		=> self.IsFaulted
			? new Error(mapper(self.Error()!))
			: self;
}