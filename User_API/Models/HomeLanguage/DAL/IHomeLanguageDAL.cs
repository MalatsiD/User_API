using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Models.HomeLanguage.DAL
{
    public interface IHomeLanguageDAL
    {
        Task<bool> AddHomeLanguage(HomeLanguage homeLanguage);
        Task<bool> UpdateHomeLanguage(HomeLanguage homeLanguage);
        Task<bool> DeleteHomeLanguage(int id);
        Task<HomeLanguage> GetHomeLanguage(int id);
    }
}
