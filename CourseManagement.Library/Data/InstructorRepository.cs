using CourseManagement.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Web.Data
{
    public class InstructorRepository : Repository<Instructor, SchoolContext>
    {
        public InstructorRepository(SchoolContext context)
            : base(context)
        { 
        }
    }
}
