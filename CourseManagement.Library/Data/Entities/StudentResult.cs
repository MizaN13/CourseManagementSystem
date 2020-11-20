using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Web.Data.Entities
{
    public class StudentResult: EntityBase<Guid>
    {
        public double Cgpa { get; set; }
        public Guid StudentId { get; set; }        
        public Student Student { get; set; }
    }
}
