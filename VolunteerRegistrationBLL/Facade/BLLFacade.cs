using System;
using Microsoft.Extensions.Configuration;
using VolunteerRegistrationDAL;
using VolunteerRegistrationDAL.Facade;

namespace VolunteerRegistrationBLL.Facade
{
    public class BLLFacade : IBLLFacade
    {
        private IDALFacade facade;

        public BLLFacade(IConfiguration conf)
        {
            facade = new DALFacade(new DbOptions
            {
                ConnectionString = conf.GetConnectionString("DefaultConnection"),
                Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            });
        }
    }
}