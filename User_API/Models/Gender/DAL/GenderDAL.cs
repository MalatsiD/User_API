using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using User_API.Data;

namespace User_API.Models.Gender.DAL
{
    public class GenderDAL : DataConnection, IGenderDAL
    {
        public async Task<bool> AddGender(Gender gender)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", gender.Name);
                dynamicParameters.Add("@SortOrder", gender.SortOrder);
                dynamicParameters.Add("@Id", DbType.Int32, direction: ParameterDirection.Output);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_AddGender", dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                var isInserted = dynamicParameters.Get<int>("@Id") > 0;

                return isInserted;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteGender(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string delete = "DELETE FROM Genders WHERE Id = @Id";

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, delete, dynamicParameters,
                    commandType: CommandType.Text);

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<Gender> GetGender(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string query = "SELECT * FROM Genders WHERE Id = @Id";

                var results = await SqlMapper.QueryFirstOrDefaultAsync<Gender>(dbConnection, query, dynamicParameters,
                    commandType: CommandType.Text);

                return results;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateGender(Gender gender)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", gender.Name);
                dynamicParameters.Add("@SortOrder", gender.SortOrder);
                dynamicParameters.Add("@Id", gender.Id);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_UpdateGender", dynamicParameters,
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
