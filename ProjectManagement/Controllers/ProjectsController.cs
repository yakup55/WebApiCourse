﻿using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private List<Project> projectsList;

        private ILoggerManager logger;

        public ProjectsController(ILoggerManager logger)
        {
            this.logger = logger;//DI
            projectsList = new List<Project>
            {
                new Project{Id=Guid.NewGuid(),Name="Project 1"},
                new Project{Id=Guid.NewGuid(),Name="Project 2"},
                new Project{Id=Guid.NewGuid(),Name="Project 3"}
            };
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                logger.LogInfo("Projects.Get() has been run");
                return Ok(projectsList);
            }
            catch (Exception ex)
            {
                logger.LogError("Projects.Get() has been crashed"+ ex.Message);
                throw;
            }
           
        }
    }
}
