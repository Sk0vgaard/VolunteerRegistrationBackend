using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationDAL.Entities;

namespace VolunteerRegistrationBLL.Converters
{
    public class GuildWorkConverter : IConverter<GuildWork, GuildWorkBO>
    {
        public GuildWork Convert(GuildWorkBO businessObject)
        {
            if (businessObject == null) return null;

            return new GuildWork
            {
                GuildId = businessObject.GuildId,
                VolunteerId = businessObject.VolunteerId,
                Start = businessObject.Start,
                End = businessObject.End
            };
        }

        public GuildWorkBO Convert(GuildWork entity)
        {
            if (entity == null) return null;

            return new GuildWorkBO
            {
                GuildId = entity.GuildId,
                VolunteerId = entity.VolunteerId,
                Start = entity.Start,
                End = entity.End
            };
        }
    }
}