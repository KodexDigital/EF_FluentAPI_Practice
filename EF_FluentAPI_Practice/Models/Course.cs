using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_FluentAPI_Practice.Models
{
	public class Course
	{
		public int CourseID { get; set; }
		public string Title { get; set; }
		public int Credits { get; set; }
		public virtual ICollection<Enrollment> Enrollments { get; set; }
	}
}
