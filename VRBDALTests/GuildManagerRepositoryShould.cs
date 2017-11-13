using VolunteerRegistrationDAL.Context;
using VolunteerRegistrationDAL.Entities;
using VolunteerRegistrationDAL.Repositories;
using Xunit;

namespace VRBDALTests
{
    public class GuildManagerRepositoryShould : IRepositoryTest
    {
        private readonly VolunteerRegistrationContext _context;
        private readonly GuildManagerRepository _repository;

        public GuildManagerRepositoryShould()
        {
            _context = TestContext.Context;
            _repository = new GuildManagerRepository(_context);
        }


        
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
        public void GetAll()
        {
            CreateMockGM();
            var entities = _repository.GetAll();
            Assert.NotEmpty(entities);
        }
        [Fact]
        public void GetOneByExistingId()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void NotGetOneByNonExistingId()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void GetAllByExistingIds()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void NotGetAllByNonExistingIds()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void DeleteByExistingId()
        {
            throw new System.NotImplementedException();
        }
        [Fact]
        public void NotDeleteByNonExistingId()
        {
            throw new System.NotImplementedException();
        }
    }
}