using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using User_API.Data;

namespace User_API.Models.User.DAL
{
    public class UserDAL : DataConnection, IUserDAL
    {
        public async Task<bool> AddUser(User user)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@DateCreated", user.DateCreated);
                dynamicParameters.Add("@DateModified", user.DateModified);
                dynamicParameters.Add("@PersonId", user.PersonId);
                dynamicParameters.Add("@Username", user.Username);
                dynamicParameters.Add("@PasswordHash", user.PasswordHash);
                dynamicParameters.Add("@PasswordSalt", user.PasswordSalt);
                dynamicParameters.Add("@Id", DbType.Int32, direction: ParameterDirection.Output);

                await SqlMapper.ExecuteAsync(dbConnection, "sp_AddUser", dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                var isInserted = dynamicParameters.Get<int>("@Id") > 0;

                return isInserted;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string delete = "DELETE FROM Users WHERE Id = @Id";

                await SqlMapper.ExecuteAsync(dbConnection, delete, dynamicParameters,
                    commandType: CommandType.Text);

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string delete = "SELECT * FROM Users WHERE Id = @Id";

                var user = await SqlMapper.QueryFirstOrDefaultAsync<User>(dbConnection, delete, dynamicParameters,
                    commandType: CommandType.Text);

                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@DateModified", user.DateModified);
                dynamicParameters.Add("@PersonId", user.PersonId);
                dynamicParameters.Add("@Username", user.Username);
                dynamicParameters.Add("@PasswordHash", user.PasswordHash);
                dynamicParameters.Add("@PasswordSalt", user.PasswordSalt);
                dynamicParameters.Add("@Id", user.Id);

                await SqlMapper.ExecuteAsync(dbConnection, "sp_UpdateUser", dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
