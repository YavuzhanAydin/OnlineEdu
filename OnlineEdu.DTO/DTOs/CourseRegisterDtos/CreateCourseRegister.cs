using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.DTOs.CourseRegisterDtos
{
    public class CreateCourseRegister
    {
        public int AppUserID { get; set; }

        public int CourseID { get; set; }

    }
}
