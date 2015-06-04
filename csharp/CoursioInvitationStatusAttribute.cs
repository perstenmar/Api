using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursioApi
{
	[System.AttributeUsage(AttributeTargets.Field)]
	class CoursioInvitationStatusAttribute : System.Attribute
	{
		private string _description;
		public string Description { get { return _description; } }

		public CoursioInvitationStatusAttribute(string description)
		{
			this._description = description;
		}
	}

}
