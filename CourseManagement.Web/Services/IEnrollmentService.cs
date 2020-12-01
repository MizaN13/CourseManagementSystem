using CourseManagement.Library.Data.Entities;
using CourseManagement.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CourseManagement.Web.Services
{
    public interface IEnrollmentService
    {
        EnrollmentViewModel Create(Enrollment entity);

        void Edit(Enrollment e);
        void Delete(Enrollment e);
        IQueryable<EnrollmentViewModel> Get();
        EnrollmentViewModel Get(Guid id);
        EnrollmentViewModel Get(Expression<Func<Enrollment, bool>> predicate);
        EnrollmentViewModel Get<U>(Expression<Func<Enrollment, bool>> predicate, Expression<Func<Enrollment, U>> includePredicate);
        IQueryable<EnrollmentViewModel> GetMultiple(Expression<Func<Enrollment, bool>> predicate);
    }
}
