
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.WebUI.DTOs.CourseDtos
{
    public class UpdateCourseDto
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string ImageURL { get; set; }
        public int CourseCategoryID { get; set; }       
        public decimal Price { get; set; }
        public bool IsShown { get; set; }
		public int AppUserId { get; set; }
	}
}
