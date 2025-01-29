using OnlineEdu.WebUI.DTOs.CourseDtos;
using OnlineEdu.WebUI.DTOs.UserDtos;

namespace OnlineEdu.WebUI.DTOs.CourseRegisterDtos
{
    public class UpdateCourseRegisterDto
    {

        public int CourseRegisterID { get; set; }
        public int AppUserID { get; set; }
        public ResultUserDto AppUser { get; set; }
        public int CourseID { get; set; }
        public ResultCourseDto Course { get; set; }

    }
}
