using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.DAL.Common.Enums;

namespace demo.BLL.DTOs.Employee
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        //properities for administartion {security}

     
 
        public string Name { get; set; } = null!;
        //[Range(22,50)]
        public int? Age { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }


        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [EmailAddress]
        public string? Email { get; set; }


        public Gendar Gendar { get; set; }
        [Display(Name=" employee type")]
        public EmpType EmployeeType { get; set; }

        public string? Department { get; set; } 
    }
}
