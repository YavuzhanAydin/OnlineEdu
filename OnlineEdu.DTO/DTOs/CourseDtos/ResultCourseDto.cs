using OnlineEdu.DTO.DTOs.CourseCategoriesDtos;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.DTOs.CourseDtos
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

        public  AppUser AppUser { get; set; }

        public int AppUserID { get; set; }
	}
}
