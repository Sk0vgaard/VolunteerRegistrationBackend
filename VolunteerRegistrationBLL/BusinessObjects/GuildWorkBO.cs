using System;

namespace VolunteerRegistrationBLL.BusinessObjects
{
    public class GuildWorkBO
    {

        public int GuildId { get; set; }
        public int VolunteerId { get; set; }
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime End { get; set; }
    }
}