using Contracts;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProjectService> projectService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            projectService = new Lazy<IProjectService>(()=>new ProjectService(repositoryManager, loggerManager)) ;
        }

        public IProjectService ProjectService => projectService.Value;
    }
}
