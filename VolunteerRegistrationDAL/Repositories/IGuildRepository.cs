using System;
using System.Collections.Generic;
using System.Text;
using VolunteerRegistrationDAL.Entities;

namespace VolunteerRegistrationDAL.Repositories
{
    public interface IGuildRepository : IRepository<Guild>
    {
        /// <summary>
        /// Get guilds with ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>List of Guilds</returns>
        List<Guild> GetGuildsWithIds(List<int> ids);

    }
}
