using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoursioApi
{
	public static class CoursioApiServiceExtensions
	{
		public static string GetCoursioEndpoint(this Enum enumValue)
		{
			var attribute = enumValue.GetAttributeOfType<CoursioEndpointAttribute>();

			return attribute == null ? String.Empty : attribute.Endpoint;
		}

		public static string GetCoursioEndpointDescription(this Enum enumValue)
		{
			var attribute = enumValue.GetAttributeOfType<CoursioEndpointAttribute>();

			return attribute == null ? String.Empty : attribute.Description;
		}

		public static string GetCoursioInvitationStatus(this Enum enumValue)
		{
			var attribute = enumValue.GetAttributeOfType<CoursioInvitationStatusAttribute>();

			return attribute == null ? String.Empty : attribute.Description;
		}

		private static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
		{
			/// <summary>
			/// Gets an attribute on an enum field value
			/// </summary>
			/// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
			/// <param name="enumVal">The enum value</param>
			/// <returns>The attribute of type T that exists on the enum value</returns>
			var type = enumVal.GetType();
			var memInfo = type.GetMember(enumVal.ToString());
			var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
			return (attributes.Length > 0) ? (T)attributes[0] : null;
		}
	}
}
