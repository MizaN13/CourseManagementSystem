using CourseManagement.Library.Data.Entities;
using CourseManagement.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CourseManagement.Web.Services
{
    public interface IInstructorService
    {
        InstructorViewModel Create(Instructor entity);

        void Edit(Instructor i);
        void Delete(Instructor i);
        IQueryable<InstructorViewModel> Get();
        InstructorViewModel Get(Guid id);
        InstructorViewModel Get(Expression<Func<Instructor, bool>> predicate);
        InstructorViewModel Get<U>(Expression<Func<Instructor, bool>> predicate, Expression<Func<Instructor, U>> includePredicate);
        IQueryable<InstructorViewModel> GetMultiple(Expression<Func<Instructor, bool>> predicate);
    }
}
