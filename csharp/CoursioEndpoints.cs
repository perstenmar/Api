using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursioApi
{
	public enum CoursioEndpints
	{
		[CoursioEndpointAttribute("circles/{circleId}", "Get circle, define CircelID")]
		Circle,
		[CoursioEndpointAttribute("circles", "Get all circles")]
		Circles,
		[CoursioEndpointAttribute("courses/{courseId}", "Get course, define CourseID")]
		Course,
		[CoursioEndpointAttribute("courses", "Get all courses")]
		Courses,
		[CoursioEndpointAttribute("courses/user/{userId}", "Get all cursers for a user, define UserId")]
		CoursesForUser,
		[CoursioEndpointAttribute("invitations", "Get all invitations")]
		Invitations,
		[CoursioEndpointAttribute("invitations/{invitationId}", "Get invitation, define InvitationId")]
		Invitation,
		[CoursioEndpointAttribute("users/course/{courseId}", "Get all users for a course, define CourseId")]
		UsersForCourse,
		[CoursioEndpointAttribute("users/{userId}", "Get user, define UserId")]
		User,
		[CoursioEndpointAttribute("users", "Get all users")]
		Users,
		[CoursioEndpointAttribute("statistics/course-user/{courseId}/{userId}", "Get statistics for a user for one course, define UserId and CourseId")]
		UserCourseStatistics
	}

}
