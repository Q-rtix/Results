namespace Results.ResultTypes;

/// <summary>
///     Represents a result type indicating an operation failure with error data.
/// </summary>
public class Error : ResultType
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Error" /> class.
    /// </summary>
    /// <param name="errors">The errors to associate with this result.</param>
    public Error(params object[] errors) : base(false) => Errors = errors;
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="Error" /> class.
    /// </summary>
    /// <param name="errors">The errors to associate with this result.</param>
    public Error(IEnumerable<object> errors) : base(false) => Errors = errors.ToArray();

    /// <summary>
    ///     Gets the list of errors associated with the operation failure.
    /// </summary>
    public object[] Errors { get; protected set; }

    /// <summary>
    ///     Represents an implicit operator for creating an instance of the <see cref="Ok{T}" /> class.
    /// </summary>
    /// <param name="exception">The exception to assign to the <see cref="Error" /> instance.</param>
    /// <returns>An instance of the <see cref="Error" /> class with the specified exception error.</returns>
    public static implicit operator Error(Exception exception) => new(exception);

    /// <summary>
    ///     Provides a string representation of the Error object.
    /// </summary>
    public override string ToString() => $"Error Result: {string.Join(", ", Errors.Select(err => err.ToString()))}";
}