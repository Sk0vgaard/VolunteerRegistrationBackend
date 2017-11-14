using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationDAL.Entities;

namespace VolunteerRegistrationBLL.Converters
{
    public class GuildManagerConverter : IConverter<GuildManager, GuildManagerBO>
    {
        public GuildManager Convert(GuildManagerBO businessObject)
        {
            if (businessObject == null) return null;
            return new GuildManager
            {
                Id = businessObject.Id,
                Name = businessObject.Name,
                Email = businessObject.Email
            };
        }

        public GuildManagerBO Convert(GuildManager entity)
        {
            if (entity == null) return null;
            return new GuildManagerBO
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email
            };
        }
    }
}