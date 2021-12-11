using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using API.Infrastructure.Models;
using API.Domain.Services;
using API.Domain.Models;

namespace API.Infrastructure.Implementation
{
    public class FileImport : IFileImport
    {
        private readonly IEmployeeService _employeeService;

        public FileImport(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task ImportAsync(string file)
        {
            // Read the CSV lines into a list of raw objects
            var employeeRawModels = ReadCsvLines(file);

            // Convert and Save Employee
            await SaveEmployeeAsync(employeeRawModels);

            // Delete Tmp File
            if (File.Exists(file))
                File.Delete(file);
        }

        private static List<EmployeeRawModel> ReadCsvLines(string file)
        {
            return File.ReadAllLines(file)
                .Skip(1) // Skip the header line
                .Select(EmployeeRawModel.FromCsv)
                .ToList();
        }

        private async Task SaveEmployeeAsync(IEnumerable<EmployeeRawModel> employeeRawModels)
        {
            var employeeModels = employeeRawModels
                .Select(x => new Employee
                {
                    EmployeeName = x.EmployeeName,
                    EmployeeNo = x.EmployeeNo,
                    DepartmentId = x.DepartmentId,
                    DOB = x.DOB,
                    JoinDate = x.JoinDate,
                    Skills = x.Skills,
                    Salary = x.Salary
                })
                .ToList();
                
            await _employeeService.CreateBulk(employeeModels);
        }
    }
}
