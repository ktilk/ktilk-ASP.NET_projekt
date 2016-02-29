using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Competition
    {
        public int CompetitionID { get; set; }
        public string CompetitionName { get; set; }
        public List<Participation> Participations { get; set; }
    }
}
