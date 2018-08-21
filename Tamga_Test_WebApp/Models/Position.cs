using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tamga_Test_WebApp.Infrastructure;

namespace Tamga_Test_WebApp.Models
{
  
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage ="Поле Название обязательно к заполнению")]
        [RegularExpression(@"^[А-ЯЁA-Z]+[а-яёА-ЯЁA-Za-z.0-9#]{1,}\s{0,}[а-яёА-ЯЁA-Za-z.0-9#]{1,}$",ErrorMessage ="Название должно начинаться с большой буквы и содержать не более двух слов")]
        public String Name { get; set; }

        [Display(Name = "Минимальная зарплата")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [Range(0, double.MaxValue,ErrorMessage ="Значение должно быть в положительном диапазоне")]
        public int SalaryForkMin { get; set; }

        [Display(Name ="Максимальная зарплата")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [EqualOrGreaterValidationAttribute(nameof(SalaryForkMin), ErrorMessage ="Значение должно быть равно или больше Минимальной зарплаты")]
        public int SalaryForkMax { get; set; }


        public int? CompanyId { get; set; }

        public Company Company { get; set; }

        public List<Applicant> Applicants { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
