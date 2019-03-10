using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Models.Person.DAL
{
    public interface IPersonDAL
    {
        Task<bool> AddPerson(Person person);
        Task<bool> UpdatePerson(Person person);
        Task<bool> DeletePerson(int id);
        Task<Person> GetPerson(int id);
    }
}
