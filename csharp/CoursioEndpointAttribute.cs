using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursioApi
{
	[System.AttributeUsage(AttributeTargets.Field)]
	class CoursioEndpointAttribute : System.Attribute
	{
		private string _endpoint;
		public string Endpoint { get { return _endpoint; } }

		private string _description;
		public string Description { get { return _description; } }
		
		public CoursioEndpointAttribute(string endpoint, string description)
		{
			this._endpoint = endpoint;
			this._description = description;
		}
	}

}
