using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursioApi
{
	public class CoursioEndpointDefinition
	{
		public CoursioEndpints Endpoint { get; set; }
		public string TranslatedEndpoint { 
			get
			{
				string endpoint = Endpoint.GetCoursioEndpoint();				
				endpoint = endpoint.Replace("{userId}", this.UserId.ToString());
				endpoint = endpoint.Replace("{courseId}", this.CourseId.ToString());
				endpoint = endpoint.Replace("{invitationId}", this.InvitationId.ToString());
				endpoint = endpoint.Replace("{circleId}", this.CircleId.ToString());
				endpoint = endpoint.Replace("{ucpId}", this.UserCirclePermissionID.ToString());
				endpoint = endpoint.Replace("{ucpId}", this.UserCoursePermissionID.ToString());
				return endpoint;
			}
		}
		public int UserId { get; set; }
		public int CourseId { get; set; }
		public int InvitationId { get; set; }
		public int CircleId { get; set; }
		public int UserCirclePermissionID { get; set; }
		public int UserCoursePermissionID { get; set; }

		/// <summary>
		/// Only used for Verb POST & PUT
		/// </summary>
		public string RequestJsonPayload { get; set; }
	}
}
