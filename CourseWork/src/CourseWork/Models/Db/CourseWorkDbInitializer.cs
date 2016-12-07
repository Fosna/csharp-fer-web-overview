using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Models.Db
{
    public class CourseWorkDbInitializer : DropCreateDatabaseIfModelChanges<CourseWorkDbContext>
    {

        protected override void Seed(CourseWorkDbContext context)
        {

            // Don't forget to save changes to database. :)
            context.SaveChanges();
        }

    }
}
