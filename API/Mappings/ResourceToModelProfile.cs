using AutoMapper;
using API.Domain.Models;
using API.Domain.Models.Queries;
using API.Resources;

namespace API.Mappings
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveEmployeeResource, Employee>();

            CreateMap<EmployeesQueryResource, EmployeeQuery>();
        }
    }
}
