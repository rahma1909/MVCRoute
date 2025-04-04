using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.BLL.DTOs.Department;
using demo.DAL.Entities.Departments;
using demo.DAL.Presistence.Repositories.Departments;

namespace demo.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService

    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IEnumerable<DepartmentToReturnDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAllQuerable().Where(d => !d.IsDeleted).Select(department=> new DepartmentToReturnDto
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                CreationDate = department.CreationDate,

            });
            return departments; 
          

            //foreach (var department in departments)  //manual mapping
            //{
            //    yield return new DepartmentToReturnDto()
            //    {
            //        Id=department.Id,
            //        Name=department.Name,
            //        Code=department.Code,
            //        CreationDate=department.CreationDate,

            //    };
            //}
        }
        public DepartemtDetailsToRetunDto? GetDepartmentById(int id)
        {
            var department = _departmentRepository.Get(id);
            if (department is not null) // != null / is {}
            {
                return new DepartemtDetailsToRetunDto
                {
                    Name = department.Name,
                    Code = department.Code,
                    CreationDate = department.CreationDate,
                    CreatedOn = department.CreatedOn,
                    CreatedBy = department.CreatedBy,
                    Description = department.Description,
                    LastModifiedBy = department.LastModifiedBy,
                    LastModifiedOn = department.LastModifiedOn,

                };

            }
            return null;
        }

        public int CreateDepartment(CreatedDepartmentToRetrunDto departmentDto)
        {
            //CreatedDepartmentToRetrunDto=>department
            var department = new Department()
            {
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                CreationDate = departmentDto.CreationDate,
                Description = departmentDto.Description,
                CreatedBy = 1,
                CreatedOn=DateTime.Now,
                LastModifiedBy=1,
                LastModifiedOn= DateTime.Now,
            };
            return _departmentRepository.Add(department);
        }

        public int UpdatedDepatment(UpdatedDepartmentDto departmentDto)
        {
            //CreatedDepartmentToRetrunDto=>department
            var department = new Department()
            {
                Id=departmentDto.Id,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                CreationDate = departmentDto.CreationDate,
              
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
            };
            return _departmentRepository.Update(department);
        }
   public bool DeleteDepartment(int id)
{
    Console.WriteLine($"DeleteDepartment called with ID: {id}");

    if (id == 0)
    {
        Console.WriteLine("Invalid ID received.");
        return false;
    }

    var department = _departmentRepository.Get(id);

    if (department == null)
    {
        Console.WriteLine($"No department found with ID: {id}");
        return false;
    }

    return _departmentRepository.Delete(department) > 0;
}

      

      
       
    }
}
