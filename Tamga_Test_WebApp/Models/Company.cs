using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tamga_Test_WebApp.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public String Name { get; set; }

        [Required]
        [RegularExpression(pattern: @"^[А-ЯЁ]{1}[а-яёА-ЯЁ0-9№:,.\s/-]{1,249}$")]
        public String Address { get; set; }

        [Required]
        [RegularExpression(pattern: @"^\+380[0-9]{9}$")]
        public String Phone { get; set; }

        public List<Position> Positions { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
