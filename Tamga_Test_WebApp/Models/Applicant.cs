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

        [Display(Name = "Имя")]
        [Required(ErrorMessage ="Поле Имя обязательно для ввода")]
        [MinLength(3, ErrorMessage = "Минимальная длина имени 3 символа")]
        [MaxLength(100, ErrorMessage = "Максимальная длина имени 100 символов")]
        public String Name { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage ="Поле Фамилия  обязательно для ввода")]
        [MinLength(3,ErrorMessage ="Минимальная длина фамилии 3 символа")]
        [MaxLength(100, ErrorMessage = "Максимальная длина фамилии 100 символов")]
        public String LastName { get; set; }

        [Display(Name = "Возраст")]
        [Required(ErrorMessage = "Поле Возраст обязательно для ввода")]
        [Range(18, 60, ErrorMessage ="Возраст должен быть в интервале от 18 до 60")]
        public int Age { get; set; }

        [Display(Name = "Телефон")]
        [Required(ErrorMessage = "Поле Телефон обязательно для ввода")]
        [RegularExpression(pattern: @"^\+380[0-9]{9}$", ErrorMessage ="Телефон в формате +380ХХХХХХХХХ")]
        public String Phone { get; set; }

        [Display(Name = "Ожидаемая зарплата")]
        [Required(ErrorMessage = "Поле Зарплата обязательно для ввода")]
        [Range(0,2000000,ErrorMessage = "Число должно быть от 0 до 2 000 000")]
        public int PretendedSalary { get; set; }

        public int? PositionId { get; set; }
        public Position Position { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
