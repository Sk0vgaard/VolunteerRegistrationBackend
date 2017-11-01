using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VolunteerRegistrationDAL.Context;
using VolunteerRegistrationDAL.Entities;

namespace VolunteerRegistrationDAL.Repositories
{
    internal class VolunteerRepository : IVolunteerRepository
    {
        private readonly VolunteerRegistrationContext _context;

        public VolunteerRepository(VolunteerRegistrationContext context)
        {
            _context = context;
        }

        public Volunteer Create(Volunteer ent)
        {
            return _context.Volunteers.Add(ent).Entity;
        }

        public IEnumerable<Volunteer> GetAll()
        {
            return _context.Volunteers.Include(v => v.Guilds).ToList();
        }

        public IEnumerable<Volunteer> GetAll(List<int> ids)
        {
            return _context.Volunteers.Where(v => ids.Contains(v.Id)).ToList();
        }

        public Volunteer Get(int id)
        {
            return _context.Volunteers.Include(v => v.Guilds).FirstOrDefault(v => v.Id == id);
        }

        public Volunteer Delete(int id)
        {
            var volunteerToDelete = _context.Volunteers.FirstOrDefault(v => v.Id == id);
            if (volunteerToDelete == null) return null;
            _context.Volunteers.Remove(volunteerToDelete);

            return volunteerToDelete;
        }

        public List<Volunteer> GetVolunteersWithIds(List<int> ids)
        {
            return _context.Volunteers.Where(v => ids.Contains(v.Id))
            .ToList();
        }
    }
}