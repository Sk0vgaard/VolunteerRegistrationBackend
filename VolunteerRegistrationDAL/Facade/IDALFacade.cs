using VolunteerRegistrationDAL.UOW;

namespace VolunteerRegistrationDAL.Facade
{
    public interface IDALFacade
    {
        IUnitOfWork UnitOfWork { get; }
    }
}