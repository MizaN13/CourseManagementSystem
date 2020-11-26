using CourseManagement.Library.Data;
using CourseManagement.Web.Data;
using CourseManagement.Web.Data.Entities;
using CourseManagement.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CourseManagement.Web.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly EnrollmentRepository _enrollmentRepository;
        private readonly CourseRepository _courseRepository;
        private readonly StudentRepository _studentRepository;

        public EnrollmentService(EnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }
        //public EnrollmentViewModel Create(Enrollment entity)
        //{
        //    _enrollmentRepository.Add(entity);
        //    var enrollment = _enrollmentRepository
        //        .Get<Student>(
        //            e => e.StudentId.Equals(entity.StudentId, StringComparison.OrdinalIgnoreCase)
        //        );
        //    return new EnrollmentViewModel()
        //    {
        //        Id = enrollment.Id,
        //        StudentId = enrollment.StudentId,
        //        CourseId = enrollment.CourseId

        //    };
        //}

        public void Delete(Enrollment enrollment)
        {
            _enrollmentRepository.Delete(enrollment);
        }

        public void Edit(Enrollment enrollment)
        {
            _enrollmentRepository.Edit(enrollment);
        }

        public IQueryable<EnrollmentViewModel> Get()
        {
            var enrollmentList = new List<EnrollmentViewModel>();
            foreach (var enrollment in _enrollmentRepository.Get().Include(e => e.Student).Include(e => e.Course))
            {

                var vm = new EnrollmentViewModel()
                {
                    Id = enrollment.Id,
                    StudentId = enrollment.StudentId,
                    CourseId = enrollment.CourseId,
                    Student = enrollment.Student,
                    Course = enrollment.Course
                };

                enrollmentList.Add(vm);
            }
            return enrollmentList.AsQueryable();
        }

        public EnrollmentViewModel Get(Guid id)
        {
            var enrollment = _enrollmentRepository.Get(id);

            var vm = new EnrollmentViewModel()
            {
                Id = enrollment.Id,
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId
            };

            return vm;
        }

        public EnrollmentViewModel Get(Enrollment enrollment)
        {
            var e = _enrollmentRepository.Get(enrollment);

            var vm = new EnrollmentViewModel()
            {
                Id = e.Id,
                StudentId = e.StudentId,
                CourseId = e.CourseId,
                Student = e.Student,
                Course = e.Course


            };
            vm.SetService(this);
            return vm;
        }
        public EnrollmentViewModel Get<U>(Expression<Func<Enrollment, bool>> predicate, Expression<Func<Enrollment, U>> includePredicate)
        {
            var enrollment = _enrollmentRepository.Get(predicate, includePredicate);
            var vm = new EnrollmentViewModel
            {
                Id = enrollment.Id,
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId
            };

            return vm;
        }

        public EnrollmentViewModel Get(Expression<Func<Enrollment, bool>> predicate)
        {
            var enrollment = _enrollmentRepository.Get(predicate, enrollment => enrollment.Student);
            var vm = new EnrollmentViewModel()
            {
                Id = enrollment.Id,
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId
            };
            vm.SetService(this as IEnrollmentService);
            //foreach (var cs in course.Students)
            //{
            //    var s = _studentService.Get(cs.StudentId);
            //    vm.Students.Add(new StudentViewModel(_studentService)
            //    {
            //        Id = s.Id,
            //        Name = s.Name,
            //        Mark = s.Mark,
            //    });
            //}
            return vm;
        }

        public IQueryable<EnrollmentViewModel> GetMultiple(Expression<Func<Enrollment, bool>> predicate)
        {
            var result = new List<EnrollmentViewModel>();
            foreach (var enrollment in _enrollmentRepository.GetMultiple(predicate))
            {
                var vm = new EnrollmentViewModel()
                {
                    Id = enrollment.Id,
                    StudentId = enrollment.StudentId,
                    CourseId = enrollment.CourseId
                };

                result.Add(vm);
            }
            return result.AsQueryable();
        }
    }
}
