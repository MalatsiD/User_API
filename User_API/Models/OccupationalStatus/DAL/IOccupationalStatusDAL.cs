using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Models.OccupationalStatus.DAL
{
    public interface IOccupationalStatusDAL
    {
        Task<bool> AddOccupationalStatus(OccupationalStatus occupationalStatus);
        Task<bool> UpdateOccupationalStatus(OccupationalStatus occupationalStatus);
        Task<bool> DeleteOccupationalStatus(int id);
        Task<OccupationalStatus> GetOccupationalStatus(int id);
        Task<IEnumerable<OccupationalStatus>> GetOccupationalStatuses();
    }
}
