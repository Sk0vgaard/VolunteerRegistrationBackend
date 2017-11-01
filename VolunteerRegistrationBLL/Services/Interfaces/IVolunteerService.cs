using System.Collections.Generic;
using VolunteerRegistrationBLL.BusinessObjects;

namespace VolunteerRegistrationBLL.Services.Interfaces
{
    public interface IVolunteerService : IService<VolunteerBO>
    {
        List<VolunteerBO> GetVolunteersInGuild(int guildId);
    }
}