using Microsoft.EntityFrameworkCore;
using VolunteerRegistrationDAL.Entities;

namespace VolunteerRegistrationDAL.Context
{
    public class VolunteerRegistrationContext : DbContext
    {
        public VolunteerRegistrationContext(DbContextOptions<VolunteerRegistrationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define new GuildWork with keys
            modelBuilder.Entity<GuildWork>()
                .HasKey(gw => new {gw.GuildId, gw.VolunteerId, gw.Start, gw.End});

            // Define Guild with relation and foreignkey
            modelBuilder.Entity<GuildWork>()
                .HasOne(gw => gw.Guild)
                .WithMany(v => v.GuildWork)
                .HasForeignKey(gw => gw.GuildId);

            // Define Volunteer with relation and foreignkey
            modelBuilder.Entity<GuildWork>()
                .HasOne(gw => gw.Volunteer)
                .WithMany(g => g.Guilds)
                .HasForeignKey(gw => gw.VolunteerId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Guild> Guilds { get; set; }    
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<GuildManager> GuildManagers { get; set; }
        
    }
}