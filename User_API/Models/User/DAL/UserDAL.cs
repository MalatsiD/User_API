using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.Data;

namespace User_API.Models.User.DAL
{
    public class UserDAL : DataConnection, IUserDAL
    {
        public Task<bool> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
