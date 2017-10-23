using Microsoft.EntityFrameworkCore;
using VolunteerRegistrationDAL.Context;

namespace VolunteerRegistrationDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private static DbContextOptions<EASVContext> optionsStatic;

        // public ICustomerRepository CustomerRepository { get; internal set; }
        private readonly EASVContext context;

        public UnitOfWork(DbOptions opt)
        {
            if (opt.Environment == "Development" && string.IsNullOrEmpty(opt.ConnectionString))
            {
                optionsStatic = new DbContextOptionsBuilder<EASVContext>()
                    .UseInMemoryDatabase("TheDB")
                    .Options;
                context = new EASVContext(optionsStatic);
            }
            else
            {
                var options = new DbContextOptionsBuilder<EASVContext>()
                    .UseSqlServer(opt.ConnectionString)
                    .Options;
                context = new EASVContext(options);
            }

            //CustomerRepository = new CustomerRepository(context);
        }

        public int Complete()
        {
            //The number of objects written to the underlying database.
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}