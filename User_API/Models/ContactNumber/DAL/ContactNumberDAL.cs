using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.Data;
using Dapper;
using System.Data;

namespace User_API.Models.ContactNumber.DAL
{
    public class ContactNumberDAL : DataConnection, IContactNumberDAL
    {
        public async Task<bool> AddContactNumber(ContactNumber contactNumber)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ContactTypeId", contactNumber.ContactTypeId);
                dynamicParameters.Add("@Contact", contactNumber.Contact);
                dynamicParameters.Add("@UserId", contactNumber.UserId);
                dynamicParameters.Add("@Id", DbType.Int32, direction: ParameterDirection.Output);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_AddContactNumber",
                    dynamicParameters, commandType: CommandType.StoredProcedure);

                var isInserted = dynamicParameters.Get<int>("@Id") > 0;

                return isInserted;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteContactNumber(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string delete = "DELETE FROM ContactNumbers WHERE Id = @Id";

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, delete, dynamicParameters,
                    commandType: CommandType.Text);

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ContactNumber>> GetContactNumbers(int userId)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserId", userId);

                string query = "SELECT * FROM ContactNumbers WHERE UserId = @UserId";

                var results = await SqlMapper.QueryAsync<ContactNumber>(dbConnection, query, dynamicParameters,
                    commandType: CommandType.Text);

                return results;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateContactNumber(ContactNumber contactNumber)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ContactTypeId", contactNumber.ContactTypeId);
                dynamicParameters.Add("@Contact", contactNumber.Contact);
                dynamicParameters.Add("@UserId", contactNumber.UserId);
                dynamicParameters.Add("@Id", contactNumber.Id);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_UpdateContactNumber",
                    dynamicParameters, commandType: CommandType.StoredProcedure);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
