using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.Models.Title;
using User_API.Models.Title.DAL;

namespace User_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly ITitleDAL _titleDAL;

        public TitleController(ITitleDAL titleDAL)
        {
            _titleDAL = titleDAL;
        }

        [HttpPost]
        public async Task<bool> AddTitle(Title title)
        {
            var result = await _titleDAL.AddTitle(title);

            return result;
        }

        [HttpPut]
        public async Task<bool> UpdateTitle(Title title)
        {
            var result = await _titleDAL.UpdateTitle(title);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteTitle(int id)
        {
            var result = await _titleDAL.DeleteTitle(id);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<Title> GetTitle(int id)
        {
            var result = await _titleDAL.GetTitle(id);

            return result;
        }
    }
}
