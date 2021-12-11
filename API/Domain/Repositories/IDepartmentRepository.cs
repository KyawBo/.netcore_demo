using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;

namespace API.Domain.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> ListAsync();
        Task<Department> FindByIdAsync(string id);
    }
}
