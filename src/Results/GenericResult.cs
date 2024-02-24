using Results.ResultTypes;
using Results.WellKnownErrors;
using Results.WellKnownErrors.Extensions;

namespace Results;

/// <summary>
/// Represents the result of an operation that can either succeed or fail.
/// </summary>
/// <typeparam name="TValue">The type of the value contained in a successful result.</typeparam>
public class Result<TValue> : Result
{
	/// <summary>
	/// Represents the result of an operation that can either succeed or fail.
	/// </summary>
	/// <typeparam name="TValue">The type of the value contained in a successful result.</typeparam>
	public Result(ResultType result) : base(result)
	{
	}

	/// <summary>
	/// Retrieves the operation result if it was successful.
	/// </summary>
	/// <typeparam name="TValue">
	/// The type of the value which is contained in a successful result.
	/// </typeparam>
	/// <returns>
	/// An instance of <see cref="Ok{TValue}"/>  representing the result of a successful operation; otherwise, null.
	/// </returns>
	public Ok<TValue>? Ok() => result as Ok<TValue>;

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
		: throw new InvalidOperationException(WellKnownError.OperationFailed.Description());

	/// <summary>
	/// Retrieves the value contained in a successful result or returns the default value.
	/// </summary>
	/// <typeparam name="TValue">The type of the value contained in a successful result.</typeparam>
	/// <returns>
	/// The value contained in a successful result if the operation succeeded;
	/// otherwise, the default value of type <typeparamref name="TValue"/>.
	/// </returns>
	public TValue? GetValueOrDefault() => IsSucceed
		? Ok()!.Value
		: default;

	/// <summary>
	/// Retrieves the value contained in a successful result, otherwise returns the provided default value.
	/// </summary>
	/// <typeparam name="TValue">The type of the value contained in a successful result.</typeparam>
	/// <param name="defaultValue">The default value to return if the result is not successful.</param>
	/// <returns>The unwrapped value if the result is successful, otherwise the specified default value.</returns>
	public TValue GetValueOr(TValue defaultValue) => IsSucceed
		? Ok()!.Value
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
	public new Result<TValue> InspectError(Action<Error> action)
	{
		if (IsFaulted)
			action(Error()!);
		return this;
	}

	public static implicit operator Result<TValue>(Ok<TValue> ok) => new(ok);
	public static implicit operator Result<TValue>(Error error) => new(error);
}