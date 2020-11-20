using CourseManagement.Web.Data.Entities;
using CourseManagement.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CourseManagement.Web.Services
{
    public interface IStudentService
    {
        StudentViewModel Create(Student entity);

        void Edit(Student s);
        void Delete(Student s);
        IQueryable<StudentViewModel> Get();
        StudentViewModel Get(Guid id);
        StudentViewModel Get(Expression<Func<Student, bool>> predicate);
        StudentViewModel Get<U>(Expression<Func<Student, bool>> predicate, Expression<Func<Student, U>> includePredicate);
        IQueryable<StudentViewModel> GetMultiple(Expression<Func<Student, bool>> predicate);
    }
}
