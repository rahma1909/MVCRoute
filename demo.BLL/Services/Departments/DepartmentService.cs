using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.BLL.DTOs.Department;
using demo.DAL.Entities.Departments;
using demo.DAL.Presistence.Repositories.Departments;
using demo.DAL.Presistence.UnitOfWork;

namespace demo.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService

    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<DepartmentToReturnDto> GetAllDepartments()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAllQuerable().Where(d => !d.IsDeleted).Select(department => new DepartmentToReturnDto
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
            var department = _unitOfWork.DepartmentRepository.Get(id);
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
                CreatedOn = DateTime.Now,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
            };
            _unitOfWork.DepartmentRepository.Add(department);
            return _unitOfWork.Complete();
        }

        public int UpdatedDepatment(UpdatedDepartmentDto departmentDto)
        {
            //CreatedDepartmentToRetrunDto=>department
            var department = new Department()
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
                Code = departmentDto.Code,
                CreationDate = departmentDto.CreationDate,

                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
            };
            _unitOfWork.DepartmentRepository.Update(department);
            return _unitOfWork.Complete();
        }
        public bool DeleteDepartment(int id)
        {
            var deprepo = _unitOfWork.DepartmentRepository;
            var dep = deprepo.Get(id);


            if (dep is { })
            deprepo.Delete(dep);
            return _unitOfWork.Complete() > 0;


      }





    }
}
