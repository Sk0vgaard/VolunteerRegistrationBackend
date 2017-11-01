using System;
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
    public class VolunteerServiceShould : AServiceTest
    {
        public VolunteerServiceShould()
        {
            // Instantiate our mock repository with a Strict behavior (Strict is a very clear way of testing, which is great for newcomers to unit testing!)
            _mockVolunteerRepo = new Mock<IVolunteerRepository>();
            MockUOW.SetupGet(uow => uow.VolunteerRepository).Returns(_mockVolunteerRepo.Object);
            _service = new VolunteerService(MockDALFacade.Object);
        }

        // Declare Mock repository
        private readonly Mock<IVolunteerRepository> _mockVolunteerRepo;

        private readonly IVolunteerService _service;

        [Fact]
        public override void CreateOne()
        {
            _mockVolunteerRepo.Setup(r => r.Create(It.IsAny<Volunteer>())).Returns(new Volunteer());

            var entity = _service.Create(new VolunteerBO());
            Assert.NotNull(entity);
        }

        [Fact]
        public override void DeleteByExistingId()
        {
            var entity = new VolunteerBO{Id = 1};
            _mockVolunteerRepo.Setup(r => r.Delete(entity.Id)).Returns(new Volunteer{Id = 1});
            _mockVolunteerRepo.Setup(r => r.Get(It.IsAny<int>())).Returns(new Volunteer());
            
            var deleted = _service.Delete(entity.Id);

            Assert.True(deleted);
        }

        [Fact]
        public override void GetAll()
        {
            _mockVolunteerRepo.Setup(r => r.GetAll()).Returns(new List<Volunteer> {new Volunteer()});
            var entities = _service.GetAll();
            Assert.NotEmpty(entities);
        }

        [Fact]
        public override void GetAllByExistingIds()
        {
            var volunteerOne = new VolunteerBO { Id = 1, Name = "One"};
            var volunteerTwo = new VolunteerBO { Id = 2, Name = "Two"};
            _mockVolunteerRepo.Setup(r => r.Create(It.IsAny<Volunteer>())).Returns(new Volunteer());

            _service.Create(volunteerOne);
            _service.Create(volunteerTwo);

            var existingEntityIds = new List<int>{volunteerOne.Id, volunteerTwo.Id};
            _mockVolunteerRepo.Setup(r => r.GetAll(existingEntityIds)).Returns(new List<Volunteer>
            {
                new Volunteer
                {
                    Id = 1, Name = "One"
                    
                },
                new Volunteer
                {
                    Id = 2, Name = "Two"
                    
                }
            });

            var existingEntities = _service.GetAll(existingEntityIds);

            Assert.NotEmpty(existingEntities);
            Assert.True(existingEntities[0].Id == 1);
        }

        [Fact]
        public override void GetOneByExistingId()
        {
            var volunteer = new VolunteerBO{Id = 1};
            _mockVolunteerRepo.Setup(r => r.Get(volunteer.Id)).Returns(new Volunteer {Id = 1});

            var entity = _service.Get(volunteer.Id);

            Assert.NotNull(entity);
        }

        [Fact]
        public override void NotConvertNullEntity()
        {
            var entity = _service.Create(null);

            Assert.Null(entity);
        }

        [Fact]
        public override void NotDeleteByNonExistingId()
        {
            _mockVolunteerRepo.Setup(r => r.Delete(It.IsAny<int>())).Returns(() => null);

            var deletedEntity = _service.Delete(0);

            Assert.False(deletedEntity);
        }

        [Fact]
        public override void NotGetAllByNonExistingIds()
        {
            _mockVolunteerRepo.Setup(r => r.GetAll(It.IsAny<List<int>>())).Returns(new List<Volunteer>());

            var entities = _service.GetAll(new List<int>());

            Assert.Empty(entities);
        }

        [Fact]
        public override void NotGetOneByNonExistingId()
        {
            _mockVolunteerRepo.Setup(r => r.Get(It.IsAny<int>())).Returns(() => null);

            var nonExistingId = 0;
            var entity = _service.Get(nonExistingId);

            Assert.Null(entity);
        }

        [Fact]
        public override void NotUpdateByNonExistingId()
        {
            _mockVolunteerRepo.Setup(r => r.Get(It.IsAny<int>())).Returns(() => null);

            var entity = _service.Update(new VolunteerBO());

            Assert.Null(entity);
        }

        [Fact]
        public override void UpdateByExistingId()
        {
            var entity = new Volunteer{Id = 1, Name = "One"};
            _mockVolunteerRepo.Setup(r => r.Get(entity.Id)).Returns(new Volunteer
            {
                Id = 1,
                Name = "One"
            });

            var entityToUpdate = _service.Get(entity.Id);

            var newName = "D4FF";
            entityToUpdate.Name = newName;

            var updatedEntity = _service.Update(entityToUpdate);

            Assert.Contains(newName, updatedEntity.Name);
        }

        [Fact]
        public void GetVolunteersInGuild()
        {
            _mockVolunteerRepo.Setup(r => r.GetVolunteersInGuild(1)).Returns(new List<Volunteer>
            {
                new Volunteer
                {
                    Id = 1,
                    Guilds = new List<GuildWork>{new GuildWork { GuildId = 1, VolunteerId = 1} }
                }
            });

            var volunteersInGuild = _service.GetVolunteersInGuild(1);

            Assert.NotEmpty(volunteersInGuild);
        }

        [Fact]
        public void GetEmptyListOfVolunteersInGuildWithNoVolunteers()
        {
            _mockVolunteerRepo.Setup(r => r.GetVolunteersInGuild(1)).Returns(new List<Volunteer>());

            var volunteersInGuild = _service.GetVolunteersInGuild(1);

            Assert.Empty(volunteersInGuild);
        }
    }
}