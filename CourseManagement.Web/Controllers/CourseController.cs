using CourseManagement.Web.Services;
using CourseManagement.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class CourseController : Controller
    {
        private readonly ICourseService  _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var vm = new CourseViewModel(_courseService);
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
            var vm = new CourseViewModel(_courseService);
            //ViewBag.Departments = _departmentService
            //    .Get()
            //    .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
            //    .ToList();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Add(CourseViewModel vm)
        {
            vm.SetService(_courseService);

            vm.Create();
            if (_courseService.Get(s => s.Name == vm.Name) != null)
                return RedirectToAction("Index");
            return View(vm);
        }
        [HttpGet("{id}")]
        public IActionResult Edit(string id)
        {
            var vm = _courseService.Get(s => s.Id.Equals(Guid.Parse(id)));
            //ViewBag.Departments = _departmentService
            //    .Get()
            //    .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
            //    .ToList();
            return View(vm);
        }
        [HttpPost("{id}")]
        public IActionResult Edit(string id, CourseViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);
            vm.SetService(_courseService);
            vm.Update(Guid.Parse(id), vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(CourseViewModel vm)
        {
            vm.Delete();
            return View(vm);
        }
    }
}
