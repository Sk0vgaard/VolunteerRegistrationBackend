using System;
using System.Collections.Generic;
using System.Text;
using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationBLL.Converters;
using VolunteerRegistrationBLL.Services.Interfaces;
using VolunteerRegistrationDAL.Entities;
using VolunteerRegistrationDAL.Facade;

namespace VolunteerRegistrationBLL.Services
{
    internal class GuildService : IGuildService
    {
        private readonly IDALFacade _facade;
        private readonly IConverter<Guild, GuildBO> _guildConverter;

        public GuildService(IDALFacade facade)
        {
            _facade = facade;
            _guildConverter = new GuildConverter();
        }

        public GuildBO Create(GuildBO bo)
        {
            throw new NotImplementedException();
        }

        public List<GuildBO> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<GuildBO> GetAll(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public GuildBO Get(int id)
        {
            throw new NotImplementedException();
        }

        public GuildBO Update(GuildBO bo)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
