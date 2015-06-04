using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursioApi
{
	public class CoursioResponse
	{
		public bool Success { get; set; }
		public string ApiHint { get; set; }
		public string ErrorMessage { get; set; }
		public string RawResponse { get; set; }
	}
}
