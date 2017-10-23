namespace VolunteerRegistrationBLL.Converters
{
    internal interface IConverter<IEntity, IBusinessObject>
    {
        IEntity Convert(IBusinessObject businessObject);
        IBusinessObject Convert(IEntity entity);
    }
}