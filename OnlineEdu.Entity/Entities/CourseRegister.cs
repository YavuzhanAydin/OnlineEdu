using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Entity.Entities
{
    public class CourseRegister
    {
        public  int CourseRegisterID { get; set; }
        public  int AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }
        public  int CourseID { get; set; }
        public virtual Course Course { get; set; }


    }
}
