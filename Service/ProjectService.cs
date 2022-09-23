using Contracts;
using Entities.Models;
using ServiceContracts;

namespace Service
{
    public class ProjectService : IProjectService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly ILoggerManager loggerManager;

        public ProjectService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            this.repositoryManager = repositoryManager;
            this.loggerManager = loggerManager;
        }

        public IEnumerable<Project> GetAllProject(bool tranckChanges)
        {
            try
            {
            var project = repositoryManager.Project.GetAllProjects(tranckChanges);
            return project;
            }
            catch (Exception e)
            {
                loggerManager.LogError("ProjectService.GetAllProjects() has an error:" + e.Message);
                throw;
            }

        }
    }
}