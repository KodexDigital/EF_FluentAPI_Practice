using EF_FluentAPI_Practice.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_FluentAPI_Practice.Models
{
	public class Enrollment
	{
		public int EnrollmentID { get; set; }
		public Grade? Grade { get; set; }

		public int StudentID { get; set; }
		public virtual Student Student { get; set; }

		public int CourseID { get; set; }
		public virtual Course Course { get; set; }
	}
}
