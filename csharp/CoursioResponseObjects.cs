using CoursioApi.ResponseObjects.CircleEndpoint.GetResponseDataObjects;
using CoursioApi.ResponseObjects.CourseEndpoint.GetResponseDataObjects;
using CoursioApi.ResponseObjects.InvitationsEndpoint.GetResponseDataObjects;
using CoursioApi.ResponseObjects.StatisticsEndpoint.GetResponseDataObjects;
using CoursioApi.ResponseObjects.UserEndpoint.GetResponseDataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CoursioApi.ResponseObjects.CircleEndpoint
{
	public class GetCircle : CoursioDataResponsOfT<List<CircleGetResponseData>> { }
	public class GetCircles : CoursioDataResponsOfT<List<CircleGetResponseData>> { }
}

namespace CoursioApi.ResponseObjects.CircleEndpoint.GetResponseDataObjects
{
	public class CircleGetResponseData
	{
		public int Id { get; set; }
		public int CourseId { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public bool Active { get; set; }
	}
}

namespace CoursioApi.ResponseObjects.InvitationsEndpoint
{
	public class GetInvitations : CoursioDataResponsOfT<List<InvitationGetResponseData>> { }

	public class GetInvitation : CoursioDataResponsOfT<List<InvitationGetResponseData>> { }

	public class PostAddInvitation : CoursioResponse
	{
		public int InvitationId { get; set; }
		public string Hash { get; set; }
	}

	public class PutResendInvitation : CoursioResponse	{ }

	public class DeleteInvitation : CoursioResponse { }
}

namespace CoursioApi.ResponseObjects.InvitationsEndpoint.GetResponseDataObjects
{
	public class InvitationGetResponseData
	{
		public int Id { get; set; }
		public int CourseId { get; set; }
		public int CircleId { get; set; }
		public int Limit { get; set; }
		public int Count { get; set; }
		public DateTime? Expires { get; set; }
		public string Hash { get; set; }
		public string Email { get; set; }
		public List<string> acceptors { get; set; }
		public int Status { get; set; }
		public CoursioInvitationStatus InvitationStatus 
		{ 
			get 
			{
				if (Enum.IsDefined(typeof(CoursioInvitationStatus), Status))
				{
					return (CoursioInvitationStatus)Status;
				}
				return CoursioInvitationStatus.Error;			
			}
			set
			{
				Status = (int)value;
			}
		}
	}
}

namespace CoursioApi.ResponseObjects.UserEndpoint
{	
	public class GetUser : CoursioDataResponsOfT<List<UserGetResponseData>> { }

	public class GetUserList : CoursioDataResponsOfT<List<UsersListUserGetResponseData>> { }

	public class GetCourseUserList : CoursioDataResponsOfT<List<CourseUserListGetResponseData>> { }
		
}

namespace CoursioApi.ResponseObjects.UserEndpoint.GetResponseDataObjects
{
	public class UserGetResponseData
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string DisplayName { get; set; }
		public string Email { get; set; }
		public string Created { get; set; }
		public DateTime? LastLogin { get; set; }
		public DateTime? LastActive { get; set; }
	}

	public class UsersListUserGetResponseData
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string DisplayName { get; set; }
	}

	public class CourseUserListGetResponseData
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string DisplayName { get; set; }
		public int Progress { get; set; }
		public int PagesRead { get; set; }
		public int TasksCorrect { get; set; }
		public int TasksWrong { get; set; }
		public int TasksPending { get; set; }
		public DateTime? LastActive { get; set; }
	}
}

namespace CoursioApi.ResponseObjects.CourseEndpoint
{
	public class GetCourse : CoursioDataResponsOfT<List<CourseGetResponseData>> { }

	public class GetCourseList : CoursioDataResponsOfT<List<CourseListCourseGetResponseData>> { }

	public class GetUsersCourseRoles : CoursioDataResponsOfT<Dictionary<string, UserCourseRoleGetResponseData>> { }
}

namespace CoursioApi.ResponseObjects.CourseEndpoint.GetResponseDataObjects
{
	public class CourseListCourseGetResponseData
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public bool Active { get; set; }
	}

	public class CourseGetResponseData
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public bool Active { get; set; }
		public List<Section> Sections { get; set; }
	}

	public class Section
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public List<Page> Pages { get; set; }
	}

	public class Page
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public List<Tasks> Tasks { get; set; }
	}

	public class Tasks
	{
		public int Id { get; set; }
		public int Type { get; set; } // task type (1-single choice, 2-multiple choice, 4-open question, 7-file)
		public string Caption { get; set; }  // task caption(s) - includes a json string with title of task and possible answers
	}

	public class UserCourseRoleGetResponseData
	{
		public int Id { get; set; } //CourseId
		public string Name { get; set; } //CourseName
		public string Slug { get; set; }
		public bool Active { get; set; }
		public string Role { get; set; }
	}
}

namespace CoursioApi.ResponseObjects.StatisticsEndpoint
{
	public class GetUserCourseStatistics : CoursioDataResponsOfT<UserStatsGetResponseData> { }
}

namespace CoursioApi.ResponseObjects.StatisticsEndpoint.GetResponseDataObjects
{
	public class UserStatsGetResponseData
	{
		public List<UserStatsCourse> course { get; set; }
	}
	
	public class UserStatsCourse
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public bool Active { get; set; }
		public int Progress { get; set; }
		public int PagesRead { get; set; }
		public int TasksCorrect { get; set; }
		public int TasksWrong { get; set; }
		public int TasksPending { get; set; }
		public DateTime LastActive { get; set; }
		public List<UserStatsSection> Sections { get; set; }
	}

	public class UserStatsSection
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public int PagesRead { get; set; }
		public int TasksCorrect { get; set; }
		public int TasksWrong { get; set; }
		public int TasksPending { get; set; }
		public List<UserStatsPage> Pages { get; set; }
	}
	
	public class UserStatsPage
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public bool Read { get; set; }
		public int TasksCorrect { get; set; }
		public int TasksWrong { get; set; }
		public int TasksPending { get; set; }
		public List<object> Tasks { get; set; }
	}

}
