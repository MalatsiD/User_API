using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using User_API.Data;

namespace User_API.Models.CommunicationPreference.DAL
{
    public class CommunicationPreferenceDAL : DataConnection, ICommunicationPreferenceDAL
    {
        public async Task<bool> AddCommunicationPreference(CommunicationPreference communicationPreference)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", communicationPreference.Name);
                dynamicParameters.Add("@SortOrder", communicationPreference.SortOrder);
                dynamicParameters.Add("@Id", DbType.Int32, direction: ParameterDirection.Output);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_AddCommunicationPreference", dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                var isInserted = dynamicParameters.Get<int>("@Id") > 0;

                return isInserted;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCommunicationPreference(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string query = "DELETE FROM CommunicationPreferences WHERE Id = @Id";

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, query, dynamicParameters,
                    commandType: CommandType.Text);

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<CommunicationPreference> GetCommunicationPreference(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string query = "SELECT * FROM CommunicationPreferences WHERE Id = @Id";

                var result = await SqlMapper.QueryFirstOrDefaultAsync<CommunicationPreference>(dbConnection,
                    query, dynamicParameters, commandType: CommandType.Text);

                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CommunicationPreference>> GetCommunicationPreferences()
        {
            try
            {
                string query = "SELECT * FROM CommunicationPreferences";

                var result = await SqlMapper.QueryAsync<CommunicationPreference>(dbConnection,
                    query, commandType: CommandType.Text);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateCommunicationPreference(CommunicationPreference communicationPreference)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", communicationPreference.Name);
                dynamicParameters.Add("@SortOrder", communicationPreference.SortOrder);
                dynamicParameters.Add("@Id", communicationPreference.Id);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_UpdateCommunicationPreference", dynamicParameters,
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
