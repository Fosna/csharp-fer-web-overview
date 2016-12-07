using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        [RegularExpression(@"\d+", ErrorMessage = "Student code can contain numbers only. Please make sure that input doesn't contain any white space.")]
        [Display(Name = "Student Code")]
        public string StudentCode { get; set; }

    }
}
