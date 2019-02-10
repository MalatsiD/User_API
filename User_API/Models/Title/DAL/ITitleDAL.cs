using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Models.Title.DAL
{
    public interface ITitleDAL
    {
        Task<bool> AddTitle(Title title);
        Task<bool> UpdateTitle(Title title);
        Task<bool> DeleteTitle(int id);
        Task<Title> GetTitle(int id);
    }
}
