using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF_FluentAPI_Practice.Models
{
	public class StudentLogin
	{

		public string EmailID { get; set; }
		public string Password { get; set; }

		[Key, ForeignKey("StudentLoginID")] //single property for both PK and FK
		public int StudentLoginID { get; set; }
		public virtual Student Student { get; set; }
	}
}
