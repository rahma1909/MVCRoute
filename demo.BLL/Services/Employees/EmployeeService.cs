using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.BLL.DTOs.Employee;
using demo.DAL.Entities.Employeees;
using demo.DAL.Presistence.Repositories.Employees;

namespace demo.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _emprepo;

        public EmployeeService(EmployeeRepository emprepo)
        {
           
            _emprepo = emprepo;
        }
        public int CreateEmployee(CreatedEmployeeDto EmployeeDto)
        {
            


            var employee = new Employee()
            {
                Name=EmployeeDto.Name,
                Age=EmployeeDto.Age,
                Address=EmployeeDto.Address,
                Phone=EmployeeDto.Phone,
                IsActive=EmployeeDto.IsActive,
                Email=EmployeeDto.Email,
                HiringDate=EmployeeDto.HiringDate,
                Gendar=EmployeeDto.Gendar,
                Salary=EmployeeDto.Salary,
                EmployeeType=EmployeeDto.EmployeeType,
                CreatedBy=1,
                LastModifiedBy=1,
                LastModifiedOn=DateTime.UtcNow
                
            };
            return _emprepo.Add(employee);
            
            }

        public bool DeleteEmployee(int id)
        {
            var employee = _emprepo.Get(id);
            if(employee is not null)
            {
                return _emprepo.Delete(employee) > 0;
            }
            else
            {
               return  false;
            }
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var employees = _emprepo.GetAllQuerable().Select(e => new EmployeeDto()
            {
                Name=e.Name,
                Age=e.Age,
                Id=e.Id,
                Salary = e.Salary,
                IsActive=e.IsActive,
                Email=e.Email,
                Gendar=e.Gendar,
                EmployeeType=e.EmployeeType,
            });
            return employees;
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var Employee = _emprepo.Get(id);

            if (Employee is not null)
                return new EmployeeDetailsDto()
                {
                    Name = Employee.Name,
                    Age = Employee.Age,
                    Address = Employee.Address,
                    Phone = Employee.Phone,
                    IsActive = Employee.IsActive,
                    Email = Employee.Email,
                    HiringDate = Employee.HiringDate,
                    Gendar = Employee.Gendar,
                    Salary = Employee.Salary,
                    EmployeeType = Employee.EmployeeType,
                   
                };
            return null;
        }

        public int UpdatedEmployee(UpdatedEmployeeDto EmployeeDto)
        {


            var employee = new Employee()
            {
                Id = EmployeeDto.Id,
                Name = EmployeeDto.Name,
                Age = EmployeeDto.Age,
                Address = EmployeeDto.Address,
                Phone = EmployeeDto.Phone,
                IsActive = EmployeeDto.IsActive,
                Email = EmployeeDto.Email,
                HiringDate = EmployeeDto.HiringDate,
                Gendar = EmployeeDto.Gendar,
                Salary = EmployeeDto.Salary,
                EmployeeType = EmployeeDto.EmployeeType,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn=DateTime.UtcNow,
            };

            return _emprepo.Update(employee);
        }

     
    }
}
