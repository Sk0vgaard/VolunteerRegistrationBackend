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
        public BLLFacade(IDALFacade dalFacade)
        {
            DALFacade = dalFacade;
        }

        public IDALFacade DALFacade { get; }
        public IVolunteerService VolunteerService => new VolunteerService(DALFacade);
    }
}