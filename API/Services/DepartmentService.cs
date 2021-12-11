using API.Domain.Models;
using API.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Repositories;

namespace API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<IEnumerable<Department>> ListAsync()
        {
            return await _departmentRepository.ListAsync();
        }
    }
}
