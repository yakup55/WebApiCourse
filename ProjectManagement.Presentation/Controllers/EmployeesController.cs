using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Presentation.Controllers
{
    [ApiController]
    [Route("api/projects/{projectId}/Employees")]
    public class EmployeesController:ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public EmployeesController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }
        [HttpGet]
        public IActionResult GetAllEmployeeByProjectId(Guid projectId)
        {
                var list = serviceManager.EmployeeService.GetAllEmployeesByProjectId(projectId, false);
                return Ok(list);
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetOneEmployeeByProjectId(Guid projectId,Guid id)
        {
                var employee = serviceManager.EmployeeService.GetOneEmployeeByProjectId(projectId, id, false);
                return Ok(employee);
        }
    }
}
