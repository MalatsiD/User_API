using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Models.Occupation.DAL
{
    public interface IOccupationDAL
    {
        Task<bool> AddOccupation(Occupation occupation);
        Task<bool> UpdateOccupation(Occupation occupation);
        Task<bool> DeleteOccupation(int id);
        Task<Occupation> GetOccupation(int id);
    }
}
