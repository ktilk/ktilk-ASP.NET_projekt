using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Person
    {
        //TODO stringide pikkused piirata ja värki
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public virtual List<Contact> Contacts { get; set; }
        public virtual List<Plan> Plans { get; set; }
        public virtual List<Participation> Participations { get; set; }
    }
}
