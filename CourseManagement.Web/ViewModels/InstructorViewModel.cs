using CourseManagement.Library.Data.Entities;
using CourseManagement.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Web.ViewModels
{
    public class InstructorViewModel
    {
        private IInstructorService _instructorService;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Skill { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

        public InstructorViewModel(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public InstructorViewModel()
        {
        }

        public void SetService(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }


        public void Create()
        {
            var id = Guid.NewGuid();
            var instructor = new Instructor
            {
                Id = id,
                Name = Name,
                Designation = Designation,
                Skill = Skill                

            };


            _instructorService.Create(instructor);
            //_studentService.Edit(student);
        }

        public IQueryable<InstructorViewModel> Read()
        {
            return _instructorService.Get();
        }
    }
}
