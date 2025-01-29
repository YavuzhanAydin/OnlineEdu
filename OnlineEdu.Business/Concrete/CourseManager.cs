﻿using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Concrete
{
    public class CourseManager : GenericManager<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseManager(IRepository<Course> _repository, ICourseRepository courseRepository) : base(_repository)
        {
            _courseRepository = courseRepository;
        }

        public void TDontShowOnHome(int id)
        {
            _courseRepository.DontShowOnHome(id);
        }

        public List<Course> TGetAllCourseWithCategories()
        {
            return _courseRepository.GetAllCourseWithCategories();
        }

        public List<Course> TGetAllCourseWithCategories(Expression<Func<Course, bool>> filter = null)
        {

            return _courseRepository.GetAllCourseWithCategories(filter);
        }

        public List<Course> TGetCourseByTeacherId(int id)
        {
            return _courseRepository.GetCourseByTeacherId(id);
        }

        public void TShowOnHome(int id)
        {
            _courseRepository.ShowOnHome(id);
        }
    }
}
