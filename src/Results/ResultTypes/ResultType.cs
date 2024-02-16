namespace Results.ResultTypes;

/// <summary>
///     Represents a result type indicating the success or failure of an operation.
/// </summary>
public abstract class ResultType
{
    /// <summary>
    ///     Represents a generic success result type.
    /// </summary>
    /// <remarks>
    ///     This result type indicates a successful operation.
    /// </remarks>
    protected ResultType(bool isSucceed) => IsSucceed = isSucceed;

    /// <summary>
    ///     Gets a value indicating whether the operation was successful.
    /// </summary>
    public bool IsSucceed { get; }

    /// <summary>
    ///     Override the ToString method to output 'Success' or 'Failure'
    /// </summary>
    /// <returns>
    ///     A string that represents the current object.
    /// </returns>
    public override string ToString() => IsSucceed ? "Success" : "Failure";
}