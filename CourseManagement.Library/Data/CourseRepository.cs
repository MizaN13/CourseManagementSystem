using CourseManagement.Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Library.Data
{
    public class CourseRepository : Repository<Course, SchoolContext>
    {
        public CourseRepository(SchoolContext context)
            : base(context)
        {
        }
    }
}
