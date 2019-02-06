using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using User_API.Data;

namespace User_API.Models.AddressType.DAL
{
    public class AddressTypeDAL : DataConnection, IAddressTypeDAL
    {
        public async Task<bool> AddAddressType(AddressType addressType)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Type", addressType.AddType);
                dynamicParameters.Add("@Id", DbType.Int32, direction: ParameterDirection.Output);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_AddAddressType", dynamicParameters, 
                    commandType: CommandType.StoredProcedure);

                bool isInserted = dynamicParameters.Get<int>("@Id") > 0;

                return isInserted;

            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAddressType(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string query = "DELETE FROM AddressTypes WHERE Id = @Id";

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, query, 
                    dynamicParameters, commandType: CommandType.Text);

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<AddressType> GetAddressType(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string query = "SELECT * FROM AddressTypes WHERE Id = @Id";

                var addressType = await SqlMapper.QueryFirstOrDefaultAsync<AddressType>(dbConnection, query,
                    dynamicParameters, commandType: CommandType.Text);

                return addressType;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AddressType>> GetAddressTypes()
        {
            try
            {
                string query = "SELECT * FROM AddressTypes";

                var addressType = await SqlMapper.QueryAsync<AddressType>(dbConnection, query,
                    commandType: CommandType.Text);

                return addressType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAddressType(AddressType addressType)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Type", addressType.AddType);
                dynamicParameters.Add("@Id", addressType.Id);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_UpdateAddressType", dynamicParameters,
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
