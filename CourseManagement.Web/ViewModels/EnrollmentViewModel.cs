using CourseManagement.Library.Data.Entities;
using CourseManagement.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Web.ViewModels
{
    public class EnrollmentViewModel
    {
        private IEnrollmentService _enrollmentService;
        private ICourseService _courseService;
        private IStudentService _studentService;
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

        public ICollection<CourseViewModel> Courses { get; set; } = new List<CourseViewModel>();
        public ICollection<StudentViewModel> Students { get; set; } = new List<StudentViewModel>();

        public EnrollmentViewModel(IEnrollmentService enrollmentService
                                   //ICourseService courseService,
                                   //IStudentService studentService
                                   )
        {
            _enrollmentService = enrollmentService;
            //_courseService = courseService;
            //_studentService = studentService;

        }

        public EnrollmentViewModel()
        {
        }

        public void SetService(IEnrollmentService enrollmentService
                               //ICourseService courseService,
                               //IStudentService studentService
                               )
        {
            _enrollmentService = enrollmentService;
            //_courseService = courseService;
            //_studentService = studentService;
        }


        public void Create()
        {

            var enrollment = new Enrollment
            {
                Id = Id,
                CourseId = CourseId,
                StudentId = StudentId
            };
            _enrollmentService.Create(enrollment);
            //_studentService.Edit(student);
        }

        public void Update(Guid id, EnrollmentViewModel vm)
        {
            var enrollment = new Enrollment
            {
                Id = id,
                CourseId = CourseId,
                StudentId = StudentId
            };
            //foreach (var d in vm.Departments)
            //{


            //}
            _enrollmentService.Edit(enrollment);
        }
        //public void Delete()
        //{
        //    _courseService.Delete(new Enrollment { Id = Id });
        //}

        public IQueryable<EnrollmentViewModel> Read()
        {
            return _enrollmentService.Get();
        }
    }
}
