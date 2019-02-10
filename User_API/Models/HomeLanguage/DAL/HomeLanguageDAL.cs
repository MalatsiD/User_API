using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using User_API.Data;

namespace User_API.Models.HomeLanguage.DAL
{
    public class HomeLanguageDAL : DataConnection, IHomeLanguageDAL
    {
        public async Task<bool> AddHomeLanguage(HomeLanguage homeLanguage)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", homeLanguage.Name);
                dynamicParameters.Add("@SortOrder", homeLanguage.SortOrder);
                dynamicParameters.Add("@Id", DbType.Int32, direction: ParameterDirection.Output);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_AddHomeLanguage", dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                var isInserted = dynamicParameters.Get<int>("@Id") > 0;

                return isInserted;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteHomeLanguage(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string delete = "DELETE FROM HomeLanguages WHERE Id = @Id";

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, delete, dynamicParameters,
                    commandType: CommandType.Text);

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<HomeLanguage> GetHomeLanguage(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string query = "SELECT * FROM HomeLanguages WHERE Id = @Id";

                var result = await SqlMapper.QueryFirstOrDefaultAsync<HomeLanguage>(dbConnection, query, 
                    dynamicParameters, commandType: CommandType.Text);

                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateHomeLanguage(HomeLanguage homeLanguage)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", homeLanguage.Name);
                dynamicParameters.Add("@SortOrder", homeLanguage.SortOrder);
                dynamicParameters.Add("@Id", homeLanguage.Id);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_UpdateHomeLanguage", dynamicParameters,
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
