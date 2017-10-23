﻿using VolunteerRegistrationBLL.BusinessObjects;
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
                Name = businessObject.Name
            };
        }

        public VolunteerBO Convert(Volunteer entity)
        {
            if (entity == null) return null;

            return new VolunteerBO
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}