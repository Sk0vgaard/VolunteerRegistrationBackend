using System.Collections.Generic;
using Moq;
using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationBLL.Facade;
using VolunteerRegistrationBLL.Services;
using VolunteerRegistrationDAL.Facade;
using VolunteerRegistrationRestAPI.Controllers;
using Xunit;

namespace VRBRestAPITests
{
    public class VolunteersControllerShould : IControllerTest
    {
        private readonly Mock<IVolunteerService> _mockVolunteerService;
        private readonly VolunteersController _controller;

        public VolunteersControllerShould()
        {
            var mockBLLFacade = new Mock<IBLLFacade>();
            _mockVolunteerService = new Mock<IVolunteerService>();
            mockBLLFacade.SetupGet(f => f.VolunteerService).Returns(_mockVolunteerService.Object);
            _controller = new VolunteersController(mockBLLFacade.Object);
        }

        [Fact]
        public void GetAll()
        {
            _mockVolunteerService.Setup(s => s.GetAll()).Returns(new List<VolunteerBO>());

            var entities = _controller.Get();

            Assert.NotNull(entities);
        }
        [Fact]
        public void GetByExistingId()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void NotGetByNonExistingId_ReturnNotFound()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void PostWithValidObject()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void NotPostWithInvalidObject_ReturnBadRequest()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void NotPostWithNull_ReturnBadRequest()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void UpdateWithValidObject_ReturnOk()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void NotUpdateWithNull_ReturnBadRequest()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void NotUpdateWithMisMatchingIds_ReturnBadRequest()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void NotUpdateWithInvalidObject_ReturnBadRequest()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void NotUpdateWithNonExistingId_ReturnNotFound()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void DeleteByExistingId_ReturnOk()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void NotDeleteByNonExistingId_ReturnNotFound()
        {
            throw new System.NotImplementedException();
        }
    }
}