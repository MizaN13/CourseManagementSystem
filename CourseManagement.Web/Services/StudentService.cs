using CourseManagement.Library.Data;
using CourseManagement.Library.Data.Entities;
using CourseManagement.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CourseManagement.Web.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentRepository _studentRepository;

        public StudentService(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public StudentViewModel Create(Student entity)
        {
            _studentRepository.Add(entity);
            var student = _studentRepository
                .Get<Course>(
                    s => s.Name == entity.Name
                );
            return new StudentViewModel()
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Telephone = student.Telephone,
                Country = student.Country,
                DateOfBirth = student.DateOfBirth,
                Gender = student.Gender,
                Biography = student.Biography,
                InstituteName = student.InstituteName,
                DegreeTitle = student.DegreeTitle,
                PassingYear = student.PassingYear,
                Result = student.Result


            };
        }

        public void Delete(Student student)
        {
            _studentRepository.Delete(student);
        }

        public void Edit(Student student)
        {
            _studentRepository.Edit(student);
        }

        public IQueryable<StudentViewModel> Get()
        {
            var studentList = new List<StudentViewModel>();
            foreach (var student in _studentRepository.Get().Include(s => s.Courses))
            {

                var vm = new StudentViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    Telephone = student.Telephone,
                    Country = student.Country,
                    DateOfBirth = student.DateOfBirth,
                    Gender = student.Gender,
                    Biography = student.Biography,
                    InstituteName = student.InstituteName,
                    DegreeTitle = student.DegreeTitle,
                    PassingYear = student.PassingYear,
                    Result = student.Result
                };

                studentList.Add(vm);
            }
            return studentList.AsQueryable();
        }

        public StudentViewModel Get(Guid id)
        {
            var student = _studentRepository.Get(id);

            var vm = new StudentViewModel()
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Telephone = student.Telephone,
                Country = student.Country,
                DateOfBirth = student.DateOfBirth,
                Gender = student.Gender,
                Biography = student.Biography,
                InstituteName = student.InstituteName,
                DegreeTitle = student.DegreeTitle,
                PassingYear = student.PassingYear,
                Result = student.Result

            };

            return vm;
        }

        public StudentViewModel Get(Student student)
        {
            var s = _studentRepository.Get(student);

            var vm = new StudentViewModel()
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Telephone = s.Telephone,
                Country = s.Country,
                DateOfBirth = s.DateOfBirth,
                Gender = s.Gender,
                Biography = s.Biography,
                InstituteName = s.InstituteName,
                DegreeTitle = s.DegreeTitle,
                PassingYear = s.PassingYear,
                Result = s.Result

            };
            vm.SetService(this as IStudentService);
            return vm;
        }
        public StudentViewModel Get<U>(Expression<Func<Student, bool>> predicate, Expression<Func<Student, U>> includePredicate)
        {
            var student = _studentRepository.Get(predicate, includePredicate);
            var vm = new StudentViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Telephone = student.Telephone,
                Country = student.Country,
                DateOfBirth = student.DateOfBirth,
                Gender = student.Gender,
                Biography = student.Biography,
                InstituteName = student.InstituteName,
                DegreeTitle = student.DegreeTitle,
                PassingYear = student.PassingYear,
                Result = student.Result
            };

            return vm;
        }

        public StudentViewModel Get(Expression<Func<Student, bool>> predicate)
        {
            var student = _studentRepository.Get(predicate, student => student.Courses);
            var vm = new StudentViewModel()
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Telephone = student.Telephone,
                Country = student.Country,
                DateOfBirth = student.DateOfBirth,
                Gender = student.Gender,
                Biography = student.Biography,
                InstituteName = student.InstituteName,
                DegreeTitle = student.DegreeTitle,
                PassingYear = student.PassingYear,
                Result = student.Result
            };
            vm.SetService(this as IStudentService);
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

        public IQueryable<StudentViewModel> GetMultiple(Expression<Func<Student, bool>> predicate)
        {
            var result = new List<StudentViewModel>();
            foreach (var student in _studentRepository.GetMultiple(predicate))
            {
                var vm = new StudentViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    Telephone = student.Telephone,
                    Country = student.Country,
                    DateOfBirth = student.DateOfBirth,
                    Gender = student.Gender,
                    Biography = student.Biography,
                    InstituteName = student.InstituteName,
                    DegreeTitle = student.DegreeTitle,
                    PassingYear = student.PassingYear,
                    Result = student.Result
                };

                result.Add(vm);
            }
            return result.AsQueryable();
        }
    }
}
