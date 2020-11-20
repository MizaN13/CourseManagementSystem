using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Web.Data.Entities
{
    public class Student : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Biography { get; set; }
        public string InstituteName { get; set; }
        public string DegreeTitle { get; set; }
        public int PassingYear { get; set; }
        public double Result { get; set; }

        public virtual ICollection<StudentResult> StudentResults { get; set; } = new List<StudentResult>();
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
