using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Models.Db
{
    public class CourseWorkDbContext : DbContext
    {
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Course> Courses { get; set; }

        // Inject hosting environment to check if in development or production environment.
        public CourseWorkDbContext(string connectionString, IHostingEnvironment env) : base(connectionString)
        {
            if (env.IsDevelopment())
            {
                // Log SLQ statements to debug console during development
                Database.Log = logRecord => Debug.WriteLine(logRecord);

                // Don't use database migrations during development. Drop database if schema changes. Speeds up development.
                Database.SetInitializer(new CourseWorkDbInitializer());
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().Property(x => x.FirstName).HasMaxLength(255);
            modelBuilder.Entity<Student>().Property(x => x.LastName).HasMaxLength(255);
            // Create unique index on StudentCode.
            modelBuilder.Entity<Student>().
                Property(p => p.StudentCode).
                HasMaxLength(20).
                HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Student_StudentCode")
                        {
                            IsUnique = true,
                        }
                    )
                );

        }
    }
}