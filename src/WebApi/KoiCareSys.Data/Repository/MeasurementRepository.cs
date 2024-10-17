using KoiCareSys.Data.Base;
using KoiCareSys.Data.DAO;
using KoiCareSys.Data.Models;
using KoiCareSys.Data.Repository.Interface;

namespace KoiCareSys.Data.Repository
{
    public class MeasurementRepository : GenericRepository<Measurement>, IMeasurementRepository
    {
        private readonly MeasurementDAO _dao;
        public MeasurementRepository() 
        {
            _dao ??= new MeasurementDAO();
        }
    }
}
