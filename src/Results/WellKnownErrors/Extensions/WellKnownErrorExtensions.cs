using System.ComponentModel;
using System.Reflection;

namespace Results.WellKnownErrors.Extensions;

public static class WellKnownErrorExtensions
{
	public static string Description(this WellKnownError self)
	{
		var name = self.ToString();
		var field = self.GetType().GetField(name);
		var attribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute), false);
		return attribute?.Description ?? name;
	}
}