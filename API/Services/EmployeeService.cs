using System;
using API.Domain.Models;
using API.Domain.Models.Queries;
using API.Domain.Repositories;
using API.Domain.Services;
using API.Domain.Services.Communication;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<EmployeeResponse> DeleteAsync(string id)
        {
            var existingEmployee = await _employeeRepository.FindByIdAsync(id);

            if (existingEmployee == null)
                return new EmployeeResponse("Employee not found.");

            try
            {
                _employeeRepository.Remove(existingEmployee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(existingEmployee);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new EmployeeResponse($"An error occurred when deleting the Employee: {ex.Message}");
            }
        }

        public async Task<QueryResult<Employee>> ListAsync(EmployeeQuery query)
        {
            return await _employeeRepository.ListAsync(query);
        }

        public async Task<EmployeeResponse> ListByIdAsync(string id)
        {
            var employee = await _employeeRepository.FindByIdAsync(id);
            return new EmployeeResponse(employee);
        }

        public async Task<EmployeeResponse> SaveAsync(Employee employee)
        {
            try
            {
                employee.CreatedDate = DateTime.Now;
                employee.UpdatedDate = DateTime.Now;
                await _employeeRepository.AddAsync(employee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(employee);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new EmployeeResponse($"An error occurred when saving the employee: {ex.Message}");
            }
        }

        public async Task<EmployeeResponse> UpdateAsync(string id, Employee employee)
        {
            var existingEmployee = await _employeeRepository.FindByIdAsync(id);

            if (existingEmployee == null)
                return new EmployeeResponse("Employee not found.");

            existingEmployee.EmployeeName = employee.EmployeeName;
            existingEmployee.EmployeeNo = employee.EmployeeNo;
            existingEmployee.DepartmentId = employee.DepartmentId;
            existingEmployee.DOB = employee.DOB;
            existingEmployee.JoinDate = employee.JoinDate;
            existingEmployee.Skills = employee.Skills;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.UpdatedDate = DateTime.Now;

            try
            {
                _employeeRepository.Update(existingEmployee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(existingEmployee);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new EmployeeResponse($"An error occurred when updating the employee: {ex.Message}");
            }
        }

        public async Task CreateBulk(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                employee.CreatedDate = DateTime.Now;
                employee.UpdatedDate = DateTime.Now;
                await _employeeRepository.AddAsync(employee);
            }

            await _unitOfWork.CompleteAsync();
        }
    }
}
