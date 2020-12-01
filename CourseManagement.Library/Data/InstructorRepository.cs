using CourseManagement.Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Library.Data
{
    public class InstructorRepository : Repository<Instructor, SchoolContext>
    {
        public InstructorRepository(SchoolContext context)
            : base(context)
        { 
        }
    }
}
