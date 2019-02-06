using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Models.CommunicationPreference.DAL
{
    public interface ICommunicationPreferenceDAL
    {
        Task<bool> AddCommunicationPreference(CommunicationPreference communicationPreference);
        Task<bool> UpdateCommunicationPreference(CommunicationPreference communicationPreference);
        Task<bool> DeleteCommunicationPreference(int id);
        Task<CommunicationPreference> GetCommunicationPreference(int id);
        Task<IEnumerable<CommunicationPreference>> GetCommunicationPreferences();
    }
}
