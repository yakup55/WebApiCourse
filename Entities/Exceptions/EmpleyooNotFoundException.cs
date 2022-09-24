namespace Entities.Exceptions
{
    public sealed class EmpleyooNotFoundException : NotFoundException
    {
        public EmpleyooNotFoundException(Guid employeeId) : base($"The employee with{employeeId} doesnt exists")
        {

        }
    }
}
