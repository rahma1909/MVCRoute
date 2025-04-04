using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.DAL.Common.Enums;

namespace demo.BLL.DTOs.Employee
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }
        //properities for administartion {security}

      
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } //when it made in the database
        public int LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }

        //[Required]
        //[MaxLength(50)]
        //[MinLength(5)]
        public string Name { get; set; } = null!;
        //[Range(22,50)]
        public int? Age { get; set; }

        public string? Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name="Is Active")]
        public bool IsActive { get; set; }

        [EmailAddress]
        public string? Email { get; set; }


        [Phone]
        [Display(Name = "phone Number")]
        public string? Phone { get; set; }

        [Display(Name ="Hiring Date")]
        public DateTime HiringDate { get; set; }


        public Gendar Gendar { get; set; }
        public EmpType EmployeeType { get; set; }

        public string? Department { get; set; }
    }
}
