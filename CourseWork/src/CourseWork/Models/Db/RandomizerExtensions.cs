using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace CourseWork.Models.Db
{
    public static class RandomizerExtensions
    {
        public static Filler<Student> SetupStudentGenerator(this Filler<Student> randomStudentGenerator)
        {
            randomStudentGenerator.Setup().
                OnProperty(x => x.Id).IgnoreIt().
                // Remember to ignore related tables. 
                OnProperty(x => x.Courses).IgnoreIt().
                OnProperty(x => x.FirstName).Use(new RealNames(NameStyle.FirstName)).
                OnProperty(x => x.LastName).Use(new RealNames(NameStyle.LastName)).
                OnProperty(x => x.StudentCode).Use(new StudentCodeRandomizer());
            return randomStudentGenerator;
        }

        public static Filler<Course> SetupRandomCourseGenerator(this Filler<Course> randomCourseGenerator)
        {
            randomCourseGenerator.Setup().
                OnProperty(x => x.Id).IgnoreIt().
                // Remember to ignore related tables. 
                OnProperty(x => x.Students).IgnoreIt().
                OnProperty(x => x.Name).Use(new MnemonicString(wordCount: 2));
            return randomCourseGenerator;
        }
    }
}
