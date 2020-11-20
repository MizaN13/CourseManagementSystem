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
    public class InstructorService : IInstructorService
    {
        private readonly InstructorRepository _instructorRepository;

        public InstructorService(InstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }
        public InstructorViewModel Create(Instructor entity)
        {
            _instructorRepository.Add(entity);
            var instructor = _instructorRepository
                .Get<Course>(
                    i => i.Name.Equals(entity.Name, StringComparison.OrdinalIgnoreCase)
                );
            return new InstructorViewModel()
            {
                Id = instructor.Id,
                Name = instructor.Name,
                Designation = instructor.Designation,
                Skill = instructor.Skill
            };
        }

        public void Delete(Instructor instructor)
        {
            _instructorRepository.Delete(instructor);
        }

        public void Edit(Instructor instructor)
        {
            _instructorRepository.Edit(instructor);
        }

        public IQueryable<InstructorViewModel> Get()
        {
            var instructorList = new List<InstructorViewModel>();
            foreach (var instructor in _instructorRepository.Get().Include(i => i.Courses))
            {

                var vm = new InstructorViewModel()
                {
                    Id = instructor.Id,
                    Name = instructor.Name,
                    Designation = instructor.Designation,
                    Skill = instructor.Skill
                };

                instructorList.Add(vm);
            }
            return instructorList.AsQueryable();
        }

        public InstructorViewModel Get(Guid id)
        {
            var instructor = _instructorRepository.Get(id);

            var vm = new InstructorViewModel()
            {
                Id = instructor.Id,
                Name = instructor.Name,
                Designation = instructor.Designation,
                Skill = instructor.Skill

            };

            return vm;
        }

        public InstructorViewModel Get(Instructor instructor)
        {
            var i = _instructorRepository.Get(instructor);

            var vm = new InstructorViewModel()
            {
                Id = i.Id,
                Name = i.Name,
                Designation = i.Designation,
                Skill = i.Skill

            };
            vm.SetService(this as IInstructorService);
            return vm;
        }
        public InstructorViewModel Get<U>(Expression<Func<Instructor, bool>> predicate, Expression<Func<Instructor, U>> includePredicate)
        {
            var instructor = _instructorRepository.Get(predicate, includePredicate);
            var vm = new InstructorViewModel
            {
                Id = instructor.Id,
                Name = instructor.Name,
                Designation = instructor.Designation,
                Skill = instructor.Skill
            };

            return vm;
        }

        public InstructorViewModel Get(Expression<Func<Instructor, bool>> predicate)
        {
            var instructor = _instructorRepository.Get(predicate, instructor => instructor.Courses);
            var vm = new InstructorViewModel()
            {
                Id = instructor.Id,
                Name = instructor.Name,
                Designation = instructor.Designation,
                Skill = instructor.Skill
            };
            vm.SetService(this as IInstructorService);
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

        public IQueryable<InstructorViewModel> GetMultiple(Expression<Func<Instructor, bool>> predicate)
        {
            var result = new List<InstructorViewModel>();
            foreach (var instructor in _instructorRepository.GetMultiple(predicate))
            {
                var vm = new InstructorViewModel()
                {
                    Id = instructor.Id,
                    Name = instructor.Name,
                    Designation = instructor.Designation,
                    Skill = instructor.Skill
                };

                result.Add(vm);
            }
            return result.AsQueryable();
        }
    }
}
