using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Models.Address.DAL
{
    public interface IAddressDAL
    {
        Task<IEnumerable<Address>> GetAddresses(int userId);
        Task<bool> AddAddress(Address address);
        Task<bool> UpdateAddress(Address address);
        Task<bool> DeleteAddres(int id);
    }
}
