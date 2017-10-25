using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using VolunteerRegistrationBLL.Services;
using VolunteerRegistrationBLL.Services.Interfaces;
using VolunteerRegistrationDAL.Repositories;

namespace VRBBLLTests
{
    public class GuildServiceShould : AServiceTest
    {
        private readonly Mock<IGuildRepository> _mockGuildRepo;
        private readonly IGuildService _service;

        public GuildServiceShould()
        {
            _mockGuildRepo = new Mock<IGuildRepository>();
            MockUOW.SetupGet(uow => uow.GuildRepository).Returns(_mockGuildRepo.Object);
            _service = new GuildService(MockDALFacade.Object);
        }

        public override void CreateOne()
        {
            throw new NotImplementedException();
        }

        public override void GetAll()
        {
            throw new NotImplementedException();
        }

        public override void GetOneByExistingId()
        {
            throw new NotImplementedException();
        }

        public override void NotGetOneByNonExistingId()
        {
            throw new NotImplementedException();
        }

        public override void NotConvertNullEntity()
        {
            throw new NotImplementedException();
        }

        public override void GetAllByExistingIds()
        {
            throw new NotImplementedException();
        }

        public override void NotGetAllByNonExistingIds()
        {
            throw new NotImplementedException();
        }

        public override void DeleteByExistingId()
        {
            throw new NotImplementedException();
        }

        public override void NotDeleteByNonExistingId()
        {
            throw new NotImplementedException();
        }

        public override void UpdateByExistingId()
        {
            throw new NotImplementedException();
        }

        public override void NotUpdateByNonExistingId()
        {
            throw new NotImplementedException();
        }
    }
}
