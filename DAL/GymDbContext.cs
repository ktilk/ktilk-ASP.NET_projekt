using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Migrations;
using Domain;

namespace DAL
{
    public class GymDbContext : DbContext
    {
        public GymDbContext() : base("DbConnectionString")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<GymDbContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GymDbContext, MigrationConfiguration>());
#if DEBUG
            Database.Log = s => Trace.Write(s);
#endif
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseInWorkout> ExercisesInWorkouts { get; set; }
        public DbSet<ExerciseType> ExerciseTypes { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanType> PlanTypes { get; set; }
        public DbSet<Workout> Workouts { get; set; }
    }
}
