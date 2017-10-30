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
            _mockGuildRepo.Setup(r => r.Create(It.IsAny<Guild>())).Returns(new Guild());
            var entity = _service.Create(new GuildBO());
            Assert.NotNull(entity);

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
            _mockGuildRepo.Setup(r => r.Get(It.IsAny<int>())).Returns(() => null);
            var nonExistingId = 0;
            var entity = _service.Get(nonExistingId);
            Assert.Null(entity);
        }
        [Fact]
        public override void NotConvertNullEntity()
        {
            var entity = _service.Create(null);
            Assert.Null(entity);
        }
        [Fact]
        public override void GetAllByExistingIds()
        {
            var guild = new GuildBO { Id = 1 };
            _mockGuildRepo.Setup(r => r.GetAll(It.IsAny<List<int>>())).Returns(new List<Guild> { new Guild() {Id = guild.Id} });
            var entities = _service.GetAll(new List<int>() {guild.Id});
            Assert.NotEmpty(entities);
        }
        [Fact]
        public override void NotGetAllByNonExistingIds()
        {
            _mockGuildRepo.Setup(r => r.GetAll(It.IsAny<List<int>>())).Returns(new List<Guild>{});
            var entities = _service.GetAll(new List<int>());
            Assert.Empty(entities);
        }
        [Fact]
        public override void DeleteByExistingId()
        {
            var entity = new GuildBO { Id = 1 };
            _mockGuildRepo.Setup(r => r.Delete(entity.Id)).Returns(new Guild() {Id = entity.Id});
            var deleted = _service.Delete(entity.Id);
            Assert.True(deleted);
        }
        [Fact]
        public override void NotDeleteByNonExistingId()
        {
            _mockGuildRepo.Setup(r => r.Delete(It.IsAny<int>())).Returns(() => null);
            var nonExistingId = 0;
            var deleted = _service.Delete(nonExistingId);
            Assert.False(deleted);
        }
        [Fact]
        public override void UpdateByExistingId()
        {
            var guild = new Guild() {Id = 1, Name = "One"};
            _mockGuildRepo.Setup(r => r.Get(guild.Id)).Returns(new Guild() {Id = guild.Id, Name = guild.Name});
            var guildToUpdate = _service.Get(guild.Id);
            var newName = "D4FF";
            guildToUpdate.Name = newName;
            var updatedGuild = _service.Update(guildToUpdate);
            Assert.Contains(updatedGuild.Name, newName);
        }
        [Fact]
        public override void NotUpdateByNonExistingId()
        {
            _mockGuildRepo.Setup(r => r.Get(It.IsAny<int>())).Returns(() => null);
            var nonExistingGuild = new GuildBO() {Id = 0};
            var entity = _service.Update(nonExistingGuild);
            Assert.Null(entity);
        }
    }
}
