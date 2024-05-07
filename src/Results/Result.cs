using Results.ResultTypes;
using Results.WellKnownErrors;

namespace Results;

/// <summary>
/// Represents the result of an operation that can either succeed or fail.
/// </summary>
/// <typeparam name="TValue">The type of the value contained in a successful result.</typeparam>
public class Result<TValue>
{
	private readonly ResultType _innerResult;
	
	/// <summary>
	/// Represents the result of an operation that can either succeed or fail.
	/// </summary>
	/// <typeparam name="TValue">The type of the value contained in a successful result.</typeparam>
	/// <param name="innerResult">
	/// The result of the operation.
	/// </param>
	/// <param name="statusCode">
	/// The status code of the operation.
	/// </param>
	public Result(ResultType innerResult, int? statusCode = null) 
		=> (_innerResult, StatusCode) = (innerResult, statusCode);
	
	/// <summary>
	///     Gets or sets the status code.
	/// </summary>
	/// <value>
	///     The status code, or null if no status code has been set.
	/// </value>
	/// <remarks>
	///     This status code is versatile, having applicability as both an internal status marker within the application, or
	///     externally as an HTTP status code when interacting over HTTP protocols.
	/// </remarks>
	public int? StatusCode { get; set; }

	/// <summary>
	///     Gets a boolean value which represents the status of the operation.
	/// </summary>
	/// <value>
	///     <c>true</c> if the operation succeeded, otherwise <c>false</c>.
	/// </value>
	public bool IsSucceed => _innerResult.IsSucceed;

	/// <summary>
	///     Gets a value indicating whether the result is faulted.
	/// </summary>
	/// <value><c>true</c> if the result is faulted; otherwise, <c>false</c>.</value>
	public bool IsFaulted => !_innerResult.IsSucceed;
	
	/// <summary>
	/// Retrieves the value contained in a successful result if the operation was successful, or throws an exception.
	/// </summary>
	/// <returns>
	/// The value of the successful result.
	/// </returns>
	/// <exception cref="InvalidOperationException">
	/// Thrown when the operation was not successful and the result object does not contain the expected value.
	/// </exception>
	public TValue Value => IsSucceed
		? Ok()!.Value
		: throw new InvalidOperationException(WellKnownError.OperationFailed);

	/// <summary>
	///     Retrieves the errors of the operation if it was failure; otherwise, throws an exception.
	/// </summary>
	/// <returns>
	///     An array of objects representing the error data if the Result is a failure.
	/// </returns>
	/// <exception cref="InvalidOperationException">
	///     Thrown when the operation could be completed successfully. Result object contains only data; Expected 'Errors' are
	///     missing.
	/// </exception>
	public object[] Errors => IsFaulted
		? Error()!.Errors
		: throw new InvalidOperationException(WellKnownError.OperationSucceed);

	/// <summary>
	///     Gets the type of the result contained in the Result object.
	/// </summary>
	/// <returns>The type of the result.</returns>
	/// <remarks>
	///     The Result object represents the result of an operation that can either succeed or fail.
	///     This method retrieves the type of the result stored within the Result object.
	/// </remarks>
	public Type ResultType => _innerResult.GetType();

	/// <summary>
	/// Retrieves the operation result if it was successful.
	/// </summary>
	/// <typeparam name="TValue">
	/// The type of the value which is contained in a successful result.
	/// </typeparam>
	/// <returns>
	/// An instance of <see cref="Ok{TValue}"/>  representing the result of a successful operation; otherwise, null.
	/// </returns>
	public Ok<TValue>? Ok() => _innerResult as Ok<TValue>;

	/// <summary>
	///     Retrieves the error of the operation if it was unsuccessful; otherwise, null.
	/// </summary>
	/// <returns>
	///     An instance of <see cref="Error" /> representing the error of an unsuccessful operation; otherwise, null.
	/// </returns>
	public Error? Error() => _innerResult as Error;

	/// <summary>
	/// Retrieves the value contained in a successful result or returns the default value.
	/// </summary>
	/// <typeparam name="TValue">The type of the value contained in a successful result.</typeparam>
	/// <returns>
	/// The value contained in a successful result if the operation succeeded;
	/// otherwise, the default value of type <typeparamref name="TValue"/>.
	/// </returns>
	public TValue? GetValueOrDefault() => IsSucceed
		? Value
		: default;

	/// <summary>
	/// Retrieves the value contained in a successful result, otherwise returns the provided default value.
	/// </summary>
	/// <typeparam name="TValue">The type of the value contained in a successful result.</typeparam>
	/// <param name="defaultValue">The default value to return if the result is not successful.</param>
	/// <returns>The unwrapped value if the result is successful, otherwise the specified default value.</returns>
	public TValue GetValueOr(TValue defaultValue) => IsSucceed
		? Value
		: defaultValue;

