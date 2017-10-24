using System;
using System.Collections.Generic;
using System.Linq;
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

        private Volunteer CreateSecondMockVolunteer()
        {
            var mock = new Volunteer{Id = 2, Name = "Mock"};
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
            var createdEntity = CreateMockVolunteer();

            var entityInList = _repository.GetAll().FirstOrDefault(v => v == createdEntity);
            Assert.NotNull(entityInList);

            var deletedEntity = _repository.Delete(createdEntity.Id);
            _context.SaveChanges();

            entityInList = _repository.GetAll().FirstOrDefault(v => v == deletedEntity);
            Assert.Null(entityInList);
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
            var createdEntity = CreateMockVolunteer();
            CreateSecondMockVolunteer();

            var foundEntity = _repository.Get(createdEntity.Id);
            Assert.NotNull(foundEntity);
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
            var entityWithFalseId = _repository.Delete(3);

            Assert.Null(entityWithFalseId);
        }

        [Fact]
        public void NotGetAllByNonExistingIds()
        {
            CreateMockVolunteer();
            CreateSecondMockVolunteer();

            var entitiesWithFalseIds = _repository.GetAll(new List<int>{3,4});

            Assert.Empty(entitiesWithFalseIds);
        }

        [Fact]
        public void NotGetOneByNonExistingId()
        {
            CreateMockVolunteer();
            CreateSecondMockVolunteer();

            var entity = _repository.Get(3);

            Assert.Null(entity);
        }
    }
}