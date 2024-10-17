using KoiCareSys.Data.Base;
using KoiCareSys.Data.DAO;
using KoiCareSys.Data.Models;
using KoiCareSys.Data.Repository.Interface;

namespace KoiCareSys.Data.Repository
{
    public class MeasureDataRepository : GenericRepository<MeasureData>, IMeasureDataRepository
    {
        private readonly MeasureDataDAO _dao;
        public MeasureDataRepository()
        {
            _dao ??= new MeasureDataDAO();
        }
    }
}
