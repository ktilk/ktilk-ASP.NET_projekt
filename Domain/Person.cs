using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Plan> Plans { get; set; }
        public List<Participation> Participations { get; set; }
    }
}
