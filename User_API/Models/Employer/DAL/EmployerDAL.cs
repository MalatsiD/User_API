using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using User_API.Data;

namespace User_API.Models.Employer.DAL
{
    public class EmployerDAL : DataConnection, IEmployerDAL
    {
        public async Task<bool> AddEmployer(Employer employer)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", employer.Name);
                dynamicParameters.Add("@Id", DbType.Int32, direction: ParameterDirection.Output);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_AddEmployer", dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                var isInserted = dynamicParameters.Get<int>("@Id") > 0;

                return isInserted;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteEmployer(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string delete = "DELETE FROM Employers WHERE Id = @Id";

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, delete, dynamicParameters,
                    commandType: CommandType.Text);

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<Employer> GetEmployer(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string query = "SELECT * FROM Employers WHERE Id = @Id";

                var result = await SqlMapper.QueryFirstOrDefaultAsync<Employer>(dbConnection, query,
                    dynamicParameters, commandType: CommandType.Text);

                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateEmployer(Employer employer)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Name", employer.Name);
                dynamicParameters.Add("@Id", employer.Id);

                await SqlMapper.QuerySingleOrDefaultAsync(dbConnection, "sp_UpdateEmployer", dynamicParameters,
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
