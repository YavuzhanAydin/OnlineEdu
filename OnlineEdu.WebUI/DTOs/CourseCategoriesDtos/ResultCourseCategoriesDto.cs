﻿
using OnlineEdu.WebUI.DTOs.CourseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.WebUI.DTOs.CourseCategoriesDtos
{
    public class ResultCourseCategoriesDto
    {
        public int CourseCategoryID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool IsShown { get; set; }

        public List<ResultCourseDto> Courses { get; set; }
    }
}
