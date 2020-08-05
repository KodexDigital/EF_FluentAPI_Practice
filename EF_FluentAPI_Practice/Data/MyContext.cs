using EF_FluentAPI_Practice.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EF_FluentAPI_Practice.Data
{
	public class MyContext : DbContext
	{
		public MyContext() : base("name = ApplicationDbContext") { }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);
			//Renaming property name
			modelBuilder.Entity<Student>().Property(s => s.FirstMidName).HasColumnName("FirstName");

			//renaming the table name
			modelBuilder.Entity<Student>().ToTable("Student_tbl"); //etc.


			//Entity splitting. Sharing the properties of a single model to multiple tables. Using the Student model as example
			modelBuilder.Entity<Student>()
				.Map(student =>
			{
				student.Properties(p => new { p.ID, p.FirstMidName, p.LastName });
				student.ToTable("Student_tbl");
			})
				.Map(studentInfo =>
				{
					studentInfo.Properties(i => new { i.ID, i.EnrollmentDate });
					studentInfo.ToTable("StudentEnrollment_tbl");
				});


			//Property method configuration for PrimaryKey
			modelBuilder.Entity<Course>()
				.HasKey(c => c.CourseID)
				.HasRequired(c => c.Title);

			//configure the maxlenth
			modelBuilder.Entity<Course>().Property(c => c.Title)
				.HasMaxLength(24)
				.IsRequired(); // null not allowed

			//Column configuration. E.g Student mode
			modelBuilder.Entity<Student>().Property(s => s.EnrollmentDate)
				.HasColumnName("EnrollDate") // this changes the name from previous to EnrollDate
				.HasColumnType("DateTime")
				.HasColumnOrder(2)
				.IsOptional(); // not compulsory


			//configuring relataionship: one-to-one relations
			//configurig ID as PK for StudentLogin
			modelBuilder.Entity<StudentLogin>().HasKey(l => l.StudentLoginID);

			//configurig ID as FK StudentLogin
			modelBuilder.Entity<Student>().HasOptional(x => x.StudentLogin) ///StudentLogIn is optional
				.WithRequired(t => t.Student); // Create inverse relationship
											   //.HasRequired(t => t.Student); // Create inverse relationship --- this nop

			//configuring relataionship: one-to-Many relations
			//configurig FK for Student and Enrollment
			modelBuilder.Entity<Enrollment>()
				.HasRequired<Student>(s => s.Student)
				.WithMany(e => e.Enrollments)
				.HasForeignKey(i => i.StudentID);

		}


		public virtual DbSet<Enrollment> Enrollments { get; set; }
		public virtual DbSet<Student> Students { get; set; }
		public virtual DbSet<Course> Courses { get; set; }
	}
}
