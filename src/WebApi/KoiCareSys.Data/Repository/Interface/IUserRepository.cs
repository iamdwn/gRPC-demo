using KoiCareSys.Data.DTO;
using KoiCareSys.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiCareSys.Data.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUser(Guid id);
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetAllUser(String search);
        bool CreateUser(RegisterNewUserDTO user);
        bool DeleteUser(Guid id);
    }
}
