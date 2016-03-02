using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ExerciseInWorkout
    {
        public int ExerciseInWorkoutID { get; set; }
        public int ExerciseID { get; set; }
        public virtual Exercise Exercise { get; set; }
        public int WorkoutID { get; set; }
        public virtual Workout Workout { get; set; }
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }
        public int? Time { get; set; }
        public int? Weight { get; set; }
    }
}
