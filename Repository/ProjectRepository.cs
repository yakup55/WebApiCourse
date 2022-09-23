using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateProject(Project project) => Create(project);
       

        public void DeleteProject(Project project)
        {
            Delete(project);
        }

        public IEnumerable<Project> GetAllProjects(bool trackChanges)
        {
            return FindAll(trackChanges).OrderBy(x => x.Name).ToList();
        }

        public Project GetProject(Guid id, bool trackChanges)
        {
            return FindByCondition(x => x.Id.Equals(id), trackChanges).SingleOrDefault();
        }
    }
}
