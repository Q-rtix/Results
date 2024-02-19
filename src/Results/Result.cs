using Results.ResultTypes;

namespace Results;

/// <summary>
/// Represents the result of an operation that can either succeed or fail.
/// </summary>
public class Result
{
	protected readonly ResultType _result;
	
	/// <summary>
	/// Represents the result of an operation that can either succeed or fail.
	/// </summary>
	public Result(ResultType result)
	{
		_result = result;
	}
	
	/// <summary>
	/// Gets a boolean value which represents the status of the operation.
	/// </summary>
	/// <value>
	/// <c>true</c> if the operation succeeded, otherwise <c>false</c>.
	/// </value>
	public bool IsSucceed => _result.IsSucceed;

	/// <summary>
	/// Gets a value indicating whether the result is faulted.
	/// </summary>
	/// <value><c>true</c> if the result is faulted; otherwise, <c>false</c>.</value>
	public bool IsFaulted => !_result.IsSucceed;
	
	
	/// <summary>
	/// Retrieves the error of the operation if it was unsuccessful; otherwise, null.
	/// </summary>
	/// <returns>
	/// An instance of <see cref="Error"/> representing the error of an unsuccessful operation; otherwise, null.
	/// </returns>
	public Error? Error() => _result as Error;
	
	
	/// <summary>
	/// Retrieves the errors of the operation if it was failure; otherwise, throws an exception.
	/// </summary>
	/// <returns>
	/// An array of objects representing the error data if the Result is a failure.
	/// </returns>
	/// <exception cref="InvalidOperationException">
	/// Thrown when the operation could be completed successfully. Result object contains only data; Expected 'Errors' are missing.
	/// </exception>
	public object[] UnwrapError() => IsFaulted
		? Error()!.Errors
		: throw new InvalidOperationException(
			"The operation could be completed successfully. Result object contains only data; Expected 'Errors' are missing.");

	/// <summary>
	/// Retrieves the error of the operation if it was failure; otherwise, returns the default value.
	/// </summary>
	/// <returns>
	/// An array of objects representing the error data if the Result is a failure; otherwise, the default value.
	/// </returns>
	public object[]? UnwrapErrorOrDefault() => IsFaulted
		? Error()!.Errors
		: default;

	/// <summary>
	/// Retrieves the error of the operation if it was failure; otherwise, returns the provided default value.
	/// </summary>
	/// <param name="defaultValue">The default value to return if the Result is a success.</param>
	/// <returns>
	/// An array of objects representing the error data if the Result is a failure; otherwise, the provided default value.
	/// </returns>
	public object[] UnwrapErrorOr(params object[] defaultValue) => IsFaulted
		? Error()!.Errors
		: defaultValue;
	
	/// <summary>
	/// Matches the result of an operation using success and error functions.
	/// </summary>
	/// <typeparam name="TReturn">The type of the matched result.</typeparam>
	/// <param name="success">The function to invoke if the operation succeeds.</param>
	/// <param name="fail">The function to invoke if the operation fails.</param>
	/// <returns>The result of the matched operation.</returns>
	public TReturn Match<TReturn>(Func<TReturn> success, Func<Error, TReturn> fail) =>
		IsSucceed ? success() : fail(Error()!);

	
	/// <summary>
	/// Executes the specified function if the result represents a failure.
	/// </summary>
	/// <typeparam name="TReturn">The type of the return value.</typeparam>
	/// <param name="function">The function to execute.</param>
	/// <returns>The result of the function if the result represents a failure; otherwise, the default value of TReturn.</returns>
	public TReturn? OnFail<TReturn>(Func<Error, TReturn> function) => IsFaulted ? function(Error()!) : default;
	
	
	/// <summary>
	/// Executes the specified action on the error contained in a failure result.
	/// </summary>
	/// <param name="action">The action to perform with the Error object.</param>
	/// <returns>The current instance of the <see cref="Result{TValue}"/> object.</returns>
	public Result InspectError(Action<Error> action)
	{
		if (IsFaulted)
			action(Error()!);
		return this;
	}
	
	public static implicit operator Result(TValue value) => TypedResult.Ok(value);
	public static implicit operator Result<TValue>(Exception exception) => TypedResult.Error<TValue>(exception);
	
	/// <summary>
	/// Gets the type of the result contained in the Result object.
	/// </summary>
	/// <returns>The type of the result.</returns>
	/// <remarks>
	/// The Result object represents the result of an operation that can either succeed or fail.
	/// This method retrieves the type of the result stored within the Result object.
	/// </remarks>
	public Type GetResultType() => _result.GetType();
	
	public override string ToString() => _result.ToString();
}