namespace VolunteerRegistrationDAL
{
    public interface IDALFacade
    {
        IUnitOfWork UnitOfWork { get; }
    }
}