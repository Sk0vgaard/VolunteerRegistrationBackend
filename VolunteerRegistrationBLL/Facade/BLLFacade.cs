using System.Runtime.CompilerServices;
using VolunteerRegistrationBLL.Services;
using VolunteerRegistrationBLL.Services.Interfaces;
using VolunteerRegistrationDAL.Facade;

[assembly: InternalsVisibleTo("VRBBLLTests")]
[assembly: InternalsVisibleTo("VolunteerRegistrationRestAPI")]

namespace VolunteerRegistrationBLL.Facade
{
    public class BLLFacade : IBLLFacade
    {
        private readonly IDALFacade _dalFacade;

        public BLLFacade(IDALFacade dalFacade)
        {
            _dalFacade = dalFacade;
        }

        public IVolunteerService VolunteerService => new VolunteerService(_dalFacade);
    }
}