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
        private readonly GuildWorkConverter _gwConverter;
        private readonly VolunteerConverter _volunteerConverter;

        public GuildService(IDALFacade facade)
        {
            _facade = facade;
            _guildConverter = new GuildConverter();
            _gwConverter = new GuildWorkConverter();
            _volunteerConverter = new VolunteerConverter();
        }

        public GuildBO Create(GuildBO bo)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var entity = uow.GuildRepository.Create(_guildConverter.Convert(bo));
                uow.Complete();
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
            using (var uow = _facade.UnitOfWork)
            {
                return uow.GuildRepository.GetAll(ids).Select(_guildConverter.Convert).ToList();
            }
        }

        public GuildBO Get(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var guildFromDB = uow.GuildRepository.Get(id);
                if (guildFromDB == null) return null;
                var convertedGuild = _guildConverter.Convert(guildFromDB);

                if (convertedGuild.VolunteerIds == null) return convertedGuild;
                {
                    convertedGuild.Volunteers = uow.VolunteerRepository.GetVolunteersWithIds(convertedGuild.VolunteerIds)
                        ?.Select(v => _volunteerConverter.Convert(v))
                        .ToList();
                }
                return convertedGuild;
            }
        }

        public GuildBO Update(GuildBO bo)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var entityToUpdate = uow.GuildRepository.Get(bo.Id);
                if (entityToUpdate == null) return null;
                entityToUpdate.Id = bo.Id;
                entityToUpdate.Name = bo.Name;
                uow.Complete();
                return bo;
            }
        }

        public bool Delete(int id)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var entityToDelete = uow.GuildRepository.Delete(id);
                uow.Complete();
                return entityToDelete != null;
            }
        }

        public bool AddGuildWork(GuildWorkBO guildWork)
        {
            using (var unitOfWork = _facade.UnitOfWork)
            {
                var guild = unitOfWork.GuildRepository.Get(guildWork.GuildId);
                guild.GuildWork.Add(_gwConverter.Convert(guildWork));
                unitOfWork.Complete();
                return true;
            }
        }

        public IEnumerable<GuildWorkBO> GetGuidWorksFromGuild(int idOfGuild)
        {
            using (var uow = _facade.UnitOfWork)
            {
                var guild = uow.GuildRepository.Get(idOfGuild);
                if (guild == null) return null;
                var guildBO = _guildConverter.Convert(guild);
                return guildBO.GuildWork;
            }
        }
    }
}