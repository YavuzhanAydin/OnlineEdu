﻿using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Abstract
{
    public interface ICourseService : IGenericService<Course>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        List<Course> TGetAllCourseWithCategories();
        List<Course> TGetAllCourseWithCategories(Expression<Func<Course, bool>> filter = null);
        List<Course> TGetCourseByTeacherId(int id);
    }
}
