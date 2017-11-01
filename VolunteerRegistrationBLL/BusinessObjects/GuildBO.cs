using System;
using System.Collections.Generic;
using System.Text;

namespace VolunteerRegistrationBLL.BusinessObjects
{
    public class GuildBO : IBusinessObject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<int> VolunteerIds { get; set; }
        public List<VolunteerBO> Volunteers { get; set; }
    }
}
