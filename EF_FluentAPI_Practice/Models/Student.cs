using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_FluentAPI_Practice.Models
{
	public class Student
	{
		public int ID { get; set; }
		public string LastName { get; set; }
		public string FirstMidName { get; set; }
		public DateTime EnrollmentDate { get; set; }
		public virtual ICollection<Enrollment> Enrollments { get; set; }
		public virtual StudentLogin StudentLogin { get; set; }
	}
}
