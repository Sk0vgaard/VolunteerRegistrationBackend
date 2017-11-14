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
            var createdEntity = MockGM;
            _mockGMRepo.Setup(r => r.Get(createdEntity.Id)).Returns(() => createdEntity);

            var entity = _service.Get(createdEntity.Id);
            Assert.NotNull(entity);
        }
        [Fact]
        public override void NotGetOneByNonExistingId()
        {
            var entity = _service.Get(0);
            Assert.Null(entity);
        }
        [Fact]
        public override void NotConvertNullEntity()
        {
            // TODO ALH: Implement

        }
        [Fact]
        public override void GetAllByExistingIds()
        {
            // TODO ALH: Implement

        }
        [Fact]
        public override void NotGetAllByNonExistingIds()
        {
            // TODO ALH: Implement

        }
        [Fact]
        public override void DeleteByExistingId()
        {
            var createdEntity = MockGM;
            _mockGMRepo.Setup(r => r.Get(createdEntity.Id)).Returns(createdEntity);
            _mockGMRepo.Setup(r => r.Delete(createdEntity.Id)).Returns(createdEntity);

            var deletedEntity = _service.Delete(createdEntity.Id);

            Assert.True(deletedEntity);
        }
        [Fact]
        public override void NotDeleteByNonExistingId()
        {
            var deletedEntity = _service.Delete(0);

            Assert.False(deletedEntity);
        }
        [Fact]
        public override void UpdateByExistingId()
        {
            var createdEntity = MockGM;
            _mockGMRepo.Setup(r => r.Get(createdEntity.Id)).Returns(createdEntity);
            var entityToUpdate = MockGMBO;
            var updatedName = "Updated";
            entityToUpdate.Name = updatedName;
            _service.Update(entityToUpdate);
            var updatedEntity = _service.Get(createdEntity.Id);
            Assert.Equal(updatedName, updatedEntity.Name);
        }
        [Fact]
        public override void NotUpdateByNonExistingId()
        {
            var entityToUpdate = new GuildManagerBO{Id = 2};
            var updatedName = "Updated";
            entityToUpdate.Name = updatedName;
            _service.Update(entityToUpdate);
            var updatedEntity = _service.Get(entityToUpdate.Id);
            Assert.Null(updatedEntity);
        }
    }
}