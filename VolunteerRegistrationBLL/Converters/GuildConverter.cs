using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationDAL.Entities;

namespace VolunteerRegistrationBLL.Converters
{
    internal class GuildConverter : IConverter<Guild, GuildBO>
    {
        public Guild Convert(GuildBO businessObject)
        {
            if (businessObject == null) return null;
            return new Guild
            {
                Id = businessObject.Id,
                Name = businessObject.Name,
                Volunteers = businessObject.VolunteerIds?.Select(vId => new GuildWork
                {
                    GuildId = businessObject.Id,
                    VolunteerId = vId
                }).ToList()
            };
        }

        public GuildBO Convert(Guild entity)
        {
            if (entity == null) return null;
            return new GuildBO
            {
                Id = entity.Id,
                Name = entity.Name,
                VolunteerIds = entity.Volunteers?.Select(v => v.VolunteerId).ToList()
            };
        }
    }
}
