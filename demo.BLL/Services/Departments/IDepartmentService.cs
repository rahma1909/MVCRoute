using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.BLL.DTOs.Department;

namespace demo.BLL.Services.Departments
{
    public interface IDepartmentService
    {

        IEnumerable<DepartmentToReturnDto> GetAllDepartments();

       DepartemtDetailsToRetunDto? GetDepartmentById(int id);


        int CreateDepartment(CreatedDepartmentToRetrunDto departmentDto);

        int UpdatedDepatment(UpdatedDepartmentDto departmentDto);

        bool DeleteDepartment(int id);
    }
}
