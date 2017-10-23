using System;
using System.Collections.Generic;

namespace VolunteerRegistrationBLL.Services
{
    public interface IService<IBusinessObject>
    {
        //C
        IBusinessObject Create(IBusinessObject bo);

        //R
        List<IBusinessObject> GetAll();

        IBusinessObject Get(int Id);

        //U
        IBusinessObject Update(IBusinessObject bo);

        //D
        Boolean Delete(int Id);
    }
}