using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tamga_Test_WebApp.Models
{
    public class Applicant
    {
        [Key]
        public int ApplicantId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public String Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public String LastName { get; set; }


        [Required]
        [Range(18, 60)]
        public int Age { get; set; }

        [Required]
        [RegularExpression(pattern: @"^\+380[0-9]{9}$")]
        public String Phone { get; set; }

        [Required]
        public int PretendetSalary { get; set; }

        public int? PositionId { get; set; }
        public Position Position { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
