using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.BLL.DTOs.Department
{
    public class DepartmentToReturnDto
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;

        [Display(Name = "Date Of Creation")]
        public DateOnly CreationDate { get; set; }

        public int Id { get; set; }
        //properities for administartion {security}



    }
}
