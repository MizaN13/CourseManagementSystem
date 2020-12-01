using CourseManagement.Web.Services;
using CourseManagement.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        public EnrollmentController(IEnrollmentService enrollmentService,
            IStudentService studentService,
            ICourseService courseService
            )
        {
            _enrollmentService = enrollmentService;
            _studentService = studentService;
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var vm = new EnrollmentViewModel(_enrollmentService);
            return View(vm.Read().ToList());
        }
        //[HttpGet("{id}")]
        //public IActionResult Index(string id)
        //{
        //    var vm = new StudentViewModel() { Id = Guid.Parse(id) };

        //    return View(vm.Read());
        //}
        public IActionResult Add()
        {
            ViewBag.Students = _studentService
                .Get()
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                .ToList();
            ViewBag.Courses = _courseService
                .Get()
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .ToList();
            var vm = new EnrollmentViewModel(_enrollmentService);
            //ViewBag.Departments = _departmentService
            //    .Get()
            //    .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
            //    .ToList();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Add(EnrollmentViewModel vm)
        {
            vm.SetService(_enrollmentService);

            vm.Create();
            if (_enrollmentService.Get(s => s.StudentId == vm.StudentId && s.CourseId == vm.CourseId)    != null )
                return RedirectToAction("Index");
            return View(vm);
        }
        [HttpGet("{id}")]
        public IActionResult Edit(string id)
        {
            var vm = _enrollmentService.Get(s => s.Id.Equals(Guid.Parse(id)));
            //ViewBag.Departments = _departmentService
            //    .Get()
            //    .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
            //    .ToList();
            return View(vm);
        }
        [HttpPost("{id}")]
        public IActionResult Edit(string id, EnrollmentViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            vm.SetService(_enrollmentService);
            vm.Update(Guid.Parse(id), vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Delete(EnrollmentViewModel vm)
        //{
        //    vm.Delete();
        //    return View(vm);
        //}
    }
}
