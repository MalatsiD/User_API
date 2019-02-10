using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using User_API.Data;

namespace User_API.Models.Occupation.DAL
{
    public class OccupationDAL : DataConnection, IOccupationDAL
    {
        public async Task<bool> AddOccupation(Occupation occupation)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Position", occupation.Position);
                dynamicParameters.Add("@StartDate", occupation.StartDate);
                dynamicParameters.Add("@EndDate", occupation.EndDate);
                dynamicParameters.Add("@Id", DbType.Int32, direction: ParameterDirection.Output);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_AddOccupation", dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                var isInserted = dynamicParameters.Get<int>("@Id") > 0;

                return isInserted;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteOccupation(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string delete = "DELETE FROM Occupations WHERE Id = @Id";

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, delete, dynamicParameters,
                    commandType: CommandType.Text);

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<Occupation> GetOccupation(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string query = "SELECT * FROM Occupations WHERE Id = @Id";

                var result = await SqlMapper.QueryFirstOrDefaultAsync<Occupation>(dbConnection, query,
                    dynamicParameters, commandType: CommandType.Text);

                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateOccupation(Occupation occupation)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Position", occupation.Position);
                dynamicParameters.Add("@StartDate", occupation.StartDate);
                dynamicParameters.Add("@EndDate", occupation.EndDate);
                dynamicParameters.Add("@Id", occupation.Id);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_UpdateOccupation", dynamicParameters,
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
