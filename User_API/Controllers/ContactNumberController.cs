using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.Models.ContactNumber;
using User_API.Models.ContactNumber.DAL;

namespace User_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactNumberController : ControllerBase
    {
        private readonly IContactNumberDAL _contactNumberDAL;

        public ContactNumberController(IContactNumberDAL contactNumberDAL)
        {
            _contactNumberDAL = contactNumberDAL;
        }

        [HttpPost]
        public async Task<bool> AddContactNumber(ContactNumber contactNumber)
        {
            var result = await _contactNumberDAL.AddContactNumber(contactNumber);

            return result;
        }

        [HttpPut]
        public async Task<bool> UpdateContactNumber(ContactNumber contactNumber)
        {
            var result = await _contactNumberDAL.UpdateContactNumber(contactNumber);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteContactNumber(int id)
        {
            var result = await _contactNumberDAL.DeleteContactNumber(id);

            return result;
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<ContactNumber>> GetContactNumbers(int userId)
        {
            var results = await _contactNumberDAL.GetContactNumbers(userId);

            return results;
        }
    }
}
