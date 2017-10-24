namespace VolunteerRegistrationBLL.BusinessObjects
{
    public abstract class APersonBO : IBusinessObject
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}