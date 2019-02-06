using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Models.AddressType.DAL
{
    public interface IAddressTypeDAL
    {
        Task<bool> AddAddressType(AddressType addressType);
        Task<bool> UpdateAddressType(AddressType addressType);
        Task<bool> DeleteAddressType(int id);
        Task<AddressType> GetAddressType(int id);
        Task<IEnumerable<AddressType>> GetAddressTypes();
    }
}
