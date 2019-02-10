using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Models.Employer.DAL
{
    public interface IEmployerDAL
    {
        Task<bool> AddEmployer(Employer employer);
        Task<bool> UpdateEmployer(Employer employer);
        Task<bool> DeleteEmployer(int id);
        Task<Employer> GetEmployer(int id);
    }
}
