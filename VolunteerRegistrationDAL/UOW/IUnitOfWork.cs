using System;

namespace VolunteerRegistrationDAL
{
    public interface IUnitOfWork : IDisposable
    {
        //ICustomerRepository CustomerRepository { get; }

        int Complete();
    }
}