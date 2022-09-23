using Entities.Models;
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
    [Route("api/projects")]
    public class ProjectController:ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public ProjectController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetAllProject()
        {
            var project = serviceManager.ProjectService.GetAllProject(false);
            return Ok(project);
        }
        [HttpGet("{id:guid}")]
        public IActionResult GetOneProject(Guid id)
        {
            try
            {
                var project = serviceManager.ProjectService.GetOneById(id, false);
                return Ok(project);
            }
            catch (Exception)
            {

              return  StatusCode(500, "Internal Error");
            }
        }
    }


}
