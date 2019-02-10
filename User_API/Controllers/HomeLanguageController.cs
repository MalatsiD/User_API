using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.Models.HomeLanguage;
using User_API.Models.HomeLanguage.DAL;

namespace User_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeLanguageController : ControllerBase
    {
        private readonly IHomeLanguageDAL _homeLanguageDAL;

        public HomeLanguageController(IHomeLanguageDAL homeLanguageDAL)
        {
            _homeLanguageDAL = homeLanguageDAL;
        }

        [HttpPost]
        public async Task<bool> AddHomeLanguage(HomeLanguage homeLanguage)
        {
            var result = await _homeLanguageDAL.AddHomeLanguage(homeLanguage);

            return result;
        }

        [HttpPut]
        public async Task<bool> UpdateHomeLanguage(HomeLanguage homeLanguage)
        {
            var result = await _homeLanguageDAL.UpdateHomeLanguage(homeLanguage);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteHomeLanguage(int id)
        {
            var result = await _homeLanguageDAL.DeleteHomeLanguage(id);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<HomeLanguage> GetHomeLanguage(int id)
        {
            var result = await _homeLanguageDAL.GetHomeLanguage(id);

            return result;
        }
    }
}
