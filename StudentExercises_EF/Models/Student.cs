using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercises_EF.Models
{
    public class Student
    {
        public int Id
        {
            get; set;
        }

        public string FirstName
        {
            get; set;
        }

        public string LastName
        {
            get; set;
        }

        public string SlackHandle
        {
            get; set;
        }

        public int CohortId
        {
            get; set;
        }

        public Cohort Cohort
        {
            get; set;
        }

        public List<AssignedExercise> AssignedExercises
        {
            get; set;
        } = new List<AssignedExercise>();

       
       

        public string UserId
        {
            get; set;
        }

        public ApplicationUser User
        {
            get; set;
        }
    }
}
