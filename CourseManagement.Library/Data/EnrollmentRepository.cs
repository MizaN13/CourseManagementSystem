using CourseManagement.Web.Data;
using CourseManagement.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagement.Library.Data
{
    public class EnrollmentRepository : Repository<Enrollment, SchoolContext>
    {
        public EnrollmentRepository(SchoolContext context)
            : base(context)
        {
        }
    }
}
