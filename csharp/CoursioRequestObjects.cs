using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace CoursioApi.RequestObjects.InvitationEndpoint
{
	public class PostInvitationRequestObject
	{
		public int courseId { get; set; }
		public int circleId { get; set; }
		public int limit { get; set; }
		public string email { get; set; }
		public string expires { get; set; }
		public bool sendEmail { get; set; }
	}

	public class PutInvitationRequestObject
	{
		public int invitationId { get; set; }
		public bool resend { get; set; }
	}


	public class DeleteInvitationRequestObject
	{
		public int invitationId { get; set; }
	}

}
