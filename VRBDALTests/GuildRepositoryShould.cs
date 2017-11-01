using System;
using System.Collections.Generic;
using System.Linq;
using VolunteerRegistrationDAL.Context;
using VolunteerRegistrationDAL.Entities;
using VolunteerRegistrationDAL.Repositories;
using Xunit;

namespace VRBDALTests
{
    public class GuildRepositoryShould : IRepositoryTest
    {
        private readonly VolunteerRegistrationContext _context;
        private readonly GuildRepository _repository;

        public GuildRepositoryShould()
        {
            _context = TestContext.Context;
            _repository = new GuildRepository(_context);
        }

        private Guild CreateMockGuild()
        {
            var mock = new Guild {Id = 1, Name = "TEST"};
            var createdEntity = _repository.Create(mock);
            _context.SaveChanges();
            return createdEntity;
        }

        private Guild CreateSecondMockGuild()
        {
            var mock = new Guild {Id = 2, Name = "TEST2"};
            var createdEntity = _repository.Create(mock);
            _context.SaveChanges();
            return createdEntity;
        }

        [Fact]
        public void CreateOne()
        {
            var createdEntity = CreateMockGuild();
            Assert.NotNull(createdEntity);
        }

        [Fact]
        public void GetAll()
        {
            CreateMockGuild();
            var entities = _repository.GetAll();
            Assert.NotNull(entities);
            Assert.NotEmpty(entities);
        }

        [Fact]
        public void GetOneByExistingId()
        {
            CreateMockGuild();
            var entity = _repository.Get(1);
            Assert.NotNull(entity);
        }

        [Fact]
        public void NotGetOneByNonExistingId()
        {
            CreateMockGuild();
            var entity = _repository.Get(2);
            Assert.Null(entity);
        }

        [Fact]
        public void GetAllByExistingIds()
        {
            var firstGuild = CreateMockGuild();
            var secondGuild = CreateSecondMockGuild();
            var idList = new List<int>() {firstGuild.Id};
            var foundEntities = _repository.GetAll(idList);
            Assert.Contains(firstGuild, foundEntities);
            Assert.DoesNotContain(secondGuild, foundEntities);
        }

        [Fact]
        public void NotGetAllByNonExistingIds()
        {
            var firstGuild = CreateMockGuild();
            var secondGuild = CreateSecondMockGuild();
            var idList = new List<int>() {3, 4};
            var notFound = _repository.GetAll(idList);
            Assert.Empty(notFound);
        }

        [Fact]
        public void DeleteByExistingId()
        {
            var newGuild = CreateMockGuild();
            var guild = _repository.GetAll().FirstOrDefault(g => g.Id == newGuild.Id);
            Assert.NotNull(guild);
            _repository.Delete(guild.Id);
            _context.SaveChanges();
            var getAll = _repository.GetAll();
            Assert.Empty(getAll);
        }

        [Fact]
        public void NotDeleteByNonExistingId()
        {
            var guild = _repository.Delete(3);
            Assert.Null(guild);
        }

        [Fact]
        public void GetVolunteersWithExistingIds()
        {
            var listOfExistingIds = new List<int> { 1, 2 };
            CreateMockGuild();
            CreateSecondMockGuild();

            var guilds = _repository.GetGuildsWithIds(listOfExistingIds);

            Assert.NotEmpty(guilds);
            Assert.True(guilds.Count == 2);
        }
        [Fact]
        public void GetEmptyListOfVolunteersWithNonExistingIds()
        {
            var listOfExistingIds = new List<int> { 0 };

            var volunteers = _repository.GetGuildsWithIds(listOfExistingIds);

            Assert.Empty(volunteers);
        }
    }
}