using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationBLL.Services;
using VolunteerRegistrationBLL.Services.Interfaces;
using VolunteerRegistrationDAL.Entities;
using VolunteerRegistrationDAL.Repositories;
using Xunit;

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

        [Fact]
        public override void CreateOne()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public override void GetAll()
        {
            _mockGuildRepo.Setup(r => r.GetAll()).Returns(new List<Guild> {new Guild()});
            var entities = _service.GetAll();
            Assert.NotEmpty(entities);
        }
        [Fact]
        public override void GetOneByExistingId()
        {
            var guild = new GuildBO {Id = 1};
            _mockGuildRepo.Setup(r => r.Get(guild.Id)).Returns(new Guild {Id = guild.Id});
            var entity = _service.Get(guild.Id);
            Assert.NotNull(entity);
        }
        [Fact]
        public override void NotGetOneByNonExistingId()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public override void NotConvertNullEntity()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public override void GetAllByExistingIds()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public override void NotGetAllByNonExistingIds()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public override void DeleteByExistingId()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public override void NotDeleteByNonExistingId()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public override void UpdateByExistingId()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public override void NotUpdateByNonExistingId()
        {
            throw new NotImplementedException();
        }
    }
}
