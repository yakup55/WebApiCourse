namespace Entities.Exceptions
{
    //sealed devreledilemez
    public sealed class ProjectNotFoundException : NotFoundException
    {
        public ProjectNotFoundException(Guid projectId) : base($"The project with{projectId} doesnt exists")
        {

        }
    }
}
