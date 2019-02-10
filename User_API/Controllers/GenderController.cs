using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.Models.Gender;
using User_API.Models.Gender.DAL;

namespace User_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderDAL _genderDAL;

        public GenderController(IGenderDAL genderDAL)
        {
            _genderDAL = genderDAL;
        }

        [HttpPost]
        public async Task<bool> AddGender(Gender gender)
        {
            var result = await _genderDAL.AddGender(gender);

            return result;
        }

        [HttpPut]
        public async Task<bool> UpdateGender(Gender gender)
        {
            var result = await _genderDAL.UpdateGender(gender);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteGender(int id)
        {
            var result = await _genderDAL.DeleteGender(id);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<Gender> GetGender(int id)
        {
            var result = await _genderDAL.GetGender(id);

            return result;
        }
    }
}
