using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VolunteerRegistrationDAL.Entities;

namespace VolunteerRegistrationDAL.Repositories
{
    public interface IVolunteerRepository : IRepository<Volunteer>
    {
        /// <summary>
        /// Get volunteeers with ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>List of volunteers</returns>
        List<Volunteer> GetVolunteersWithIds(List<int> ids);
    }
}