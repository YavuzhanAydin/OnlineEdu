using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.DTOs.CourseRegisterDtos
{
    public class UpdateCourseRegister
    {
        public int CourseRegisterID { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public int CourseID { get; set; }
        public ResultCourseDto Course { get; set; }

    }
}
