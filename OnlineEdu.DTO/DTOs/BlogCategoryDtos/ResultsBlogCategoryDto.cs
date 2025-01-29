using OnlineEdu.DTO.DTOs.BlogDtos;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.DTOs.BlogCategoryDtos
{
    public class ResultsBlogCategoryDto
    {
        public int BlogCategoryID { get; set; }
        public string Name { get; set; }

        public List<ResultsBlogDto> Blogs { get; set; }
    }
}
