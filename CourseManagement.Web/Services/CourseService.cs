using CourseManagement.Web.Data;
using CourseManagement.Web.Data.Entities;
using CourseManagement.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Web.Services
{
    public class CourseService : ICourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public CourseViewModel Create(Course entity)
        {
            _courseRepository.Add(entity);
            var course = _courseRepository
                .Get<Student>(
                    c => c.Name.Equals(entity.Name, StringComparison.OrdinalIgnoreCase)
                );
            return new CourseViewModel()
            {
                Id = course.Id,
                Name = course.Name,
                Type = course.Type,
                Target = course.Target,
                Level = course.Level,
                Fee = course.Fee,
                Description = course.Description,
                Prerequisite = course.Prerequisite,
                CourseHighlight = course.CourseHighlight,
                Classes = course.Classes,
                Lessons = course.Lessons,
                Duration = course.Duration,
                BatchNo = course.BatchNo,
                ClassDays = course.ClassDays,
                Time = course.Time,
                RegClose = course.RegClose,
                ClassStart = course.ClassStart


            };
        }

        public void Delete(Course course)
        {
            _courseRepository.Delete(course);
        }

        public void Edit(Course course)
        {
            _courseRepository.Edit(course);
        }

        public IQueryable<CourseViewModel> Get()
        {
            var courseList = new List<CourseViewModel>();
            foreach (var course in _courseRepository.Get().Include(c => c.Students))
            {

                var vm = new CourseViewModel()
                {
                    Id = course.Id,
                    Name = course.Name,
                    Type = course.Type,
                    Target = course.Target,
                    Level = course.Level,
                    Fee = course.Fee,
                    Description = course.Description,
                    Prerequisite = course.Prerequisite,
                    CourseHighlight = course.CourseHighlight,
                    Classes = course.Classes,
                    Lessons = course.Lessons,
                    Duration = course.Duration,
                    BatchNo = course.BatchNo,
                    ClassDays = course.ClassDays,
                    Time = course.Time,
                    RegClose = course.RegClose,
                    ClassStart = course.ClassStart,
                };
                
                courseList.Add(vm);
            }
            return courseList.AsQueryable();
        }

        public CourseViewModel Get(Guid id)
        {
            var course = _courseRepository.Get(id);

            var vm = new CourseViewModel()
            {
                Id = course.Id,
                Name = course.Name,
                Type = course.Type,
                Target = course.Target,
                Level = course.Level,
                Fee = course.Fee,
                Description = course.Description,
                Prerequisite = course.Prerequisite,
                CourseHighlight = course.CourseHighlight,
                Classes = course.Classes,
                Lessons = course.Lessons,
                Duration = course.Duration,
                BatchNo = course.BatchNo,
                ClassDays = course.ClassDays,
                Time = course.Time,
                RegClose = course.RegClose,
                ClassStart = course.ClassStart,

            };
            
            return vm;
        }

        public CourseViewModel Get(Course course)
        {
            var c = _courseRepository.Get(course);

            var vm = new CourseViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Type = c.Type,
                Target = c.Target,
                Level = c.Level,
                Fee = c.Fee,
                Description = c.Description,
                Prerequisite = c.Prerequisite,
                CourseHighlight = c.CourseHighlight,
                Classes = c.Classes,
                Lessons = c.Lessons,
                Duration = c.Duration,
                BatchNo = c.BatchNo,
                ClassDays = c.ClassDays,
                Time = c.Time,
                RegClose = c.RegClose,
                ClassStart = c.ClassStart

            };
            vm.SetService(this as ICourseService);
            return vm;
        }
        public CourseViewModel Get<U>(Expression<Func<Course, bool>> predicate, Expression<Func<Course, U>> includePredicate)
        {
            var course = _courseRepository.Get(predicate, includePredicate);
            var vm = new CourseViewModel
            {
                Id = course.Id,
                Name = course.Name,
                Type = course.Type,
                Target = course.Target,
                Level = course.Level,
                Fee = course.Fee,
                Description = course.Description,
                Prerequisite = course.Prerequisite,
                CourseHighlight = course.CourseHighlight,
                Classes = course.Classes,
                Lessons = course.Lessons,
                Duration = course.Duration,
                BatchNo = course.BatchNo,
                ClassDays = course.ClassDays,
                Time = course.Time,
                RegClose = course.RegClose,
                ClassStart = course.ClassStart
            };
            
            return vm;
        }

        public CourseViewModel Get(Expression<Func<Course, bool>> predicate)
        {
            var course = _courseRepository.Get(predicate, course => course.Students);
            var vm = new CourseViewModel()
            {
                Id = course.Id,
                Name = course.Name,
                Type = course.Type,
                Target = course.Target,
                Level = course.Level,
                Fee = course.Fee,
                Description = course.Description,
                Prerequisite = course.Prerequisite,
                CourseHighlight = course.CourseHighlight,
                Classes = course.Classes,
                Lessons = course.Lessons,
                Duration = course.Duration,
                BatchNo = course.BatchNo,
                ClassDays = course.ClassDays,
                Time = course.Time,
                RegClose = course.RegClose,
                ClassStart = course.ClassStart
            };
            vm.SetService(this as ICourseService);
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

        public IQueryable<CourseViewModel> GetMultiple(Expression<Func<Course, bool>> predicate)
        {
            var result = new List<CourseViewModel>();
            foreach (var course in _courseRepository.GetMultiple(predicate))
            {
                var vm = new CourseViewModel()
                {
                    Id = course.Id,
                    Name = course.Name,
                    Type = course.Type,
                    Target = course.Target,
                    Level = course.Level,
                    Fee = course.Fee,
                    Description = course.Description,
                    Prerequisite = course.Prerequisite,
                    CourseHighlight = course.CourseHighlight,
                    Classes = course.Classes,
                    Lessons = course.Lessons,
                    Duration = course.Duration,
                    BatchNo = course.BatchNo,
                    ClassDays = course.ClassDays,
                    Time = course.Time,
                    RegClose = course.RegClose,
                    ClassStart = course.ClassStart
                };
                
                result.Add(vm);
            }
            return result.AsQueryable();
        }
    }
}

