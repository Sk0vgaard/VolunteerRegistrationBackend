using System;
using System.Collections.Generic;

namespace VolunteerRegistrationBLL.Services.Interfaces
{
    public interface IService<IBusinessObject>
    {
        //C
        IBusinessObject Create(IBusinessObject bo);

        //R
        List<IBusinessObject> GetAll();

        List<IBusinessObject> GetAll(List<int> ids);

        IBusinessObject Get(int id);

        //U
        IBusinessObject Update(IBusinessObject bo);

        //D
        Boolean Delete(int id);
    }
}