	/// <summary>
	/// Retrieves the value of the result if the operation succeeded, or the result of a function if the operation failed.
	/// </summary>
	/// <typeparam name="TValue">The type of the value contained in the result.</typeparam>
	/// <param name="function">The function to be executed if the operation failed.</param>
	/// <returns>The value of the result if the operation succeeded, or the result of the function if the operation failed.</returns>
	public TValue GetValueOrElse(Func<Error, TValue> function) => IsSucceed
		? Value
		: function(Error()!);
	
	/// <summary>
	///     Retrieves the error of the operation if it was failure; otherwise, returns the default value.
	/// </summary>
	/// <returns>
	///     An array of objects representing the error data if the Result is a failure; otherwise, the default value.
	/// </returns>
	public object[]? GetErrorsOrDefault() => IsFaulted
		? Error()!.Errors
		: default;

	/// <summary>
	///     Retrieves the error of the operation if it was failure; otherwise, returns the provided default value.
	/// </summary>
	/// <param name="defaultValue">The default value to return if the Result is a success.</param>
	/// <returns>
	///     An array of objects representing the error data if the Result is a failure; otherwise, the provided default value.
	/// </returns>
	public object[] GetErrorsOr(params object[] defaultValue) => IsFaulted
		? Error()!.Errors
		: defaultValue;

	/// <summary>
	/// Matches the result of an operation using success and error functions.
	/// </summary>
	/// <typeparam name="TReturn">The type of the matched result.</typeparam>
	/// <param name="success">The function to invoke if the operation succeeds.</param>
	/// <param name="fail">The function to invoke if the operation fails.</param>
	/// <returns>The result of the matched operation.</returns>
	public TReturn Match<TReturn>(Func<TValue, TReturn> success, Func<Error, TReturn> fail) =>
		IsSucceed ? success(Value) : fail(Error()!);
	
	public TReturn Match<TReturn>(Func<TReturn> success, Func<Error, TReturn> fail)
	{
		if (typeof(TValue) != typeof(Empty))
			throw new InvalidOperationException(
				$"Match with Func<{typeof(TReturn)} is only available when TValue is Empty. TValue is {typeof(TValue)}. " +
				$"Instead use Match<{typeof(TValue)},{typeof(TReturn)}>.");
		
		return IsSucceed ? success() : fail(Error()!);
	}

	/// <summary>
	/// Executes the specified function if the operation was successful.
	/// </summary>
	/// <typeparam name="TReturn">The return type of the function.</typeparam>
	/// <param name="function">The function to execute.</param>
	/// <returns>
	/// The result of the function execution if the operation was successful, or <see langword="default"/> if the operation failed.
	/// </returns>
	public TReturn? OnSuccess<TReturn>(Func<TValue, TReturn> function) => IsSucceed ? function(Value) : default;
	
	/// <summary>
	///     Executes the specified function if the operation was successful.
	/// </summary>
	/// <typeparam name="TReturn">The return type of the function.</typeparam>
	/// <param name="function">The function to execute.</param>
	/// <returns>
	///     The result of the function execution if the operation was successful, or <see langword="default" /> if the
	///     operation failed.
	/// </returns>
	public TReturn? OnSuccess<TReturn>(Func<TReturn> function) => IsSucceed ? function() : default;
	
	/// <summary>
	///     Executes the specified function if the result represents a failure.
	/// </summary>
	/// <typeparam name="TReturn">The type of the return value.</typeparam>
	/// <param name="function">The function to execute.</param>
	/// <returns>The result of the function if the result represents a failure; otherwise, the default value of TReturn.</returns>
	public TReturn? OnFail<TReturn>(Func<Error, TReturn> function) => IsFaulted ? function(Error()!) : default;

	/// <summary>
	/// Executes the specified action on the value contained in a successful result.
	/// </summary>
	/// <param name="action">
	/// The action to execute on the value.
	/// </param>
	/// <returns>
	/// The current instance of the <see cref="Result{TValue}"/> object.
	/// </returns>
	public Result<TValue> Inspect(Action<TValue> action)
	{
		if (IsSucceed)
			action(Value);
		return this;
	}

	/// <summary>
	/// Executes the specified action on the error contained in a failure result.
	/// </summary>
	/// <param name="action">The action to perform with the Error object.</param>
	/// <returns>The current instance of the <see cref="Result{TValue}"/> object.</returns>
	public Result<TValue> InspectError(Action<Error> action)
	{
		if (IsFaulted)
			action(Error()!);
		return this;
	}

	public override string ToString() => $"{(IsSucceed ? "Ok:" : "Error:")} {_innerResult}";

	public static implicit operator Result<TValue>(Ok<TValue> ok) => new(ok);
	public static implicit operator Result<TValue>(Error error) => new(error);
}