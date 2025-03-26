using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.BLL.DTOs.Employee;

namespace demo.BLL.Services.Employees
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees();

        EmployeeDetailsDto? GetEmployeeById(int id);


        int CreateEmployee(CreatedEmployeeDto EmployeeDto);

        int UpdatedEmployee(UpdatedEmployeeDto EmployeeDto);

        bool DeleteEmployee(int id);
    }
}
