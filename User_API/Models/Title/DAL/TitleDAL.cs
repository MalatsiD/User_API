using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using User_API.Data;

namespace User_API.Models.Title.DAL
{
    public class TitleDAL : DataConnection, ITitleDAL
    {
        public async Task<bool> AddTitle(Title title)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", title.Name);
                dynamicParameters.Add("@SortOrder", title.SortOrder);
                dynamicParameters.Add("@Id", DbType.Int32, direction: ParameterDirection.Output);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_AddTitle", dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                var isInserted = dynamicParameters.Get<int>("@Id") > 0;

                return isInserted;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteTitle(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string delete = "DELETE FROM Titles WHERE Id = @Id";

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, delete, dynamicParameters,
                    commandType: CommandType.Text);

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<Title> GetTitle(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string query = "SELECT * FROM Titles WHERE Id = @Id";

                var result = await SqlMapper.QueryFirstOrDefaultAsync<Title>(dbConnection, query, dynamicParameters,
                    commandType: CommandType.Text);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateTitle(Title title)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", title.Name);
                dynamicParameters.Add("@SortOrder", title.SortOrder);
                dynamicParameters.Add("@Id", title.Id);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_UpdateTitle", dynamicParameters,
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
