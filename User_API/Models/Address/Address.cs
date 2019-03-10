using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.Models.Address
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string Town { get; set; }
        public int Code { get; set; }

        public int PersonId { get; set; }

        public int AddressTypeId { get; set; }
        public AddressType.AddressType AddressType { get; set; }
    }
}
