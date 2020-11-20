using CourseManagement.Web.Data.Entities;
using CourseManagement.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Web.Services
{
    public interface ICourseService
    {
        CourseViewModel Create(Course entity);

        void Edit(Course c);
        void Delete(Course c);
        IQueryable<CourseViewModel> Get();
        CourseViewModel Get(Guid id);
        CourseViewModel Get(Expression<Func<Course, bool>> predicate);
        CourseViewModel Get<U>(Expression<Func<Course, bool>> predicate, Expression<Func<Course, U>> includePredicate);
        IQueryable<CourseViewModel> GetMultiple(Expression<Func<Course, bool>> predicate);
    }
}
