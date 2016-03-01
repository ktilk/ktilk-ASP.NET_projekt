﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Plan
    {
        public int PlanID { get; set; }
        public string PlanName { get; set; }
        public int? Rating { get; set; }
        public string Description { get; set; }
        public int PlanTypeID { get; set; }
        public PlanType PlanType { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateClosed { get; set; }
        public string Duration { get; set; }
        public int PersonID { get; set; }
        public List<Workout> Workouts { get; set; }
    }
}
