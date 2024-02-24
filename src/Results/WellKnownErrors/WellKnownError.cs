using System.ComponentModel;

namespace Results.WellKnownErrors;

internal enum WellKnownError
{
	[Description("The operation could be completed successfully. Result object contains only data; Expected 'Errors' are missing.")]
	OperationSucceed,
	
	[Description("The operation could not be completed successfully. Result object contains only error data; Expected 'Value' is missing.")]
	OperationFailed,
}