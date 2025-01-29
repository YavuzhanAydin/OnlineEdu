using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DataAccess.Concrete
{
	public class CourseCategoryRepository : GenericRepository<CourseCategory>, ICourseCategoryRepository
	{
		public CourseCategoryRepository(OnlineEduContext _context) : base(_context)
		{
		}

		public void DontShowOnHome(int id)
		{
			var values = _context.CourseCategories.Find(id);
			values.IsShown = false;
			_context.SaveChanges();
		}

		public void ShowOnHome(int id)
		{
			var values = _context.CourseCategories.Find(id);
			values.IsShown = true;
			_context.SaveChanges();
		}
	}
}
