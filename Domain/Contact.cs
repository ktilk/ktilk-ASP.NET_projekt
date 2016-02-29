using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Value { get; set; }
        public int ContactTypeID { get; set; }
        public ContactType ContactType { get; set; }
        public int PersonID { get; set; }
        public Person Person { get; set; }
    }
}
