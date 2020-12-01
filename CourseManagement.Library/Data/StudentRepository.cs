using CourseManagement.Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Library.Data
{
    public class StudentRepository : Repository<Student, SchoolContext>
    {
        public StudentRepository(SchoolContext context)
            : base(context)
        {

        }
        public override void Add(Student s)
        {
            _context.Set<Student>().Add(s);
            
            _context.SaveChanges();
        }
    }
}
