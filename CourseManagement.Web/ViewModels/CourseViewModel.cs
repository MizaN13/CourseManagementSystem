using CourseManagement.Library.Data.Entities;
using CourseManagement.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Web.ViewModels
{
    public class CourseViewModel
    {
        private ICourseService _courseService;

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Target { get; set; }
        public string Level { get; set; }
        public double Fee { get; set; }
        public string Description { get; set; }
        public string CourseHighlight { get; set; }
        public int Classes { get; set; }
        public int Lessons { get; set; }
        public double Duration { get; set; }
        public string Prerequisite { get; set; }
        public int BatchNo { get; set; }
        public DateTime ClassDays { get; set; }
        public DateTime Time { get; set; }
        public DateTime RegClose { get; set; }
        public DateTime ClassStart { get; set; }
       

        public CourseViewModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public CourseViewModel()
        {
        }

        public void SetService(ICourseService courseService)
        {
            _courseService = courseService;
        }


        public void Create()
        {
            
            var course = new Course
            {
                Name = Name,
                Type = Type,
                Target = Target,
                Level = Level,
                Fee = Fee,
                Description = Description,
                Prerequisite = Prerequisite,
                CourseHighlight = CourseHighlight,
                Classes = Classes,
                Lessons = Lessons,
                Duration = Duration,
                BatchNo = BatchNo,
                ClassDays = ClassDays,
                Time = Time,
                RegClose = RegClose,
                ClassStart = ClassStart

            };
            

            _courseService.Create(course);
            //_studentService.Edit(student);
        }

        public void Update(Guid id, CourseViewModel vm)
        {
            var course = new Course
            {
                Id = id,
                Name = Name,
                Type = Type,
                Target = Target,
                Level = Level,
                Fee = Fee,
                Description = Description,
                Prerequisite = Prerequisite,
                CourseHighlight = CourseHighlight,
                Classes = Classes,
                Lessons = Lessons,
                Duration = Duration,
                BatchNo = BatchNo,
                ClassDays = ClassDays,
                Time = Time,
                RegClose = RegClose,
                ClassStart = ClassStart
            };
            //foreach (var d in vm.Departments)
            //{


            //}
            _courseService.Edit(course);
        }
        public void Delete()
        {
            _courseService.Delete(new Course { Name = Name });
        }

        public IQueryable<CourseViewModel> Read()
        {
            return _courseService.Get();
        }
    }
}
