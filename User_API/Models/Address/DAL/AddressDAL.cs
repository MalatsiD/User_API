using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using User_API.Data;

namespace User_API.Models.Address.DAL
{
    public class AddressDAL : DataConnection, IAddressDAL
    {
        public async Task<bool> AddAddress(Address address)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@AddressTypeId", address.AddressTypeId);
                dynamicParameters.Add("@StreetAddress", address.StreetAddress);
                dynamicParameters.Add("@Town", address.Town);
                dynamicParameters.Add("@Code", address.Code);
                dynamicParameters.Add("@UserId", address.UserId);
                dynamicParameters.Add("@Id", DbType.Int32, direction: ParameterDirection.Output);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_AddAddress", dynamicParameters, commandType: CommandType.StoredProcedure);

                bool inserted = dynamicParameters.Get<int>("@Id") > 0;

                return inserted;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAddres(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string query = "DELETE FROM Addresses WHERE Id = @Id";

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, query, 
                    dynamicParameters, commandType: CommandType.Text);

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Address>> GetAddresses(int userId)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserId", userId);

                string query = "SELECT * FROM Addresses WHERE UserId = @UserId";

                var addresses = await SqlMapper.QueryAsync<Address>(dbConnection, query, 
                    dynamicParameters, commandType: CommandType.Text);

                return addresses;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAddress(Address address)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@AddressTypeId", address.AddressTypeId);
                dynamicParameters.Add("@StreetAddress", address.StreetAddress);
                dynamicParameters.Add("@Town", address.Town);
                dynamicParameters.Add("@Code", address.Code);
                dynamicParameters.Add("@UserId", address.UserId);
                dynamicParameters.Add("@Id", address.Id);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_UpdateAddress", dynamicParameters, 
                    commandType: CommandType.StoredProcedure);

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
