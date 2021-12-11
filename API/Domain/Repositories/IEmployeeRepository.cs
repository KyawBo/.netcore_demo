using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Models.Queries;

namespace API.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<QueryResult<Employee>> ListAsync(EmployeeQuery query);
        Task AddAsync(Employee employee);
        Task<Employee> FindByIdAsync(string id);
        void Update(Employee employee);
        void Remove(Employee employee);
    }
}
