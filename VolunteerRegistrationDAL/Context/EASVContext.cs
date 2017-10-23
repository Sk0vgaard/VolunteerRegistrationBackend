using Microsoft.EntityFrameworkCore;

namespace VolunteerRegistrationDAL.Context
{
    internal class EASVContext : DbContext
    {
        public EASVContext(DbContextOptions<EASVContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<Entity> Entites { get; set; }
    }
}