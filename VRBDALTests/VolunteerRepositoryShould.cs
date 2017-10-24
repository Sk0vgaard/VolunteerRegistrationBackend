using System;
using VolunteerRegistrationDAL.Context;
using VolunteerRegistrationDAL.Entities;
using VolunteerRegistrationDAL.Repositories;
using Xunit;

namespace VRBDALTests
{
    public class VolunteerRepositoryShould : IRepositoryTest
    {
        public VolunteerRepositoryShould()
        {
            _context = TestContext.Context;
            _repository = new VolunteerRepository(_context);
        }

        private readonly VolunteerRegistrationContext _context;
        private readonly VolunteerRepository _repository;

        private Volunteer CreateMockVolunteer()
        {
            var mock = new Volunteer {Id = 1, Name = "Test"};
            var createdEntity = _repository.Create(mock);
            _context.SaveChanges();
            return createdEntity;
        }

        [Fact]
        public void CreateOne()
        {
            var createdEntity = CreateMockVolunteer();

            Assert.NotNull(createdEntity);
        }

        [Fact]
        public void DeleteByExistingId()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetAll()
        {
            CreateMockVolunteer();
            var entities = _repository.GetAll();

            Assert.NotNull(entities);
            Assert.NotEmpty(entities);
        }

        [Fact]
        public void GetAllByExistingIds()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void GetOneByExistingId()
        {
            CreateMockVolunteer();
            var entity = _repository.Get(1);
            Assert.NotNull(entity);
        }

        [Fact]
        public void NotDeleteByNonExistingId()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void NotGetAllByNonExistingIds()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void NotGetOneByNonExistingId()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void NotUpdateByNonExistingId()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void UpdateByExistingId()
        {
            throw new NotImplementedException();
        }
    }
}