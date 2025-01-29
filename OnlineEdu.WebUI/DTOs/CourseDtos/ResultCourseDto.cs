using OnlineEdu.WebUI.DTOs.CourseCategoriesDtos;
using OnlineEdu.WebUI.DTOs.UserDtos;


namespace OnlineEdu.WebUI.DTOs.CourseDtos
{
    public class ResultCourseDto
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string ImageURL { get; set; }
        public int CourseCategoryID { get; set; }
        public ResultCourseCategoriesDto Category { get; set; }
        public decimal Price { get; set; }
        public bool IsShown { get; set; }
        public ResultUserDto AppUser { get; set; }
		public int AppUserId { get; set; }
	}
}
