using System;
using VolunteerRegistrationDAL.Context;
using VolunteerRegistrationDAL.Entities;
using VolunteerRegistrationDAL.Repositories;
using Xunit;

namespace VRBDALTests
{
    public class GuildManagerRepositoryShould : IRepositoryTest
    {
        public GuildManagerRepositoryShould()
        {
            _context = TestContext.Context;
            _repository = new GuildManagerRepository(_context);
        }

        private readonly VolunteerRegistrationContext _context;
        private readonly GuildManagerRepository _repository;


        private GuildManager CreateMockGM()
        {
            var gm = _repository.Create(new GuildManager {Id = 1});
            _context.SaveChanges();
            return gm;
        }

        [Fact]
        public void CreateOne()
        {
            var entity = CreateMockGM();
            Assert.NotNull(entity);
        }

        [Fact]
        public void DeleteByExistingId()
        {
            var entityToDelete = CreateMockGM();
            _repository.Delete(entityToDelete.Id);
            _context.SaveChanges();
            var deletedEntity = _repository.Get(entityToDelete.Id);
            Assert.Null(deletedEntity);
        }

        [Fact]
        public void GetAll()
        {
            CreateMockGM();
            var entities = _repository.GetAll();
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
            var createdEntity = CreateMockGM();
            var entity = _repository.Get(createdEntity.Id);
            Assert.NotNull(entity);
        }

        [Fact]
        public void NotDeleteByNonExistingId()
        {
            var deletedEntity = _repository.Get(0);
            Assert.Null(deletedEntity);
        }

        [Fact]
        public void NotGetAllByNonExistingIds()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void NotGetOneByNonExistingId()
        {
            var entity = _repository.Get(0);
            Assert.Null(entity);
        }
    }
}