using System;
using VolunteerRegistrationDAL.Repositories;

namespace VolunteerRegistrationDAL.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IVolunteerRepository VolunteerRepository { get;}

        int Complete();
    }
}