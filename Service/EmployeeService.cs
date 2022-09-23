using AutoMapper;
using Contracts;
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
            try
            {
                var emploList = repositoryManager.Employee.GetEmployeesByProjectId(projectId, tranckChanges);
                var employeeDtos = mapper.Map < IEnumerable<EmployeeDto>>(emploList);
                return employeeDtos;
            }
            catch (Exception e)
            {
                loggerManager.LogError("EmployeeService.GetAllEmployeesByProjectId:" + e.Message);
                throw;
            }
        }

        public EmployeeDto GetOneEmployeeByProjectId(Guid projectId, Guid employeeId, bool tranChanges)
        {
            try
            {
                var list = repositoryManager.Employee.GetEmployeeByProjectId(projectId, employeeId, tranChanges);
                var employeeDtos = mapper.Map<EmployeeDto>(list);
                return employeeDtos;    
            }
            catch (Exception e)
            {
                loggerManager.LogError("EmployeeService.GetAllEmployeesByProjectId:" + e.Message);
                throw;
            }
        }
    }
}