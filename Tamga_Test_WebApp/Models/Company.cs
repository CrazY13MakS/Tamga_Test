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

        [Display(Name ="Название")]
        [Required(ErrorMessage ="Поле Название обяззательно для заполнения")]
        [MinLength(3, ErrorMessage = "")]
        [MaxLength(250, ErrorMessage = "")]
        public String Name { get; set; }

        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Поле Адрес обязательно для заполнения")]
        [RegularExpression(pattern: @"^[А-ЯЁ]{1}[а-яёА-ЯЁ0-9№:,.\s/-]{1,249}$", ErrorMessage = "Адрес должен начинаться с большой буквы, буквы только на кириллице")]
        public String Address { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Поле Телефон обязательно для заполнения")]
        [RegularExpression(pattern: @"^\+380[0-9]{9}$", ErrorMessage = "Телефон должен быть в формате +380ХХХХХХХХХ")]
        public String Phone { get; set; }

        public List<Position> Positions { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
