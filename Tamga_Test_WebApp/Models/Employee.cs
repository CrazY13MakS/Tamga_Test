using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tamga_Test_WebApp.Models
{
    public class Employee
    {
        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }



    }
}
