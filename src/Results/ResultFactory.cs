using Results.ResultTypes;

namespace Results;

public static class ResultFactory
{
	/// <summary>
	/// Creates a new result instance representing a failure with the specified error and optional status code.
	/// </summary>
	/// <typeparam name="T">The type of the result value.</typeparam>
	/// <param name="error">The error associated with the failure.</param>
	/// <param name="statusCode">The optional status code associated with the failure. Default is null.</param>
	/// <returns>A new result instance representing a failure with the specified error and optional status code.</returns>
	public static Result<T> Error<T>(Error error, int? statusCode = null) => new(error, statusCode);
	
	/// <summary>
    /// Creates a new result instance representing a failure with the specified error and optional status code.
	/// </summary>
	/// <param name="error">The error associated with the failure.</param>
	/// <param name="statusCode">The optional status code associated with the failure. Default is null.</param>
	/// <returns>A new empty result instance representing a failure with the specified error and optional status code.</returns>
	public static Result<Empty> Error(Error error, int? statusCode = null) => new(error, statusCode);
	
	/// <summary>
	/// Creates a new result instance representing a failure with the specified error message(s) or object(s) and optional status code.
	/// </summary>
	/// <typeparam name="T">The type of the result value.</typeparam>
	/// <param name="errors">The error message(s) or object(s) associated with the failure.</param>
	/// <param name="statusCode">The optional status code associated with the failure. Default is null.</param>
	/// <returns>A new result instance representing a failure with the specified error message(s) or object(s) and optional status code.</returns>
	public static Result<T> Error<T>(IEnumerable<object> errors, int? statusCode = null) => new(new Error(errors), statusCode);

	/// <summary>
	/// Creates a new result instance representing a failure with the specified error message(s) or object(s) and optional status code.
	/// </summary>
	/// <param name="errors">The error message(s) or object(s) associated with the failure.</param>
	/// <param name="statusCode">The optional status code associated with the failure. Default is null.</param>
	/// <returns>A new empty result instance representing a failure with the specified error message(s) or object(s) and optional status code.</returns>
	public static Result<Empty> Error(IEnumerable<object> errors, int? statusCode = null) => new(new Error(errors), statusCode);
	
	/// <summary>
	/// Creates a new result instance representing a failure with the specified error message(s) or object(s).
	/// </summary>
	/// <typeparam name="T">The type of the result value.</typeparam>
	/// <param name="errors">The error message(s) or object(s) associated with the failure.</param>
	/// <returns>A new result instance representing a failure with the specified error message(s) or object(s).</returns>
	public static Result<T> Error<T>(params object[] errors) => new(new Error(errors));
	
	/// <summary>
	/// Creates a new result instance representing a failure with the specified error message(s) or object(s).
	/// </summary>
	/// <param name="errors">The error message(s) or object(s) associated with the failure.</param>
	/// <returns>A new empty result instance representing a failure with the specified error message(s) or object(s).</returns>
	public static Result<Empty> Error(params object[] errors) => new(new Error(errors));
	
	/// <summary>
	/// Creates a new result instance representing a successful operation with the specified value and optional status code.
	/// </summary>
	/// <typeparam name="T">The type of the result value.</typeparam>
	/// <param name="value">The value associated with the successful operation.</param>
	/// <param name="statusCode">The optional status code associated with the successful operation. Default is null.</param>
	/// <returns>A new result instance representing a successful operation with the specified value and optional status code.</returns>
	public static Result<T> Ok<T>(T value, int? statusCode = null) => new(new Ok<T>(value), statusCode);
	
	/// <summary>
	/// Creates a new result instance representing a successful operation with the specified value and optional status code.
	/// </summary>
	/// <param name="statusCode">The optional status code associated with the successful operation. Default is null.</param>
	/// <returns>A new empty result instance representing a successful operation with the specified value and optional status code.</returns>
	public static Result<Empty> Ok(int? statusCode = null) => new(new Ok<Empty>(), statusCode);
}