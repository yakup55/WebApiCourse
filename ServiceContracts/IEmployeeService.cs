using Entities.Models;
using Shared.DataTransferObjects;

namespace ServiceContracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployeesByProjectId(Guid projectId,bool tranckChanges);
        EmployeeDto GetOneEmployeeByProjectId(Guid projectId,Guid employeeId,bool tranChanges);

    }
}