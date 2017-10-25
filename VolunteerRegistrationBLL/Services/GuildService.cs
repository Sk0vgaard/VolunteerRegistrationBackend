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
        public Guild Create(Guild bo)
        {
            throw new NotImplementedException();
        }

        public List<Guild> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Guild> GetAll(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public Guild Get(int id)
        {
            throw new NotImplementedException();
        }

        public Guild Update(Guild bo)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
