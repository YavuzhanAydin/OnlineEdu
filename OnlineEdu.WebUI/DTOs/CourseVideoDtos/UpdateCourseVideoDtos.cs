﻿namespace OnlineEdu.WebUI.DTOs.CourseVideoDtos
{
	public class UpdateCourseVideoDtos
	{
		public int CourseVideoId { get; set; }
		public int CourseId { get; set; }
		public int VideoNumber { get; set; }
		public string VideoUrl { get; set; }
	}
}
