using System.Collections.Generic;
using System.Linq;
using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationBLL.Converters;
using VolunteerRegistrationBLL.Services.Interfaces;
using VolunteerRegistrationDAL.Facade;

namespace VolunteerRegistrationBLL.Services
{
    public class GuildManagerService : IGuildManagerService
    {
        private readonly IDALFacade _facade;
        private readonly GuildManagerConverter _guildManagerConverter;

        public GuildManagerService(IDALFacade facade)
        {
            _facade = facade;
            _guildManagerConverter = new GuildManagerConverter();
        }
        public GuildManagerBO Create(GuildManagerBO bo)
        {
            using (var unitOfWork = _facade.UnitOfWork)
            {
                var convertedEntityForDB = _guildManagerConverter.Convert(bo);
                var createdEntity = unitOfWork.GuildManagerRepository.Create(convertedEntityForDB);
                unitOfWork.Complete();
                return _guildManagerConverter.Convert(createdEntity);
            }
        }

        public List<GuildManagerBO> GetAll()
        {
            using (var unitOfWork = _facade.UnitOfWork)
            {
                return unitOfWork.GuildManagerRepository.GetAll().Select(_guildManagerConverter.Convert).ToList();
            }
        }

        public List<GuildManagerBO> GetAll(List<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public GuildManagerBO Get(int id)
        {
            using (var unitOfWork = _facade.UnitOfWork)
            {
                return _guildManagerConverter.Convert(unitOfWork.GuildManagerRepository.Get(id));
            }
        }

        public GuildManagerBO Update(GuildManagerBO bo)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            using (var unitOfWork = _facade.UnitOfWork)
            {
                var entity = unitOfWork.GuildManagerRepository.Get(id);
                if (entity == null) return false;
                unitOfWork.GuildManagerRepository.Delete(id);
                unitOfWork.Complete();
                return true;
            }
        }
    }
}