using Results.Factories;
using Results.ResultTypes;

namespace Results;

public class Result<TValue>
{
	private readonly ResultType _result;

	public Result(ResultType result)
	{
		_result = result;
	}

	public bool IsSucceed => _result.IsSucceed;
	public bool IsFaulted => !_result.IsSucceed;


	public Ok<TValue>? Ok() => _result as Ok<TValue>;
	public Error? Error() => _result as Error;


	public TValue Unwrap() => IsSucceed
		? Ok()!.Value
		: throw new InvalidOperationException(
			"The operation could not be completed successfully. Result object contains only error data; Expected 'Value' is missing.");

	public TValue? UnwrapOrDefault() => IsSucceed
		? Ok()!.Value
		: default;

	public TValue UnwrapOr(TValue defaultValue) => IsSucceed
		? Ok()!.Value
		: defaultValue;


	public object[] UnwrapError() => IsFaulted
		? Error()!.Errors
		: throw new InvalidOperationException(
			"The operation could be completed successfully. Result object contains only data; Expected 'Errors' are missing.");

	public object[]? UnwrapErrorOrDefault() => IsFaulted
		? Error()!.Errors
		: default;

	public object[] UnwrapErrorOr(params object[] defaultValue) => IsFaulted
		? Error()!.Errors
		: defaultValue;


	public TReturn Match<TReturn>(Func<TValue, TReturn> success, Func<Error, TReturn> fail) =>
		IsSucceed ? success(Unwrap()) : fail(Error()!);

	public TReturn? OnSuccess<TReturn>(Func<TValue, TReturn> function) => IsSucceed ? function(Unwrap()) : default;
	public TReturn? OnFail<TReturn>(Func<Error, TReturn> function) => IsFaulted ? function(Error()!) : default;


	public Result<TValue> Inspect(Action<TValue> action)
	{
		if (IsSucceed)
			action(Unwrap());
		return this;
	}

	public Result<TValue> InspectError(Action<Error> action)
	{
		if (IsFaulted)
			action(Error()!);
		return this;
	}

	public Type GetResultType() => _result.GetType();

	public static implicit operator Result<TValue>(TValue value) => TypedResult.Ok(value);
	public static implicit operator Result<TValue>(Exception exception) => TypedResult.Error<TValue>(exception);

	public override string ToString() => _result.ToString();
}