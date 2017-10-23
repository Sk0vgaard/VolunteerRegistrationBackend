using VolunteerRegistrationDAL.UOW;

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