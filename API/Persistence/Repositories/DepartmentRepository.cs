using API.Domain.Models;
using API.Domain.Repositories;
using API.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Extensions;

namespace API.Persistence.Repositories
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;
        public DepartmentRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public async Task<Department> FindByIdAsync(string id)
        {
            return await _appDbContext.Departments.FindAsync(id);
        }

        public async Task<IEnumerable<Department>> ListAsync()
        {
            return await Task.Run(async () =>
            {
                var result = await _appDbContext.SqlQuery<Department>("EXEC [dbo].[Department_SelectList]");

                return result;
            });
        }
    }
}
