using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationDAL.Entities;

namespace VolunteerRegistrationBLL.Converters
{
    internal class GuildConverter : IConverter<Guild, GuildBO>
    {
        private GuildWorkConverter _gwConverter = new GuildWorkConverter();
        public Guild Convert(GuildBO businessObject)
        {
            if (businessObject == null) return null;
            return new Guild
            {
                Id = businessObject.Id,
                Name = businessObject.Name,
                GuildWork = businessObject.GuildWork?.Select(_gwConverter.Convert).ToList()
            };
        }

        public GuildBO Convert(Guild entity)
        {
            if (entity == null) return null;
            return new GuildBO
            {
                Id = entity.Id,
                Name = entity.Name,
                VolunteerIds = entity.GuildWork?.Select(v => v.VolunteerId).ToList(),
                GuildWork = entity.GuildWork?.Select(_gwConverter.Convert).ToList()
            };
        }
    }
}
