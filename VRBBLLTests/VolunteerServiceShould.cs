using System.Collections.Generic;
using Moq;
using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationBLL.Services;
using VolunteerRegistrationBLL.Services.Interfaces;
using VolunteerRegistrationDAL;
using VolunteerRegistrationDAL.Entities;
using VolunteerRegistrationDAL.Facade;
using VolunteerRegistrationDAL.Repositories;
using Xunit;

namespace VRBBLLTests
{
    public class VolunteerServiceShould : AServiceTest
    {
        // Declare Mock repository
        private readonly Mock<IVolunteerRepository> _mockVolunteerRepo;
        private readonly IVolunteerService _service;

        public VolunteerServiceShould()
        {
            // Instantiate our mock repository with a Strict behavior (Strict is a very clear way of testing, which is great for newcomers to unit testing!)
            _mockVolunteerRepo = new Mock<IVolunteerRepository>(MockBehavior.Strict);
            MockUOW.SetupGet(uow => uow.VolunteerRepository).Returns(_mockVolunteerRepo.Object);
            _service = new VolunteerService(MockDALFacade.Object);
        }

        [Fact]
        public override void CreateOne()
        {
            _mockVolunteerRepo.Setup(r => r.Create(It.IsAny<Volunteer>())).Returns(new Volunteer());

            var entity = _service.Create(new VolunteerBO());
            Assert.NotNull(entity);
        }

        [Fact]
        public override void GetAll()
        {
            _mockVolunteerRepo.Setup(r => r.GetAll()).Returns(new List<Volunteer>() {new Volunteer()});
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