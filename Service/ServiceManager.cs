using AutoMapper;
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
        private readonly Lazy<IEmployeeService> employeeService;
        

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager,IMapper mapper)
        {
            projectService = new Lazy<IProjectService>(()=>new ProjectService(repositoryManager, loggerManager,mapper)) ;
            employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, loggerManager,mapper));
        }

        public IProjectService ProjectService => projectService.Value;
        public IEmployeeService EmployeeService => employeeService.Value;
    }
}
