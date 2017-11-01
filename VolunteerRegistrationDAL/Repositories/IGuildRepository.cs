using System;
using System.Collections.Generic;
using System.Text;
using VolunteerRegistrationDAL.Entities;

namespace VolunteerRegistrationDAL.Repositories
{
    public interface IGuildRepository : IRepository<Guild>
    {
        /// <summary>
        /// Get guilds parsed volunteer is in
        /// </summary>
        /// <param name="volunteerId"></param>
        /// <returns>List of Guilds, volunteer is in</returns>
        List<Guild> GetGuildsWithVolunteer(int volunteerId);
    }
}
