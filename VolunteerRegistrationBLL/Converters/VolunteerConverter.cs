using System.Linq;
using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationDAL.Entities;

namespace VolunteerRegistrationBLL.Converters
{
    internal class VolunteerConverter : IConverter<Volunteer, VolunteerBO>
    {
        public Volunteer Convert(VolunteerBO businessObject)
        {
            if (businessObject == null) return null;

            return new Volunteer
            {
                Id = businessObject.Id,
                Name = businessObject.Name,
                Email = businessObject.Email,
                Phone = businessObject.Phone,
                Guilds = businessObject.GuildIds?.Select(gId => new GuildWork
                {
                    VolunteerId = businessObject.Id,
                    GuildId = gId
                }).ToList()
            };
        }

        public VolunteerBO Convert(Volunteer entity)
        {
            if (entity == null) return null;

            return new VolunteerBO
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                GuildIds = entity.Guilds?.Select(g => g.GuildId).ToList()
            };
        }
    }
}