using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using User_API.Data;

namespace User_API.Models.OccupationalStatus.DAL
{
    public class OccupationalStatusDAL : DataConnection, IOccupationalStatusDAL
    {
        public async Task<bool> AddOccupationalStatus(OccupationalStatus occupationalStatus)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", occupationalStatus.Name);
                dynamicParameters.Add("@SortOrder", occupationalStatus.SortOrder);
                dynamicParameters.Add("@Id", DbType.Int32, direction: ParameterDirection.Output);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_AddOccupationalStatus", dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                var isInserted = dynamicParameters.Get<int>("@Id") > 0;

                return isInserted;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteOccupationalStatus(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string delete = "DELETE FROM OccupationalStatuses WHERE Id = @Id";

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, delete, dynamicParameters,
                    commandType: CommandType.Text);

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<OccupationalStatus> GetOccupationalStatus(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string query = "SELECT * FROM OccupationalStatuses";

                var result = await SqlMapper.QueryFirstOrDefaultAsync<OccupationalStatus>(dbConnection, query,
                    dynamicParameters, commandType: CommandType.Text);

                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<OccupationalStatus>> GetOccupationalStatuses()
        {
            try
            {
                string query = "SELECT * FROM OccupationalStatuses";

                var result = await SqlMapper.QueryAsync<OccupationalStatus>(dbConnection, query,
                    commandType: CommandType.Text);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateOccupationalStatus(OccupationalStatus occupationalStatus)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", occupationalStatus.Name);
                dynamicParameters.Add("@SortOrder", occupationalStatus.SortOrder);
                dynamicParameters.Add("@Id", occupationalStatus.Id);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_UpdateOccupationalStatus", dynamicParameters,
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
