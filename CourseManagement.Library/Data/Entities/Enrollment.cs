using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagement.Library.Data.Entities
{
    public class Enrollment : EntityBase<Guid>
    {

        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
