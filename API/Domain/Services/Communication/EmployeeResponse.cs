using API.Domain.Models;

namespace API.Domain.Services.Communication
{
    public class EmployeeResponse : BaseResponse<Employee>
    {
        public EmployeeResponse(Employee resource) : base(resource)
        {
        }

        public EmployeeResponse(string message) : base(message)
        {
        }
    }
}
