using Microsoft.EntityFrameworkCore;
using VolunteerRegistrationDAL.Context;
using VolunteerRegistrationDAL.Repositories;

namespace VolunteerRegistrationDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VolunteerRegistrationContext _context;

        public IVolunteerRepository VolunteerRepository { get; }

        public UnitOfWork(DbOptions opt)
        {
            if (opt.Environment == "Development" && string.IsNullOrEmpty(opt.ConnectionString))
            {
                var optionsStatic = new DbContextOptionsBuilder<VolunteerRegistrationContext>()
                    .UseInMemoryDatabase("TheDB")
                    .Options;
                _context = new VolunteerRegistrationContext(optionsStatic);
            }
            else
            {
                var options = new DbContextOptionsBuilder<VolunteerRegistrationContext>()
                    .UseSqlServer(opt.ConnectionString)
                    .Options;
                _context = new VolunteerRegistrationContext(options);
            }

            VolunteerRepository = new VolunteerRepository(_context);
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