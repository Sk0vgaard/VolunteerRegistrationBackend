using System.Runtime.CompilerServices;
using VolunteerRegistrationDAL.Context;
using VolunteerRegistrationDAL.UOW;

[assembly: InternalsVisibleTo("VRBDALTests")]
namespace VolunteerRegistrationDAL.Facade
{
    public class DALFacade : IDALFacade
    {
        private readonly VolunteerRegistrationContext _context;

        public DALFacade(VolunteerRegistrationContext context)
        {
           _context = context;
        }

        public IUnitOfWork UnitOfWork => new UnitOfWork(_context);
    }
}