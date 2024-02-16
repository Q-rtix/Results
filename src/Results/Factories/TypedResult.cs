using Results.ResultTypes;

namespace Results.Factories;

public static class TypedResult
{
	public static Result<TValue> Ok<TValue>(TValue value) => new(new Ok<TValue>(value));
	
	public static Result<TValue> Error<TValue>(params object[] errors) => new(new Error(errors));
	public static Result<TValue> Error<TValue>(IEnumerable<object> errors) => new(new Error(errors));
}