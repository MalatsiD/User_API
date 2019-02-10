using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_API.Models.Employer;
using User_API.Models.Employer.DAL;

namespace User_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerDAL _employerDAL;

        public EmployerController(IEmployerDAL employerDAL)
        {
            _employerDAL = employerDAL;
        }

        [HttpPost]
        public async Task<bool> AddEmployer(Employer employer)
        {
            var result = await _employerDAL.AddEmployer(employer);

            return result;
        }

        [HttpPut]
        public async Task<bool> UpdateEmployer(Employer employer)
        {
            var result = await _employerDAL.UpdateEmployer(employer);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteEmployer(int id)
        {
            var result = await _employerDAL.DeleteEmployer(id);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<Employer> GetEmployer(int id)
        {
            var result = await _employerDAL.GetEmployer(id);

            return result;
        }
    }
}
