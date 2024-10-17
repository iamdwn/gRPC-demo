using KoiCareSys.Data.Base;
using KoiCareSys.Data.DAO;
using KoiCareSys.Data.Models;
using KoiCareSys.Data.Repository.Interface;

namespace KoiCareSys.Data.Repository
{
    public class UnitRepository : GenericRepository<Unit>, IUnitRepository
    {
        private readonly UnitDAO _dao;
        public UnitRepository()
        {
            _dao ??= new UnitDAO();
        }
    }
}
