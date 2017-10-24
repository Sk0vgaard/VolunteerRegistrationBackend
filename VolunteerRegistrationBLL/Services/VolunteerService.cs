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

        public VolunteerService(IDALFacade dalFacade)
        {
            _facade = dalFacade;
            _volunteerConverter = new VolunteerConverter();
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
                return _volunteerConverter.Convert(unitOfWork.VolunteerRepository.Get(id));
            }
        }

        public VolunteerBO Update(VolunteerBO bo)
        {
            using (var unitOfWork = _facade.UnitOfWork)
            {
                var entityToUpdate = unitOfWork.VolunteerRepository.Get(bo.Id);

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
                if (entityToDelete == null) return false;
                return true;
            }
        }
    }
}