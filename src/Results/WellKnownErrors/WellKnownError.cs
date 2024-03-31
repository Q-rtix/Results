using System.ComponentModel;

namespace Results.WellKnownErrors;

internal static class WellKnownError
{
	public const string OperationSucceed =
		"The operation could be completed successfully. Result object contains only data; Expected 'Errors' are missing.";

	public const string OperationFailed =
		"The operation could be completed successfully. Result object contains only data; Expected 'Errors' are missing.";
}