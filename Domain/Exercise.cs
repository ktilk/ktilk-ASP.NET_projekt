using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Exercise
    {
        public int ExerciseID { get; set; }
        public int ExerciseTypeID { get; set; }
        public ExerciseType ExerciseType { get; set; }
        public string ExerciseName { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public string VideoUrl { get; set; }
        public int Rating { get; set; }
        public DateTime DateCreated { get; set; }
        public List<ExerciseInWorkout> ExercisesInWorkouts { get; set; }
    }
}
