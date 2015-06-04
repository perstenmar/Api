using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Text;

namespace CoursioApi
{
	public static class CoursioApiExtensions
	{
		public static CoursioDataResponsOfT<T> ToCoursioGetResponse<T>(this string json)
		{
			JsConfig.EmitLowercaseUnderscoreNames = true; 
			JsConfig.TryToParsePrimitiveTypeValues = true;
			JsConfig.ConvertObjectTypesIntoStringDictionary = true;

			CoursioDataResponsOfT<T> result;
			try
			{
				result = json.FromJson<CoursioDataResponsOfT<T>>();
			}
			catch (Exception ex)
			{
				CoursioDataResponsOfT<string> errorResult = json.FromJson<CoursioDataResponsOfT<string>>();
				result = new CoursioDataResponsOfT<T>();
				result.Success = false;
				result.ErrorMessage = string.Format("Failed to retrieve data: {0}", errorResult.Data);
			}
			if(result.Data == null)
			{
				result.Success = false;
				result.ErrorMessage = string.Format("Faild to Desirialize Json to object of type \"{0}\"", typeof(T).ToString());
			}
			result.RawResponse = json;

			return result;
		}
	}
}
