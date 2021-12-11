using AutoMapper;
using API.Domain.Models;
using API.Domain.Models.Queries;
using API.Resources;

namespace API.Mappings
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Department, DepartmentResource>();

            CreateMap<Employee, EmployeeResource>();

            CreateMap<QueryResult<Employee>, QueryResultResource<EmployeeResource>>();
        }
    }
}
