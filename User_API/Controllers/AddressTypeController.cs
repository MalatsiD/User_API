using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.Models.AddressType;
using User_API.Models.AddressType.DAL;

namespace User_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressTypeController : ControllerBase
    {
        private readonly IAddressTypeDAL _addressTypeDAL;

        public AddressTypeController(IAddressTypeDAL addressTypeDAL)
        {
            _addressTypeDAL = addressTypeDAL;
        }

        [HttpPost]
        public async Task<bool> AddAddressType(AddressType addressType)
        {
            var result = await _addressTypeDAL.AddAddressType(addressType);

            return result;
        }

        [HttpPut]
        public async Task<bool> UpdateAddressType(AddressType addressType)
        {
            var result = await _addressTypeDAL.UpdateAddressType(addressType);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAddressType(int id)
        {
            var result = await _addressTypeDAL.DeleteAddressType(id);

            return result;
        }

        [HttpGet("GetAddressTypes")]
        public async Task<IEnumerable<AddressType>> GetAddressTypes()
        {
            var result = await _addressTypeDAL.GetAddressTypes();

            return result;
        }

        [HttpGet("GetAddressType/{id}")]
        public async Task<AddressType> GetAddressType(int id)
        {
            var result = await _addressTypeDAL.GetAddressType(id);

            return result;
        }
    }
}
