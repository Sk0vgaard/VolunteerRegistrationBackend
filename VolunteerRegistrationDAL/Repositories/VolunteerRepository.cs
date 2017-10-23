using System.Collections.Generic;
using System.Linq;
using VolunteerRegistrationDAL.Context;
using VolunteerRegistrationDAL.Entities;

namespace VolunteerRegistrationDAL.Repositories
{
    internal class VolunteerRepository : IVolunteerRepository
    {
        private VolunteerRegistrationContext _context;

        public VolunteerRepository(VolunteerRegistrationContext context)
        {
            _context = context;
        }

        public Volunteer Create(Volunteer ent)
        {
            return _context.volunteers.Add(ent).Entity;
        }

        public IEnumerable<Volunteer> GetAll()
        {
            return _context.volunteers.ToList();
        }

        public IEnumerable<Volunteer> GetAll(List<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public Volunteer Get(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Volunteer Delete(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}