using KoiCareSys.Data.Base;
using KoiCareSys.Data.DAO;
using KoiCareSys.Data.Models;
using KoiCareSys.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KoiCareSys.Data.Repository
{
    public class FeedingScheduleRepository : GenericRepository<FeedingSchedule>, IFeedingScheduleRepository
    {
        private readonly FeedingScheduleDAO _dao;
        public FeedingScheduleRepository()
        {
            _dao ??= new FeedingScheduleDAO();
        }

        public async Task<FeedingSchedule> GetFeedingSchedule(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<FeedingSchedule>> GetAllFeedingSchedules()
        {
            return await GetAllAsync();
        }

        public async Task<IEnumerable<FeedingSchedule>> GetAllFeedingSchedules(string? search)
        {
            Expression<Func<FeedingSchedule, bool>> predicate = x => x.FoodType.Contains(search) || x.Note.Contains(search);
            IQueryable<FeedingSchedule> query = _dbSet.Where(predicate);
            return query.AsNoTracking().AsEnumerable();
        }

        public bool CreateFeedingSchedule(FeedingSchedule feedingSchedule)
        {
            FeedingSchedule create = new FeedingSchedule()
            {
                FeedAt = feedingSchedule.FeedAt,
                FoodAmount = feedingSchedule.FoodAmount,
                KoiId = feedingSchedule.KoiId

            };
            _dao.Create(create);
            return true;
        }

        public bool DeleteFeedingSchedule(Guid id)
        {
            FeedingSchedule found = _dao.GetById(id);
            if (found is null) return false;
            return true;
        }
    }
}
