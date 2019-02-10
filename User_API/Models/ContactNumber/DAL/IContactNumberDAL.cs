using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Models.ContactNumber.DAL
{
    public interface IContactNumberDAL
    {
        Task<bool> AddContactNumber(ContactNumber contactNumber);
        Task<bool> UpdateContactNumber(ContactNumber contactNumber);
        Task<bool> DeleteContactNumber(int id);
        Task<IEnumerable<ContactNumber>> GetContactNumbers(int userId);
    }
}
