using System.Collections.Generic;

namespace VolunteerRegistrationDAL.Entities
{
    public class Guild : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GuildWork> Volunteers { get; set; }
    }
}