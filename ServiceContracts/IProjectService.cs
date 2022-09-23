using Entities.Models;

namespace ServiceContracts
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAllProject(bool tranckChanges);
    }
}