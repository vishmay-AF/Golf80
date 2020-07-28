using AutoMapper;
using Golf80.BusinessEntities;
using Golf80.DataEntities;

namespace Golf80.AutoMapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<DepartmentAddModel, Department>();
            CreateMap<Department, DepartmentViewModel>();
        }
    }
}
