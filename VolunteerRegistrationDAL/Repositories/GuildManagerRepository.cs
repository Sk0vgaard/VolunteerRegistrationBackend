using System.Collections.Generic;
using System.Linq;
using VolunteerRegistrationDAL.Context;
using VolunteerRegistrationDAL.Entities;

namespace VolunteerRegistrationDAL.Repositories
{
    public class GuildManagerRepository: IGuildManagerRepository
    {
        private VolunteerRegistrationContext _context;
        public GuildManagerRepository(VolunteerRegistrationContext context)
        {
            _context = context;
        }
        public GuildManager Create(GuildManager ent)
        {
            return _context.GuildManagers.Add(ent).Entity;
        }

        public IEnumerable<GuildManager> GetAll()
        {
            return _context.GuildManagers.ToList();
        }

        public IEnumerable<GuildManager> GetAll(List<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public GuildManager Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public GuildManager Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}