using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VolunteerRegistrationDAL.Entities;

namespace VolunteerRegistrationDAL.Repositories
{
    public interface IVolunteerRepository : IRepository<Volunteer>
    {
        /// <summary>
        /// Get volunteeers in parsed guild
        /// </summary>
        /// <param name="guildId"></param>
        /// <returns>List of volunteers in guild</returns>
        List<Volunteer> GetVolunteersInGuild(int guildId);
    }
}