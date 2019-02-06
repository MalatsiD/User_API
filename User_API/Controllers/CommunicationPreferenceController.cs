using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.Models.CommunicationPreference;
using User_API.Models.CommunicationPreference.DAL;

namespace User_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationPreferenceController : ControllerBase
    {
        private readonly ICommunicationPreferenceDAL _communicationPreferenceDAL;

        public CommunicationPreferenceController(ICommunicationPreferenceDAL communicationPreferenceDAL)
        {
            _communicationPreferenceDAL = communicationPreferenceDAL;
        }

        [HttpPost]
        public async Task<bool> AddCommunicationPreference(CommunicationPreference communicationPreference)
        {
            var result = await _communicationPreferenceDAL.AddCommunicationPreference(communicationPreference);

            return result;
        }

        [HttpPut]
        public async Task<bool> UpdateCommunicationPreference(CommunicationPreference communicationPreference)
        {
            var result = await _communicationPreferenceDAL.UpdateCommunicationPreference(communicationPreference);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCommunicationPreference(int id)
        {
            var result = await _communicationPreferenceDAL.DeleteCommunicationPreference(id);

            return result;
        }

        [HttpGet("GetCommunicationPreferences")]
        public async Task<IEnumerable<CommunicationPreference>> GetCommunicationPreferences()
        {
            var result = await _communicationPreferenceDAL.GetCommunicationPreferences();

            return result;
        }

        [HttpGet("GetCommunicationPreference/{id}")]
        public async Task<CommunicationPreference> GetCommunicationPreference(int id)
        {
            var result = await _communicationPreferenceDAL.GetCommunicationPreference(id);

            return result;
        }
    }
}
