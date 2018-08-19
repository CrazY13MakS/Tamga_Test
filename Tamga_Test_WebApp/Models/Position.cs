using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tamga_Test_WebApp.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Required]
        [RegularExpression(@"^[А-ЯЁA-Z]+[а-яёА-ЯЁA-Za-z.0-9#]{1,}\s{0,1}[а-яёА-ЯЁA-Za-z.0-9#]{1,}$")]
        public String Name { get; set; }


        [Required]
        [Range(0, double.MaxValue)]
        public int SalaryForkMin { get; set; }

        [Required]
        public int SalaryForkMax { get; set; }


        public int? CompanyId { get; set; }

        public Company Company { get; set; }

        public List<Applicant> Applicants { get; set; }
    }
}
