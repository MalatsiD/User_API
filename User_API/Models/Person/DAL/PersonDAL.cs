using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using User_API.Data;
using User_API.Models.Address.DAL;
using User_API.Models.CommunicationPreference.DAL;
using User_API.Models.ContactNumber.DAL;
using User_API.Models.Gender.DAL;
using User_API.Models.HomeLanguage.DAL;
using User_API.Models.Title.DAL;

namespace User_API.Models.Person.DAL
{
    public class PersonDAL : DataConnection, IPersonDAL
    {
        private readonly ITitleDAL _titleDAL;
        private readonly IGenderDAL _genderDAL;
        private readonly IHomeLanguageDAL _homeLanguageDAL;
        private readonly ICommunicationPreferenceDAL _communicationPreferenceDAL;
        private readonly IContactNumberDAL _contactNumberDAL;
        private readonly IAddressDAL _addressDAL;

        public PersonDAL(ITitleDAL titleDAL, IGenderDAL genderDAL, IHomeLanguageDAL homeLanguageDAL,
            ICommunicationPreferenceDAL communicationPreferenceDAL, IContactNumberDAL contactNumberDAL,
            IAddressDAL addressDAL)
        {
            _titleDAL = titleDAL;
            _genderDAL = genderDAL;
            _homeLanguageDAL = homeLanguageDAL;
            _communicationPreferenceDAL = communicationPreferenceDAL;
            _contactNumberDAL = contactNumberDAL;
            _addressDAL = addressDAL;
        }

        public async Task<bool> AddPerson(Person person)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@DateCreated", person.DateCreated);
                dynamicParameters.Add("@DateModified", person.DateModified);
                dynamicParameters.Add("@FirstName", person.FirstName);
                dynamicParameters.Add("@MiddleName", person.MiddleName);
                dynamicParameters.Add("@PreferredName", person.PreferredName);
                dynamicParameters.Add("@LastName", person.LastName);
                dynamicParameters.Add("@IdNumber", person.IdNumber);
                dynamicParameters.Add("@EmailAddress", person.EmailAddress);
                dynamicParameters.Add("@TitleId", person.TitleId);
                dynamicParameters.Add("@GenderId", person.GenderId);
                dynamicParameters.Add("@HomeLanguageId", person.HomeLanguageId);
                dynamicParameters.Add("@CommunicationPrefId", person.CommunicationPrefId);
                dynamicParameters.Add("@Id", DbType.Int32, direction: ParameterDirection.Output);

                await SqlMapper.ExecuteAsync(dbConnection, "sp_AddPerson", dynamicParameters,
                    commandType: CommandType.StoredProcedure);

                var isInserted = dynamicParameters.Get<int>("@Id") > 0;

                return isInserted;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeletePerson(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string delete = "DELETE FROM People WHERE Id = @Id";

                await SqlMapper.ExecuteAsync(dbConnection, delete, dynamicParameters,
                    commandType: CommandType.Text);

                return true;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<Person> GetPerson(int id)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", id);

                string query = "SELECT * FROM People WHERE Id = @Id";

                var person = await SqlMapper.QueryFirstOrDefaultAsync<Person>(dbConnection, query, dynamicParameters,
                    commandType: CommandType.Text);

                if(person != null)
                {
                    person.Title = await _titleDAL.GetTitle(person.TitleId);
                    person.Gender = await _genderDAL.GetGender(person.GenderId);
                    person.HomeLanguage = await _homeLanguageDAL.GetHomeLanguage(person.HomeLanguageId);
                    person.Communication = await _communicationPreferenceDAL.GetCommunicationPreference(
                        person.CommunicationPrefId);
                    person.ContactNumbers = await _contactNumberDAL.GetContactNumbers(person.Id);
                    person.Addresses = await _addressDAL.GetAddresses(person.Id);
                }

                return person;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdatePerson(Person person)
        {
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@DateModified", person.DateModified);
                dynamicParameters.Add("@FirstName", person.FirstName);
                dynamicParameters.Add("@MiddleName", person.MiddleName);
                dynamicParameters.Add("@PreferredName", person.PreferredName);
                dynamicParameters.Add("@LastName", person.LastName);
                dynamicParameters.Add("@IdNumber", person.IdNumber);
                dynamicParameters.Add("@EmailAddress", person.EmailAddress);
                dynamicParameters.Add("@TitleId", person.TitleId);
                dynamicParameters.Add("@GenderId", person.GenderId);
                dynamicParameters.Add("@HomeLanguageId", person.HomeLanguageId);
                dynamicParameters.Add("@CommunicationPrefId", person.CommunicationPrefId);
                dynamicParameters.Add("@Id", person.Id);

                await SqlMapper.ExecuteAsync(dbConnection, "sp_UpdatePerson", dynamicParameters,
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
