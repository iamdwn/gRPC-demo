using KoiCareSys.Data.Base;
using KoiCareSys.Data.DAO;
using KoiCareSys.Data.Models;
using KoiCareSys.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KoiCareSys.Data.Repository
{
    public class PondRepository : GenericRepository<Pond>, IPondRepository
    {
        private readonly PondDAO _dao;
        public PondRepository()
        {
            _dao ??= new PondDAO();
        }

        public async Task<Pond> GetPond(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<Pond>> GetPonds()
        {
            return await GetAllAsync();
        }

        public async Task<IEnumerable<Pond>> GetAllPond(string search)
        {
            Expression<Func<Pond, bool>> predicate = x => x.PondName.Contains(search) || x.Description.Contains(search);

            bool hasResults = await _dbSet.AnyAsync(predicate);

            if (!hasResults)
            {
                return Enumerable.Empty<Pond>();
            }

            IQueryable<Pond> query = _dbSet.Where(predicate);
            return await query.AsNoTracking().ToListAsync();
        }

    }
}
