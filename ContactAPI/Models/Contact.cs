using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public byte[] Image { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public long PhoneWork { get; set; }
        public long PhonePersonal { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
