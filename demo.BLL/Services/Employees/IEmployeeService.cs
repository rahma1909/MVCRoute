using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.BLL.DTOs.Employee;
using demo.DAL.Entities.Employeees;

namespace demo.BLL.Services.Employees
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(string search);

        EmployeeDetailsDto? GetEmployeeById(int id);


        int CreateEmployee(CreatedEmployeeDto EmployeeDto);

        int UpdatedEmployee(UpdatedEmployeeDto EmployeeDto);

        bool DeleteEmployee(int id);

    
    }
}
