using VolunteerRegistrationBLL.Services.Interfaces;

namespace VolunteerRegistrationBLL.Facade
{
    public interface IBLLFacade
    {
        IVolunteerService VolunteerService { get; }
    }
}