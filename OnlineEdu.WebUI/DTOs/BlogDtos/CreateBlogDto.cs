
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.WebUI.DTOs.BlogDtos
{
    public class CreateBlogDto
    {
        
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageURL { get; set; }
        public DateTime BlogDate { get; set; } = DateTime.Now;
        public int BlogCategoryID { get; set; }
        public int WriterID { get; set; }
    }
}
