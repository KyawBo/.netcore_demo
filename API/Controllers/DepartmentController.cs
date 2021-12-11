using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Domain.Services;
using API.Resources;
using API.Domain.Models;

namespace API.Controllers
{
    public class DepartmentController : BaseApiController
    {
        private readonly IDepartmentService _departmentService;

        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all departments.
        /// </summary>
        /// <returns>List of departments.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartmentResource>), 200)]
        public async Task<IEnumerable<DepartmentResource>> ListAsync()
        {
            var departments = await _departmentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentResource>>(departments);

            return resources;
        }

    }
}
