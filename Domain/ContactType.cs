using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ContactType
    {
        public int ContactTypeID { get; set; }
        public string ContactTypeName { get; set; }
        public List<Contact> Contacts { get; set; }

    }
}
