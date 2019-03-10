using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Models.ContactNumber
{
    public class ContactNumber
    {
        public int Id { get; set; }
        public int ContactTypeId { get; set; }
        public string Contact { get; set; }
        public int PersonId { get; set; }
    }
}
