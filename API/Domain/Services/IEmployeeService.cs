using System.Threading.Tasks;
using System.Collections.Generic;
using API.Domain.Models;
using API.Domain.Models.Queries;
using API.Domain.Services.Communication;

namespace API.Domain.Services
{
    public interface IEmployeeService
    {
        Task<QueryResult<Employee>> ListAsync(EmployeeQuery query);
        Task<EmployeeResponse> ListByIdAsync(string id);
        Task<EmployeeResponse> SaveAsync(Employee employee);
        Task<EmployeeResponse> UpdateAsync(string id, Employee employee);
        Task<EmployeeResponse> DeleteAsync(string id);
        Task CreateBulk(IEnumerable<Employee> employees);
    }
}
