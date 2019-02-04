using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Models.User
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string EmailAddress { get; set; }


        public Title.Title Title { get; set; }
        public int TitleId { get; set; }

        public int GenderId { get; set; }
        public Gender.Gender Gender { get; set; }

        public int HomeLanguageId { get; set; }
        public HomeLanguage.HomeLanguage HomeLanguage { get; set; }

        public int CommunicationPrefId { get; set; }
        public CommunicationPreference.CommunicationPreference Communication { get; set; }

        public int OccupationalStatusId { get; set; }
        public OccupationalStatus.OccupationalStatus OccupationalStatus { get; set; }

        public int OccupationId { get; set; }
        public Occupation.Occupation Occupation { get; set; }

        public int EmployerId { get; set; }
        public Employer.Employer Employer { get; set; }

        //Collections
        public IEnumerable<ContactNumber.ContactNumber> ContactNumbers { get; set; }
        public IEnumerable<Address.Address> Addresses { get; set; }

    }
}
