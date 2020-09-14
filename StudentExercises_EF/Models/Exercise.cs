using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExercises_EF.Models
{
    public class Exercise
    {

        public int Id
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Language
        {
            get; set;
        }

        public string UserId
        {
            get; set;
        }

        public ApplicationUser User
        {
            get; set;
        }

        public List<AssignedExercise> AssignedExercises
        {
            get; set;
        } = new List<AssignedExercise>();
    }
}
