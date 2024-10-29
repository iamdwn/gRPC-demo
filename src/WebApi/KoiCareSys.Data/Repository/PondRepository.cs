using KoiCareSys.Data.Base;
using KoiCareSys.Data.Models;
using KoiCareSys.Data.Repository.Interface;

namespace KoiCareSys.Data.Repository
{
    public class PondRepository : GenericRepository<Pond>, IPondRepository
    {
        public PondRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
