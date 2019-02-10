using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Models.User.DAL
{
    public interface IUserDAL
    {
        Task<bool> AddUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User> GetUser(int id);
    }
}
