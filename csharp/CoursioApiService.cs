using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.Text;
using CoursioApi.RequestObjects.InvitationEndpoint;
using CoursioApi.ResponseObjects.InvitationsEndpoint;
using CoursioApi.ResponseObjects.CourseEndpoint;
using CoursioApi.ResponseObjects.UserEndpoint;
using CoursioApi.ResponseObjects.StatisticsEndpoint;
using CoursioApi.ResponseObjects.CircleEndpoint;

namespace CoursioApi
{
	public class CoursioApiService
	{
		CoursioApi _api;

		/// <summary>
		/// Uses CoursioApiFactory to create an instance of CoursioApi with settings from AppSettings
		/// </summary>
		public CoursioApiService()
		{
			_api = CoursioApiFactory.CreateApiClientFromAppSettingsDef();
		}

		public CoursioApiService(CoursioApi api)
		{
			api = api;
		}


		public string Get(CoursioEndpointDefinition getDefinition)
		{
			return _api.Get(getDefinition);
		}

		public GetUserList GetAllUsers()
		{
			CoursioEndpointDefinition def = new CoursioEndpointDefinition();
			def.Endpoint = CoursioEndpints.Users;

			return (GetUserList)new GetUserList().PopulateFromJson(_api.Get(def));
		}

		public GetUserCourseStatistics GetUserCourseStatistics(int userId, int courseId)
		{
			CoursioEndpointDefinition def = new CoursioEndpointDefinition();
			def.Endpoint = CoursioEndpints.UserCourseStatistics;
			def.UserId = userId;
			def.CourseId = courseId;

			return (GetUserCourseStatistics)new GetUserCourseStatistics().PopulateFromJson(_api.Get(def));
		}

		public GetCourseUserList GetUsersForCourse(int courseId)
		{
			CoursioEndpointDefinition def = new CoursioEndpointDefinition();
			def.Endpoint = CoursioEndpints.UsersForCourse;
			def.CourseId = courseId;

			return (GetCourseUserList)new GetCourseUserList().PopulateFromJson(_api.Get(def));
		}

		public GetUsersCourseRoles GetCoursesForUser(int userid)
		{
			CoursioEndpointDefinition def = new CoursioEndpointDefinition();
			def.Endpoint = CoursioEndpints.CoursesForUser;
			def.UserId = userid;

			return (GetUsersCourseRoles)new GetUsersCourseRoles().PopulateFromJson(_api.Get(def));
		}

		public GetCourse GetCourse(int courseId)
		{
			CoursioEndpointDefinition def = new CoursioEndpointDefinition();
			def.Endpoint = CoursioEndpints.Course;
			def.CourseId = courseId;

			return (GetCourse)new GetCourse().PopulateFromJson(_api.Get(def));
		}

		public GetCourseList GetAllCourses()
		{
			CoursioEndpointDefinition def = new CoursioEndpointDefinition();
			def.Endpoint = CoursioEndpints.Courses;

			return (GetCourseList)new GetCourseList().PopulateFromJson(_api.Get(def));
		}

		public GetInvitation GetInvitation(int invitationId)
		{
			CoursioEndpointDefinition def = new CoursioEndpointDefinition();
			def.Endpoint = CoursioEndpints.Invitation;
			def.InvitationId = invitationId;

			return (GetInvitation)new GetInvitation().PopulateFromJson(_api.Get(def));
		}

		public PostAddInvitation PostInvitation(PostInvitationRequestObject requestObject)
		{
			CoursioEndpointDefinition def = new CoursioEndpointDefinition();
			def.Endpoint = CoursioEndpints.Invitations;
			def.RequestJsonPayload = requestObject.ToJson();

			return _api.Post(def).FromJson<PostAddInvitation>();
		}

		public PutResendInvitation PutResendInvitation(PutInvitationRequestObject requestObject)
		{
			CoursioEndpointDefinition def = new CoursioEndpointDefinition();
			def.Endpoint = CoursioEndpints.Invitation;
			def.InvitationId = requestObject.invitationId;
			def.RequestJsonPayload = requestObject.ToJson();

			return _api.Put(def).FromJson<PutResendInvitation>();
		}

		public DeleteInvitation DeleteInvitation(DeleteInvitationRequestObject requestObject)
		{
			CoursioEndpointDefinition def = new CoursioEndpointDefinition();
			def.Endpoint = CoursioEndpints.Invitation;
			def.InvitationId = requestObject.invitationId;
			def.RequestJsonPayload = requestObject.ToJson();

			return _api.Delete(def).FromJson<DeleteInvitation>();
		}

		public GetCircle GetCircleById(int circleId)
		{
			CoursioEndpointDefinition def = new CoursioEndpointDefinition();
			def.Endpoint = CoursioEndpints.Circle;
			def.CircleId = circleId;

			return _api.Get(def).FromJson<GetCircle>();
		}

		public GetCircles GetAllCircles()
		{
			CoursioEndpointDefinition def = new CoursioEndpointDefinition();
			def.Endpoint = CoursioEndpints.Circles;

			return _api.Get(def).FromJson<GetCircles>();
		}



		public GetCircles GetCirclesForCourse(int courseID)
		{
			CoursioEndpointDefinition def = new CoursioEndpointDefinition();
			def.Endpoint = CoursioEndpints.Circles;

			var circles = _api.Get(def).FromJson<GetCircles>();

			if(!circles.Success)
			{
				return circles;
			}

			circles.Data = circles.Data.Where(x => x.CourseId == courseID).ToList();

			return circles;
		}
	}
}
