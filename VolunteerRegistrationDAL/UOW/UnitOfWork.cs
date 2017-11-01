using Microsoft.EntityFrameworkCore;
using VolunteerRegistrationDAL.Context;
using VolunteerRegistrationDAL.Repositories;

namespace VolunteerRegistrationDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VolunteerRegistrationContext _context;
        public IGuildRepository GuildRepository { get; }

        public IVolunteerRepository VolunteerRepository { get; }

        public UnitOfWork(VolunteerRegistrationContext context)
        {
            _context = context;

            VolunteerRepository = new VolunteerRepository(_context);
            GuildRepository = new GuildRepository(_context);
        }

        public int Complete()
        {
            //The number of objects written to the underlying database.
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}