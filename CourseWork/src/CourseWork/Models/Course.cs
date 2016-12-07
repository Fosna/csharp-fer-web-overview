using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public virtual IList<Student> Students { get; set; }

        public Course()
        {
            Students = new List<Student>();
        }
    }
}
