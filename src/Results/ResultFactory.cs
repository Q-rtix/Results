using Results.ResultTypes;
using Results.WellKnownErrors;

namespace Results;

public static class ResultFactory
{
	/// <summary>
	/// Creates a new result instance based on the provided value and optional status code.
	/// If the value is null, it returns a new result instance with an error indicating a null value.
	/// Otherwise, it returns a new result instance containing the provided value wrapped in an Ok object.
	/// </summary>
	/// <typeparam name="T">The type of the result value.</typeparam>
	/// <param name="value">The value to be contained in the result. Default is null.</param>
	/// <param name="statusCode">The optional status code associated with the result. Default is null.</param>
	/// <returns>A new result instance with either the provided value or an error indicating a null value.</returns>
	/// <remarks>
	/// The value parameter is nullable and must be a reference type.
	/// </remarks>
	public static Result<T> Create<T>(T? value = null, int? statusCode = null) where T : class
		=> value is null
			? new Result<T>(new Error(WellKnownError.NullValue), statusCode)
			: new Result<T>(new Ok<T>(value), statusCode);
	
	/// <summary>
	/// Creates a new result instance based on the provided value and optional status code.
	/// If the value is null, it returns a new result instance with an error indicating a null value.
	/// Otherwise, it returns a new result instance containing the provided value wrapped in an Ok object.
	/// </summary>
	/// <typeparam name="T">The type of the result value, which must be a non-nullable value type.</typeparam>
	/// <param name="value">The value to be contained in the result. Default is null.</param>
	/// <param name="statusCode">The optional status code associated with the result. Default is null.</param>
	/// <returns>A new result instance with either the provided value or an error indicating a null value.</returns>
	/// <remarks>
	/// The value parameter is nullable and must be a non-nullable value type.
	/// </remarks>
	public static Result<T> Create<T>(T? value = null, int? statusCode = null) where T : struct
		=> value is null
			? new Result<T>(new Error(WellKnownError.NullValue), statusCode)
			: new Result<T>(new Ok<T>(value.Value), statusCode);

	/// <summary>
	/// Creates a new result instance representing a failure with the specified error and optional status code.
	/// </summary>
	/// <typeparam name="T">The type of the result value.</typeparam>
	/// <param name="error">The error associated with the failure.</param>
	/// <param name="statusCode">The optional status code associated with the failure. Default is null.</param>
	/// <returns>A new result instance representing a failure with the specified error and optional status code.</returns>
	public static Result<T> Failure<T>(Error error, int? statusCode = null) => new(error, statusCode);
	
	/// <summary>
	/// Creates a new result instance representing a failure with the specified error message(s) or object(s).
	/// </summary>
	/// <typeparam name="T">The type of the result value.</typeparam>
	/// <param name="errors">The error message(s) or object(s) associated with the failure.</param>
	/// <returns>A new result instance representing a failure with the specified error message(s) or object(s).</returns>
	public static Result<T> Failure<T>(params object[] errors) => new Error(errors);
	
	/// <summary>
	/// Creates a new result instance representing a successful operation with the specified value and optional status code.
	/// </summary>
	/// <typeparam name="T">The type of the result value.</typeparam>
	/// <param name="value">The value associated with the successful operation.</param>
	/// <param name="statusCode">The optional status code associated with the successful operation. Default is null.</param>
	/// <returns>A new result instance representing a successful operation with the specified value and optional status code.</returns>
	public static Result<T> Success<T>(T value, int? statusCode = null) => new(new Ok<T>(value), statusCode);
}