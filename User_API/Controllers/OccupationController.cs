using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.Models.Occupation;
using User_API.Models.Occupation.DAL;

namespace User_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        private readonly IOccupationDAL _occupationDAL;

        public OccupationController(IOccupationDAL occupationDAL)
        {
            _occupationDAL = occupationDAL;
        }

        [HttpPost]
        public async Task<bool> AddOccupation(Occupation occupation)
        {
            var result = await _occupationDAL.AddOccupation(occupation);

            return result;
        }

        [HttpPut]
        public async Task<bool> UpdateOccupation(Occupation occupation)
        {
            var result = await _occupationDAL.UpdateOccupation(occupation);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteOccupation(int id)
        {
            var result = await _occupationDAL.DeleteOccupation(id);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<Occupation> GetOccupation(int id)
        {
            var result = await _occupationDAL.GetOccupation(id);

            return result;
        }
    }
}
