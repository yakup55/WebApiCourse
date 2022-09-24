using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using ServiceContracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly ILoggerManager loggerManager;
        private readonly IMapper mapper;

        public EmployeeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.loggerManager = loggerManager;
            this.mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetAllEmployeesByProjectId(Guid projectId, bool tranckChanges)
        {
            CheckProjectExits(projectId);
                var emploList = repositoryManager.Employee.GetEmployeesByProjectId(projectId, tranckChanges);
                var employeeDtos = mapper.Map < IEnumerable<EmployeeDto>>(emploList);
                return employeeDtos;
           
        }

        public EmployeeDto GetOneEmployeeByProjectId(Guid projectId, Guid employeeId, bool tranChanges)
        {
            CheckProjectExits(projectId);
            
            
            var list = repositoryManager.Employee.GetEmployeeByProjectId(projectId, employeeId, tranChanges);
            if (list is null)
            {
                throw new EmpleyooNotFoundException(employeeId);
            }
            var employeeDtos = mapper.Map<EmployeeDto>(list);
                return employeeDtos;    
        }
        //Bunu yazarak hata kontrollerini kolay kullanma sunduk
        private void CheckProjectExits(Guid projectId)
        {
            var project = repositoryManager.Project.GetProject(projectId, false);
            if (project is null)
            {
                throw new ProjectNotFoundException(projectId);
            }
        }
       
       
    }
}