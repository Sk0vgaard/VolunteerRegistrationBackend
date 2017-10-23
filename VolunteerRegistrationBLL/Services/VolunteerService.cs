using System.Collections.Generic;
using System.Linq;
using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationBLL.Converters;
using VolunteerRegistrationBLL.Facade;
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

        public VolunteerBO Get(int Id)
        {
            throw new System.NotImplementedException();
        }

        public VolunteerBO Update(VolunteerBO bo)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}