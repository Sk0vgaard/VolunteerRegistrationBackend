using Microsoft.EntityFrameworkCore;
using VolunteerRegistrationDAL.Entities;

namespace VolunteerRegistrationDAL.Context
{
    public class VolunteerRegistrationContext : DbContext
    {
        public VolunteerRegistrationContext(DbContextOptions<VolunteerRegistrationContext> options) : base(options)
        {

            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Volunteer> Volunteers { get; set; }
        
    }
}