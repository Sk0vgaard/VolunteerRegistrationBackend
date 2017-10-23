using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using VolunteerRegistrationBLL.Services;
using VolunteerRegistrationBLL.Services.Interfaces;
using VolunteerRegistrationDAL;
using VolunteerRegistrationDAL.Context;
using VolunteerRegistrationDAL.Facade;

[assembly: InternalsVisibleTo("VRBBLLTests")]
[assembly: InternalsVisibleTo("VRBRestAPITests")]
[assembly: InternalsVisibleTo("VolunteerRegistrationRestAPI")]
namespace VolunteerRegistrationBLL.Facade
{
    public class BLLFacade : IBLLFacade
    {
        public IDALFacade DALFacade { get; }

        public BLLFacade(IDALFacade dalFacade)
        {
            DALFacade = dalFacade;
        }
        public IVolunteerService VolunteerService => new VolunteerService(DALFacade);
    }
}