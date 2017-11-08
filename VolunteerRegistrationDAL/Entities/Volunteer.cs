using System.Collections.Generic;

namespace VolunteerRegistrationDAL.Entities
{
    public class Volunteer : Person
    {
        public string Phone { get; set; }
        public List<GuildWork> Guilds { get; set; }

    }
}