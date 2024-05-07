namespace Results.ResultTypes;

/// <summary>
///     Represents a result type indicating a successful operation with a value.
/// </summary>
/// <typeparam name="TValue">The type of the value.</typeparam>
public record Ok<TValue> : ResultType
{
    /// <summary>
    ///     Represents the value of a successful operation result.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public TValue Value { get; }
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="Ok{T}" /> class.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="value">The value obtained in the operation.</param>
    public Ok(TValue value) : base(true)
        => Value = value;

    public Ok() : this(default(TValue))
    {
        if (typeof(TValue) != typeof(Empty))
            throw new InvalidOperationException(
                $"Parameterless constructor of Ok<{typeof(TValue)}> is only available when TValue is Empty.");
    }

    /// <summary>
    ///     Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() => $"{Value}";
}