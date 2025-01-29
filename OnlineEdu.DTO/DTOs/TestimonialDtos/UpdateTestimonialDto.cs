using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.DTOs.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public int TestiMonialID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string ImageURl { get; set; }
        public string Comment { get; set; }
        public int Star { get; set; }
    }
}
