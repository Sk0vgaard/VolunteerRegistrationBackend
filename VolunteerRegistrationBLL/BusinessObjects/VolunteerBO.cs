using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VolunteerRegistrationBLL.BusinessObjects
{
    public class VolunteerBO : APersonBO
    {
        [Required]
        public string Phone { get; set; }

        public List<int> GuildIds { get; set; }
        public List<GuildBO> Guilds { get; set; }

    }
}