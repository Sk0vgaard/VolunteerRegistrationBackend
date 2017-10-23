using VolunteerRegistrationBLL.Services;
using VolunteerRegistrationBLL.Services.Interfaces;
using VolunteerRegistrationDAL.Facade;

namespace VolunteerRegistrationBLL.Facade
{
    public interface IBLLFacade
    {
        IDALFacade DALFacade { get;}
        IVolunteerService VolunteerService { get; }
    }
}