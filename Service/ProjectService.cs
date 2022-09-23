using AutoMapper;
using Contracts;
using Entities.Models;
using ServiceContracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class ProjectService : IProjectService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly ILoggerManager loggerManager;
        private readonly IMapper mapper; 

        public ProjectService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.loggerManager = loggerManager;
            this.mapper = mapper;
        }

        public IEnumerable<ProjectDto> GetAllProject(bool tranckChanges)
        {
            try
            {
            var project = repositoryManager.Project.GetAllProjects(tranckChanges);
                var projectDtos=mapper.Map<IEnumerable<ProjectDto>>(project);
                return projectDtos;
           
            }
            catch (Exception e)
            {
                loggerManager.LogError("ProjectService.GetAllProjects() has an error:" + e.Message);
                throw;
            }

        }

        public ProjectDto GetOneById(Guid id, bool tranChanges)
        {
            try
            {
              var project  = repositoryManager.Project.GetProject(id, tranChanges);
                var projectDto = mapper.Map<ProjectDto>(project);
                return projectDto;

            }
            catch (Exception e)
            {
                loggerManager.LogError("ProjecrRepository.GetProject():"+e.Message);
                throw;
            }

        }
    }
}