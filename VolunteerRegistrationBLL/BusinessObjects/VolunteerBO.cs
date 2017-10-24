using System.ComponentModel.DataAnnotations;

namespace VolunteerRegistrationBLL.BusinessObjects
{
    public class VolunteerBO : APersonBO
    {
        [Required]
        public string Phone { get; set; }

    }
}