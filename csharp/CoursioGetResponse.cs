using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Text;

namespace CoursioApi
{
	public class CoursioDataResponsOfT<T> : CoursioResponse
	{
		public T Data { get; set; }

		public CoursioDataResponsOfT<T> PopulateFromJson(string json)
		{
			CoursioDataResponsOfT<T> result = new CoursioDataResponsOfT<T>();
			try
			{
				result = json.FromJson<CoursioDataResponsOfT<T>>();
			}
			catch (Exception ex)
			{
				CoursioDataResponsOfT<string> errorResult = json.FromJson<CoursioDataResponsOfT<string>>();
				this.Success = false;
				this.ErrorMessage = string.Format("Failed to retrieve data: {0}", errorResult.Data);
			}
			this.Success = result.Success;
			this.ApiHint = result.ApiHint;
			if (result.Data == null)
			{
				this.Success = false;
				this.ErrorMessage = string.Format("Faild to Desirialize Json to object of type \"{0}\"", typeof(T).ToString());
			}
			else
			{
				this.Data = result.Data;
			}
			this.RawResponse = json;

			return this;
		}
	}
}
