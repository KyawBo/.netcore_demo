using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Domain.Services;
using API.Resources;
using API.Domain.Models;
using API.Domain.Models.Queries;

namespace API.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly IEmployeeService _employeeService;

        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        
        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<EmployeeResource>), 200)]
        public async Task<QueryResultResource<EmployeeResource>> ListAsync([FromQuery] EmployeesQueryResource query)
        {
            var employeeQuery = _mapper.Map<EmployeesQueryResource, EmployeeQuery>(query);
            var queryResult = await _employeeService.ListAsync(employeeQuery);

            var resource = _mapper.Map<QueryResult<Employee>, QueryResultResource<EmployeeResource>>(queryResult);
            return resource;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeeResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> ListByIdAsync(string id)
        {
            var result = await _employeeService.ListByIdAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var employeeResource = _mapper.Map<Employee, EmployeeResource>(result.Resource);
            return Ok(employeeResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmployeeResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveEmployeeResource resource)
        {
            var employee = _mapper.Map<SaveEmployeeResource, Employee>(resource);
            var result = await _employeeService.SaveAsync(employee);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var employeeResource = _mapper.Map<Employee, EmployeeResource>(result.Resource);
            return Ok(employeeResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EmployeeResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(string id, [FromBody] SaveEmployeeResource resource)
        {
            var employee = _mapper.Map<SaveEmployeeResource, Employee>(resource);
            var result = await _employeeService.UpdateAsync(id, employee);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var employeeResource = _mapper.Map<Employee, EmployeeResource>(result.Resource);
            return Ok(employeeResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EmployeeResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await _employeeService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var categoryResource = _mapper.Map<Employee, EmployeeResource>(result.Resource);
            return Ok(categoryResource);
        }
    }
}
