using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using VolunteerRegistrationBLL.Services;
using VolunteerRegistrationBLL.Services.Interfaces;
using VolunteerRegistrationDAL;
using VolunteerRegistrationDAL.Facade;

[assembly: InternalsVisibleTo("VRBBLLTests")]
[assembly: InternalsVisibleTo("VRBRestAPITests")]
[assembly: InternalsVisibleTo("VolunteerRegistrationRestAPI")]
namespace VolunteerRegistrationBLL.Facade
{
    public class BLLFacade : IBLLFacade
    {
        public IDALFacade DALFacade { get; }
        public IVolunteerService VolunteerService => new VolunteerService(DALFacade);


        public BLLFacade(IConfiguration conf)
        {
            DALFacade = new DALFacade(new DbOptions
            {
                ConnectionString = conf.GetConnectionString("DefaultConnection"),
                Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            });
        }
    }
}