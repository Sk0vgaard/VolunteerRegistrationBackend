using System;
using System.Collections.Generic;
using System.Linq;
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
            using (var uow = _facade.UnitOfWork)
            {
                var entity = uow.GuildRepository.Create(_guildConverter.Convert(bo));
                return _guildConverter.Convert(entity);
            }
        }

        public List<GuildBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.GuildRepository.GetAll().Select(_guildConverter.Convert).ToList();
            }
        }

        public List<GuildBO> GetAll(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public GuildBO Get(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                return _guildConverter.Convert(uow.GuildRepository.Get(id));
            }
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
