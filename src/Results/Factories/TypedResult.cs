using Results.ResultTypes;

namespace Results.Factories;

/// <summary>
/// Represents a typed result, which can be either successful or contain errors.
/// </summary>
public static class TypedResult
{
	/// <summary>
	/// Creates a new result object indicating a successful operation without a value.
	/// </summary>
	/// <returns>A result object indicating a successful operation without a value.</returns>
	public static Result Ok() => new(new Ok());
	
	/// <summary>
	/// Creates a new result object indicating a successful operation with a value.
	/// </summary>
	/// <typeparam name="TValue">The type of the return value on successful operation associated with the Result object.</typeparam>
	/// <param name="value">The value obtained in the operation.</param>
	/// <returns>A result object indicating a successful operation with a value.</returns>
	public static Result<TValue> Ok<TValue>(TValue value) => new(new Ok<TValue>(value));
	
	/// <summary>
	/// Creates a new result object indicating a failed operation with errors.
	/// </summary>
	/// <param name="errors">Errors to associate with the Result object.</param>
	/// <returns>A Result object with Errors.</returns>
	public static Result Error(params object[] errors) => new(new Error(errors));
	
	/// <summary>
	/// Creates a new result object indicating a failed operation with errors.
	/// </summary>
	/// <param name="errors">Errors to associate with the Result object.</param>
	/// <returns>A Result object with Errors.</returns>
	public static Result Error(IEnumerable<object> errors) => new(new Error(errors));

	/// <summary>
	/// Creates a new result object indicating a failed operation with errors.
	/// </summary>
	/// <typeparam name="TValue">The type of the return value on successful operation associated with the Result object.</typeparam>
	/// <param name="errors">Errors to associate with the Result object.</param>
	/// <returns>A Result object with Errors.</returns>
	public static Result<TValue> Error<TValue>(params object[] errors) => new(new Error(errors));

	/// <summary>
	/// Creates a new result object indicating a failed operation with errors.
	/// </summary>
	/// <typeparam name="TValue">The type of the return value on successful operation associated with the Result object.</typeparam>
	/// <param name="errors">Errors to associate with the Result object.</param>
	/// <returns>A Result object with Errors.</returns>
	public static Result<TValue> Error<TValue>(IEnumerable<object> errors) => new(new Error(errors));
}