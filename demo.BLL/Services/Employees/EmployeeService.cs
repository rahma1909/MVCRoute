using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.BLL.DTOs.Employee;
using demo.DAL.Entities.Employeees;
using demo.DAL.Presistence.Repositories.Employees;
using demo.DAL.Presistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace demo.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }


        public int CreateEmployee(CreatedEmployeeDto EmployeeDto)
        {



            var employee = new Employee()
            {
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
                DepartmentId = EmployeeDto.DepartmentId,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow

            };
            _unitOfWork.EmployeeRepository.Add(employee);
          return  _unitOfWork.Complete();

        }

        public bool DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.Get(id);
            if (employee is not null)
            {
                var emprepo = _unitOfWork.EmployeeRepository;
                emprepo.Delete(employee);
                return _unitOfWork.Complete()>0;
            }
            else
            {
                return false;
            }
        }



        public IEnumerable<EmployeeDto> GetAllEmployees(string search)
        {
            var employees = _unitOfWork.EmployeeRepository
                 .GetAllQuerable()
                 .Include(e => e.Department) //eager load
                 .Where(e => !e.IsDeleted && (string.IsNullOrEmpty(search) ||
                  e.Name.ToLower().Contains(search.ToLower())))
                 .Select(e => new EmployeeDto()
                 {
                     Name = e.Name,
                     Age = e.Age,
                     Id = e.Id,
                     Salary = e.Salary,
                     IsActive = e.IsActive,
                     Email = e.Email,
                     Gendar = e.Gendar,
                     EmployeeType = e.EmployeeType,
                     Department = e.Department.Name
                 })
                 .ToList();
            return employees;
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var Employee = _unitOfWork.EmployeeRepository.GetAll() // Ensure GetAll() returns IQueryable<Employee>
                                   .Where(e => e.Id == id)
                                   .Select(e => new EmployeeDetailsDto()
                                   {
                                       Name = e.Name,
                                       Age = e.Age,
                                       Address = e.Address,
                                       Phone = e.Phone,
                                       IsActive = e.IsActive,
                                       Email = e.Email,
                                       HiringDate = e.HiringDate,
                                       Gendar = e.Gendar,
                                       Salary = e.Salary,
                                       EmployeeType = e.EmployeeType,
                                       Department = e.Department != null ? e.Department.Name : "No Department"
                                   })
                                   .FirstOrDefault();

            return Employee;
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
                DepartmentId = EmployeeDto.DepartmentId,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.UtcNow,
            };

            _unitOfWork.EmployeeRepository.Update(employee);
            return _unitOfWork.Complete();
        }





    }
}
