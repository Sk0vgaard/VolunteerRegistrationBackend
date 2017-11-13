using System.Collections.Generic;
using Moq;
using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationBLL.Services;
using VolunteerRegistrationBLL.Services.Interfaces;
using VolunteerRegistrationDAL.Entities;
using VolunteerRegistrationDAL.Repositories;
using Xunit;

namespace VRBBLLTests
{
    public class GuildManagerServiceShould : AServiceTest
    {
        private readonly Mock<IGuildManagerRepository> _mockGMRepo;
        private readonly IGuildManagerService _service;

        public GuildManagerServiceShould()
        {
            _mockGMRepo = new Mock<IGuildManagerRepository>();
            MockUOW.SetupGet(uow => uow.GuildManagerRepository).Returns(_mockGMRepo.Object);
            _service = new GuildManagerService(MockDALFacade.Object);
        }

        private GuildManager MockGM = new GuildManager
        {
            Id = 1,
            Name = "Oliver with a Twist",
            Email = "Test@Twist.com"
        };

        private GuildManagerBO MockGMBO = new GuildManagerBO
        {
            Id = 1,
            Name = "Oliver with a Twist",
            Email = "Test@Twist.com"
        };
        [Fact]
        public override void CreateOne()
        {
            _mockGMRepo.Setup(r => r.Create(It.IsAny<GuildManager>())).Returns(() => MockGM);

            var entity = _service.Create(MockGMBO);
            Assert.NotNull(entity);
        }
        [Fact]
        public override void GetAll()
        {
            _mockGMRepo.Setup(r => r.GetAll()).Returns(() => new List<GuildManager>
            {
                MockGM
            });

            var entities = _service.GetAll();
            Assert.NotEmpty(entities);
        }
        [Fact]
        public override void GetOneByExistingId()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public override void NotGetOneByNonExistingId()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public override void NotConvertNullEntity()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public override void GetAllByExistingIds()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public override void NotGetAllByNonExistingIds()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public override void DeleteByExistingId()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public override void NotDeleteByNonExistingId()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public override void UpdateByExistingId()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public override void NotUpdateByNonExistingId()
        {
            throw new System.NotImplementedException();
        }
    }
}