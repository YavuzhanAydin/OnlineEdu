using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Entity.Entities
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string ImageURL { get; set; }
        public int CourseCategoryID { get; set; }
        public virtual CourseCategory Category { get; set; }
        public decimal Price { get; set; }
        public bool IsShown { get; set; }

        public int? AppUserID { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual List<CourseRegister> CourseRegisters { get; set; }
        public virtual List<CourseVideo> CourseVideos { get; set; }
    }
}
