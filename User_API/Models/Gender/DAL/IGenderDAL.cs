using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Models.Gender.DAL
{
    public interface IGenderDAL
    {
        Task<bool> AddGender(Gender gender);
        Task<bool> UpdateGender(Gender gender);
        Task<bool> DeleteGender(int id);
        Task<Gender> GetGender(int id);
    }
}
