using System.Collections.Generic;

namespace VolunteerRegistrationDAL
{
    public interface IRepository<IEntity>
    {
        IEntity Create(IEntity ent);

        IEnumerable<IEntity> GetAll();

        IEnumerable<IEntity> GetAll(List<int> ids);

        IEntity Get(int Id);

        IEntity Delete(int Id);
    }
}