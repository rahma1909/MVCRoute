using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.BLL.DTOs.Department
{
    public class CreatedDepartmentToRetrunDto
    {

        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "code is required")]
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name = "Date Of Creation")]
        public DateOnly CreationDate { get; set; }
        
    }

}
