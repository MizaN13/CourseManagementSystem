using CourseManagement.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Web.Data
{
    public class CourseRepository : Repository<Course, SchoolContext>
    {
        public CourseRepository(SchoolContext context)
            : base(context)
        {
        }
    }
}
