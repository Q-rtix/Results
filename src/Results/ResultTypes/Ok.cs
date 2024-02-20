namespace Results.ResultTypes;

public class Ok : ResultType
{
	/// <summary>
	///     Initializes a new instance of the <see cref="Ok" /> class.
	/// </summary>
	public Ok() : base(true)
	{
	}

	/// <summary>
	///     Returns a string that represents the current object.
	/// </summary>
	/// <returns>A string that represents the current object.</returns>
	public override string ToString() => $"Ok Result";
}