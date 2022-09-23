using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployeeForProject(Guid projectId, Employee employee)
        {
            employee.ProjectId = projectId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public Employee GetEmployeeByProjectId(Guid ProjectId, Guid id, bool trackChanges)
        {
         return   FindByCondition(x => x.ProjectId.Equals(ProjectId) && x.Id.Equals(id), trackChanges).SingleOrDefault();
        }

        public IEnumerable<Employee> GetEmployeesByProjectId(Guid projectId, bool trackChanges)=>
        
             FindByCondition(x => x.ProjectId.Equals(projectId), trackChanges).OrderBy(y=>y.FirstName).ToList();
        
    }
}
