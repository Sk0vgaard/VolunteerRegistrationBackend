using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VolunteerRegistrationDAL.Context;
using VolunteerRegistrationDAL.Entities;

namespace VolunteerRegistrationDAL.Repositories
{
    class GuildRepository : IGuildRepository
    {
        private readonly VolunteerRegistrationContext _context;

        public GuildRepository(VolunteerRegistrationContext context)
        {
            _context = context;
        }

        public Guild Create(Guild ent)
        {
            return _context.Guilds.Add(ent).Entity;
        }

        public IEnumerable<Guild> GetAll()
        {
            return _context.Guilds.Include(g => g.GuildWork).ToList();
        }

        public IEnumerable<Guild> GetAll(List<int> ids)
        {
            return _context.Guilds.Where(g => ids.Contains(g.Id)).ToList();

        }

        public Guild Get(int id)
        {
            return _context.Guilds.Include(g => g.GuildWork).FirstOrDefault(g => g.Id == id);
        }

        public Guild Delete(int Id)
        {
            var guild = _context.Guilds.FirstOrDefault(g => g.Id == Id);
            if (guild == null)
            {
                return null;
            }
            _context.Guilds.Remove(guild);
            return guild;
        }

        public List<Guild> GetGuildsWithIds(List<int> ids)
        {
            return _context.Guilds.Where(g => ids.Contains(g.Id)).ToList();
        }
    }
}
