using System;

namespace VolunteerRegistrationDAL.Entities
{
    public class GuildWork
    {
        public int GuildId { get; set; }
        public Guild Guild { get; set; }
        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime End { get; set; }
    }
}