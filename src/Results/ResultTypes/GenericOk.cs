namespace Results.ResultTypes;

/// <summary>
///     Represents a result type indicating a successful operation with a value.
/// </summary>
/// <typeparam name="TValue">The type of the value.</typeparam>
public class Ok<TValue> : Ok
{
    /// <summary>
    ///     Represents the value of a successful operation result.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public TValue Value { get; protected set; }
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="Ok{T}" /> class.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="value">The value obtained in the operation.</param>
    public Ok(TValue value) => Value = value;

    /// <summary>
    ///     Represents an implicit operator for creating an instance of the <see cref="Ok{T}" /> class.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="value">The value to assign to the <see cref="Ok{T}" /> instance.</param>
    /// <returns>An instance of the <see cref="Ok{T}" /> class with the specified value.</returns>
    public static implicit operator Ok<TValue>(TValue value) => new(value);

    /// <summary>
    ///     Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => $"Ok Result: {Value?.ToString() ?? string.Empty}";
}