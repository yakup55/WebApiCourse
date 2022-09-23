using Entities.Models;
using Shared.DataTransferObjects;

namespace ServiceContracts
{
    public interface IProjectService
    {
        IEnumerable<ProjectDto> GetAllProject(bool tranckChanges);
        ProjectDto GetOneById(Guid id, bool tranChanges);
    }
}