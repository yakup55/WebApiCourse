using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext context;
        private Lazy<IProjectRepository> projectRepository;
        private Lazy<IEmployeeRepository> employeeRepository;

        public RepositoryManager(RepositoryContext context)
        {
            this.context = context;
            projectRepository=new Lazy<IProjectRepository>(()=>new ProjectRepository(context));
            employeeRepository=new Lazy<IEmployeeRepository>(()=>new EmployeeRepository(context));
        }

        

        public IProjectRepository Project => projectRepository.Value;

        public IEmployeeRepository Employee => employeeRepository.Value;

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
