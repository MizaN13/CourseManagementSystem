using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Library.Data.Entities
{
    public class Instructor : EntityBase<Guid>
    {
        public string Name {get; set;}
        public string Designation { get; set; }
        public string Skill { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
        

    }
}
