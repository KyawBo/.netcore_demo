using API.Domain.Models;
using API.Domain.Models.Queries;
using API.Domain.Repositories;
using API.Persistence.Contexts;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace API.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

     /*   public async Task AddAsync(Employee employee)
        {
            string sql = "EXEC [dbo].[Employee_Insert] @EmployeeName, @EmployeeNo, @DOB, @JoinDate, @DepartmentId, @Skills, @Salary";
            var parameters = new[]
            {
                new SqlParameter("@EmployeeName", SqlDbType.NVarChar)
                {
                  Direction = ParameterDirection.Input,
                  Value = employee.EmployeeName
                },
                new SqlParameter("@EmployeeNo", SqlDbType.VarChar)
                {
                  Direction = ParameterDirection.Input,
                  Value = employee.EmployeeNo
                },
                new SqlParameter("@DOB", SqlDbType.NVarChar)
                {
                  Direction = ParameterDirection.Input,
                  Value = employee.DOB
                },
                new SqlParameter("@JoinDate", SqlDbType.NVarChar)
                {
                  Direction = ParameterDirection.Input,
                  Value = employee.JoinDate
                },
                new SqlParameter("@DepartmentId", SqlDbType.Char)
                {
                  Direction = ParameterDirection.Input,
                  Value = employee.DepartmentId
                },
                 new SqlParameter("@Skills", SqlDbType.NVarChar)
                {
                  Direction = ParameterDirection.Input,
                  Value = employee.Skills
                },
                new SqlParameter("@Salary", SqlDbType.Decimal)
                {
                  Direction = ParameterDirection.Input,
                  Value = employee.Salary
                }
            };
            *//*  List<SqlParameter> parms = new List<SqlParameter>
              { 
                  // Create parameters    
                  new SqlParameter { ParameterName = "@EmployeeName", Value = employee.EmployeeName },
                  new SqlParameter { ParameterName = "@c",  Value = employee.EmployeeNo },
                  new SqlParameter { ParameterName = "@DOB",  Value = employee.DOB },
                  new SqlParameter { ParameterName = "@JoinDate",  Value = employee.JoinDate },
                  new SqlParameter { ParameterName = "@DepartmentId", Value = employee.DepartmentId},
                  new SqlParameter { ParameterName = "@Skills",  Value = employee.Skills },
                  new SqlParameter { ParameterName = "@Salary",  Value = employee.Salary},
              };*//*


            await Task.Run(async () =>
            {
                await _appDbContext.Database.ExecuteSqlRawAsync(sql, parameters: parameters);
            });
        }*/

      public async Task<Employee> FindByIdAsync(string id)
       {
            return await _context.Employees
                                 .Include(e => e.Department)
                                 .FirstOrDefaultAsync(e => e.EmployeeId == id);
       }

        public async Task<QueryResult<Employee>> ListAsync(EmployeeQuery query)
        {
            IQueryable<Employee> queryable = _context.Employees
                                                    .Include(e => e.Department)
                                                    .AsNoTracking();

            if (query._employeeName != null )
            {
                queryable = queryable.Where(e => e.EmployeeName.Contains(query._employeeName));
            }

            if (query._employeeNo != null)
            {
                queryable = queryable.Where(e => e.EmployeeNo.Contains(query._employeeNo));
            }

            int totalItems = await queryable.CountAsync();

            List<Employee> employees = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                    .Take(query.ItemsPerPage)
                                                    .OrderBy(e => e.EmployeeNo)
                                                    .ToListAsync();

            return new QueryResult<Employee>
            {
                Items = employees,
                TotalItems = totalItems,
            };
        }

        public void Remove(Employee employee)
        {
            _context.Employees.Remove(employee);
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }
    }
}
