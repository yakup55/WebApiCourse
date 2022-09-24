using AutoMapper;
using Contracts;
using Entities.Exceptions;
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

            var project = repositoryManager.Project.GetAllProjects(tranckChanges);
            var projectDtos = mapper.Map<IEnumerable<ProjectDto>>(project);
            return projectDtos;
        }

        public ProjectDto GetOneById(Guid id, bool tranChanges)
        {
            var project = repositoryManager.Project.GetProject(id, tranChanges);
            if (project is null)
            {
                throw new ProjectNotFoundException(id);
            }
            var projectDto = mapper.Map<ProjectDto>(project);
            return projectDto;
        }
    }
}