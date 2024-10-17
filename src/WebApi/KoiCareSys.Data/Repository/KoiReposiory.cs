using KoiCareSys.Data.Base;
using KoiCareSys.Data.DAO;
using KoiCareSys.Data.Models;
using KoiCareSys.Data.Repository.Interface;

namespace KoiCareSys.Data.Repository
{
    public class KoiReposiory : GenericRepository<Koi>, IKoiRepository
    {
        private readonly KoiDAO _dao;
        public KoiReposiory()
        {
            _dao ??= new KoiDAO();
        }
    }
}
