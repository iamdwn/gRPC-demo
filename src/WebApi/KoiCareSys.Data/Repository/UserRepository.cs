using KoiCareSys.Data.Base;
using KoiCareSys.Data.DAO;
using KoiCareSys.Data.DTO;
using KoiCareSys.Data.Models;
using KoiCareSys.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KoiCareSys.Data.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly UserDAO _dao;
        public UserRepository()
        {
            _dao ??= new UserDAO();
        }
        public async Task<User> GetUser(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await GetAllAsync();
        }

        public async Task<IEnumerable<User>> GetAllUser(string? search)
        {
            Expression<Func<User, bool>> predicate = x => x.FullName.Contains(search) || x.Email.Contains(search);
            IQueryable<User> query = _dbSet.Where(predicate);
            return query.AsNoTracking().AsEnumerable();
        }

        public bool CreateUser(RegisterNewUserDTO user)
        {
            User create = new User()
            {
                Email = user.Email,
                Password = user.Password,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                Status = user.Status,
            }; ;
            _dao.Create(create);
            return true;
        }

        public bool DeleteUser(Guid id)
        {
            User found = _dao.GetById(id);
            if (found is null) return false;
            return true;
        }

        public async Task<User> GetFirstUser()
        {
            return await GetFirstAsync();
        }
    }
}
