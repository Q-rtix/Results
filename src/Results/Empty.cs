namespace Results;

/// <summary>
///     Represents an empty record type with no meaningful data.
/// </summary>
/// <remarks>
///     The <see cref="Empty"/> record serves as a placeholder for situations where a type is needed
///     but no actual data needs to be stored or conveyed.
/// </remarks>
public record Empty
{
	public override string ToString() => "Empty";
}