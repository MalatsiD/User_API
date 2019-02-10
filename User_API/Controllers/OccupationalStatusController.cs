using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.Models.OccupationalStatus;
using User_API.Models.OccupationalStatus.DAL;

namespace User_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationalStatusController : ControllerBase
    {
        private readonly IOccupationalStatusDAL _occupationalStatusDAL;

        public OccupationalStatusController(IOccupationalStatusDAL occupationalStatusDAL)
        {
            _occupationalStatusDAL = occupationalStatusDAL;
        }

        [HttpPost]
        public async Task<bool> AddOccupationalStatus(OccupationalStatus occupationalStatus)
        {
            var result = await _occupationalStatusDAL.AddOccupationalStatus(occupationalStatus);

            return result;
        }

        [HttpPut]
        public async Task<bool> UpdateOccupationalStatus(OccupationalStatus occupationalStatus)
        {
            var result = await _occupationalStatusDAL.UpdateOccupationalStatus(occupationalStatus);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteOccupationalStatus(int id)
        {
            var result = await _occupationalStatusDAL.DeleteOccupationalStatus(id);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<OccupationalStatus> GetOccupationalStatus(int id)
        {
            var result = await _occupationalStatusDAL.GetOccupationalStatus(id);

            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<OccupationalStatus>> GetOccupationalStatuses()
        {
            var result = await _occupationalStatusDAL.GetOccupationalStatuses();

            return result;
        }
    }
}
