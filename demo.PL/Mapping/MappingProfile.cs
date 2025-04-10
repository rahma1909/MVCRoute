

using AutoMapper;
using demo.BLL.DTOs.Department;
using demo.PL.ViewModels.Departments;

namespace demo.PL.Mapping
{
    public class MappingProfile:Profile

    {
        public MappingProfile()
        {
            #region employees

            #endregion

            #region dep


            CreateMap<DepartemtDetailsToRetunDto, DepartmentViewModel>().ReverseMap();
            CreateMap<DepartmentViewModel, UpdatedDepartmentDto>();
            CreateMap<DepartmentViewModel, CreatedDepartmentToRetrunDto>();
            #endregion
        }

  
        
    }
}
