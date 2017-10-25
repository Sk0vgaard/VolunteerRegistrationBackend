using System.Collections.Generic;

namespace VolunteerRegistrationDAL.Repositories
{
    public interface IRepository<IEntity>
    {
        IEntity Create(IEntity ent);

        IEnumerable<IEntity> GetAll();

        IEnumerable<IEntity> GetAll(List<int> ids);

        IEntity Get(int id);

        IEntity Delete(int id);
    }
}