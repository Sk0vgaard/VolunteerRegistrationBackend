using System;
using System.Collections.Generic;
using System.Text;

namespace VolunteerRegistrationDAL.Entities
{
    public abstract class Person : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
