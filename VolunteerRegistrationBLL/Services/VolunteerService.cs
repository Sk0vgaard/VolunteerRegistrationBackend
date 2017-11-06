using System;
using System.Collections.Generic;
using System.Linq;
using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationBLL.Converters;
using VolunteerRegistrationBLL.Services.Interfaces;
using VolunteerRegistrationDAL.Facade;

namespace VolunteerRegistrationBLL.Services
{
    internal class VolunteerService : IVolunteerService
    {
        private readonly IDALFacade _facade;
        private readonly VolunteerConverter _volunteerConverter;
        private readonly GuildConverter _guildConverter;

        public VolunteerService(IDALFacade dalFacade)
        {
            _facade = dalFacade;
            _volunteerConverter = new VolunteerConverter();
            _guildConverter = new GuildConverter();
        }

        public VolunteerBO Create(VolunteerBO bo)
        {
            if (bo == null) return null;
            using (var unitOfWork = _facade.UnitOfWork)
            {
                var createdBO = unitOfWork.VolunteerRepository.Create(_volunteerConverter.Convert(bo));
                unitOfWork.Complete();
                return _volunteerConverter.Convert(createdBO);
            }
        }

        public List<VolunteerBO> GetAll()
        {
            using (var unitOfWork = _facade.UnitOfWork)
            {
                return unitOfWork.VolunteerRepository.GetAll().Select(_volunteerConverter.Convert).ToList();
            }
        }

        public List<VolunteerBO> GetAll(List<int> ids)
        {
            using (var unitOfWork = _facade.UnitOfWork)
            {
                return unitOfWork.VolunteerRepository.GetAll(ids).Select(_volunteerConverter.Convert).ToList();
            }
        }

        public VolunteerBO Get(int id)
        {
            using (var unitOfWork = _facade.UnitOfWork)
            {
                var volunteerFromDB = unitOfWork.VolunteerRepository.Get(id);
                if (volunteerFromDB == null) return null;
                var convertedVolunteer = _volunteerConverter.Convert(volunteerFromDB);

                if (convertedVolunteer.GuildIds == null) return convertedVolunteer;
                convertedVolunteer.Guilds = unitOfWork.GuildRepository.GetGuildsWithIds(convertedVolunteer.GuildIds)
                    ?.Select(g => _guildConverter.Convert(g))
                    .ToList();
                return convertedVolunteer;
            }
        }

        public VolunteerBO Update(VolunteerBO bo)
        {
            using (var unitOfWork = _facade.UnitOfWork)
            {
                var entityToUpdate = unitOfWork.VolunteerRepository.Get(bo.Id);
                if (entityToUpdate == null) return null;

                entityToUpdate.Name = bo.Name;
                entityToUpdate.Email = bo.Email;
                entityToUpdate.Phone = bo.Phone;

                unitOfWork.Complete();

                return bo;
            }
        }

        public bool Delete(int id)
        {
            using (var unitOfWork = _facade.UnitOfWork)
            {
                var entityToDelete = unitOfWork.VolunteerRepository.Delete(id);
                unitOfWork.Complete();
                if (entityToDelete == null) return false;
                return true;
            }
        }
    }
}