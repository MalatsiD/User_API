using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.Models.Address;
using User_API.Models.Address.DAL;

namespace User_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressDAL _addressDAL;

        public AddressController(IAddressDAL addressDAL)
        {
            _addressDAL = addressDAL;
        }

        [HttpPost]
        public async Task<bool> GetAddress(Address address)
        {
            var result = await _addressDAL.AddAddress(address);

            return result;
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<Address>> GetAddresses(int userId)
        {
            var addresses = await _addressDAL.GetAddresses(userId);

            return addresses;
        }
    }
}
