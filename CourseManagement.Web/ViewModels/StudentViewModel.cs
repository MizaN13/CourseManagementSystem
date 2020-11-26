using CourseManagement.Web.Data.Entities;
using CourseManagement.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Web.ViewModels
{
    public class StudentViewModel
    {
        private IStudentService _studentService;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Biography { get; set; }
        public string InstituteName { get; set; }
        public string DegreeTitle { get; set; }
        public int PassingYear { get; set; }
        public double Result { get; set; }

        public virtual ICollection<StudentResult> StudentResults { get; set; } = new List<StudentResult>();
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public StudentViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public StudentViewModel()
        {
        }

        public void SetService(IStudentService studentService)
        {
            _studentService = studentService;
        }


        public void Create()
        {
            var id = Guid.NewGuid();
            var student = new Student
            {
                Id = id,
                Name = Name,
                Email = Email,
                Telephone = Telephone,
                Country = Country,
                DateOfBirth = DateOfBirth,
                Gender = Gender,
                Biography = Biography,
                InstituteName = InstituteName,
                DegreeTitle = DegreeTitle,
                PassingYear = PassingYear,
                Result = Result,


            };


            _studentService.Create(student);
            //_studentService.Edit(student);
        }

        public void Update(Guid id, StudentViewModel vm)
        {
            var student = new Student
            {
                Id = id,
                Name = Name,
                Email = Email,
                Telephone = Telephone,
                Country = Country,
                DateOfBirth = DateOfBirth,
                Gender = Gender,
                Biography = Biography,
                InstituteName = InstituteName,
                DegreeTitle = DegreeTitle,
                PassingYear = PassingYear,
                Result = Result,
            };
            //foreach (var d in vm.Departments)
            //{


            //}
            _studentService.Edit(student);
        }
        public void Delete()
        {
            _studentService.Delete(new Student { Name = Name });
        }

        public IQueryable<StudentViewModel> Read()
        {
            return _studentService.Get();
        }
    }
}
