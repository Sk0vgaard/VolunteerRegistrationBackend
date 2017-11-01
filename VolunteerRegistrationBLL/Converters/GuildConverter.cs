using System;
using System.Collections.Generic;
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
                Name = businessObject.Name
            };
        }

        public GuildBO Convert(Guild entity)
        {
            if (entity == null) return null;
            return new GuildBO
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
