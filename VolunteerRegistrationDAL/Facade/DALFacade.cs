using System.Runtime.CompilerServices;
using VolunteerRegistrationDAL.UOW;

[assembly: InternalsVisibleTo("VRBDALTests")]
namespace VolunteerRegistrationDAL.Facade
{
    public class DALFacade : IDALFacade
    {
        private readonly DbOptions opt;

        public DALFacade(DbOptions opt)
        {
            this.opt = opt;
        }

        public IUnitOfWork UnitOfWork => new UnitOfWork(opt);
    }
}