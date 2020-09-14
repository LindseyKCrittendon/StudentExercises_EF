using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentExercises_EF.Models;

namespace StudentExercises_EF.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cohort> Cohort
        {
            get; set;
        }

        public DbSet<Student> Student
        {
            get; set;
        }

        public DbSet<Instructor> Instructor
        {
            get; set;
        }

        public DbSet<Exercise> Exercise
        {
            get; set;
        }

        public DbSet<AssignedExercise> AssignedExercise
        {
            get; set;
        }

        public DbSet<ApplicationUser> ApplicationUsers
        {
            get; set;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Create a new user for Identity Framework
            ApplicationUser user = new ApplicationUser
            {
                Id = "1",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Duchess72&");
            modelBuilder.Entity<ApplicationUser>().HasData(user);


            // Create 3 cohorts
            modelBuilder.Entity<Cohort>().HasData(
                new Cohort()
                {
                    Id = 1,
                    Name = "Cohort I",
                    UserId = "1"
                },
                new Cohort()
                {
                    Id = 2,
                    Name = "Cohort II",
                    UserId = "1"
                },
                new Cohort()
                {
                    Id = 3,
                    Name = "Cohort III",
                    UserId = "1"
                 }
            );
            //creating instructors
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor()
                {
                    Id = 1,
                    FirstName = "Jordan",
                    LastName = "Castelloe",
                    SlackHandle = "JordanC",
                    Specialty = "Suffering",
                    CohortId = 1,
                    UserId = "1"
                },
                new Instructor()
                {
                    Id = 2,
                    FirstName = "Jacob",
                    LastName = "Perry",
                    SlackHandle = "JPpuffinStuff",
                    Specialty = "Life Coach",
                    CohortId = 1,
                    UserId = "1"
                },
                new Instructor()
                {
                    Id = 3, 
                    FirstName = "Tommy",
                    LastName = "Spurlock",
                    SlackHandle = "TacoPro",
                    Specialty = "Tacos",
                    CohortId = 2,
                    UserId = "1"
                },
                new Instructor()
                {
                    Id = 4,
                    FirstName = "Orby",
                    LastName = "Hotchkiss",
                    SlackHandle = "Orbster",
                    Specialty = "Cuddles",
                    CohortId = 2,
                    UserId = "1"
                },
                new Instructor()
                {
                    Id = 5,
                    FirstName = "Karman",
                    LastName = "Crittendon",
                    SlackHandle = "KarmyKar",
                    Specialty = "Establishing Dominance",
                    CohortId = 3,
                    UserId = "1"
                },
                new Instructor()
                {
                    Id = 6,
                    FirstName = "Also",
                    LastName = "Crittendon",
                    SlackHandle = "BoofBooof",
                    CohortId = 3,
                    UserId = "1"
                }
                
                );

            //create some students
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "Mike",
                    LastName = "Hotchkiss",
                    SlackHandle = "Mikey",
                    CohortId = 1,
                    UserId = "1"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Joey",
                    LastName = "Wellman",
                    SlackHandle = "Beesus",
                    CohortId = 2,
                    UserId = "1"
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Lindsey",
                    LastName = "Crittendon",
                    SlackHandle = "Lindsey",
                    CohortId = 3,
                    UserId = "1"
                },
                new Student()
                {
                    Id = 4,
                    FirstName = "Dylan",
                    LastName = "Bishop",
                    SlackHandle = "DylanB",
                    CohortId = 3,
                    UserId = "1"
                }
                );

            modelBuilder.Entity<Exercise>().HasData(
                new Exercise()
                {
                    Id = 1,
                    Name = "Chicken Monkey",
                    Language = "JavaScript",
                    UserId = "1"
                },
                new Exercise()
                {
                    Id = 2,
                    Name = "Nutshell",
                    Language = "JavaScript",
                    UserId = "1"
                },
                new Exercise()
                {
                    Id = 3,
                    Name = "Nutshell",
                    Language = "React",
                    UserId = "1"
                },
                new Exercise()
                {
                    Id = 4,
                    Name = "Trestlebridge",
                    Language = "C#",
                    UserId = "1"
                },
                new Exercise()
                {
                    Id = 5,
                    Name = "Bangazon API",
                    Language = "C#",
                    UserId = "1"
                },
                new Exercise()
                {
                    Id = 6, 
                    Name = "Student Exercises",
                    Language = "C#",
                    UserId = "1"
                }
                );
            modelBuilder.Entity<AssignedExercise>().HasData(
                new AssignedExercise()
                {
                    Id = 1,
                    ExerciseId = 1,
                    StudentId = 1
                },
                new AssignedExercise()
                {
                    Id = 2, 
                    ExerciseId = 1,
                    StudentId = 2
                },
                new AssignedExercise()
                {
                    Id = 3,
                    ExerciseId = 2,
                    StudentId = 3
                },
                new AssignedExercise()
                {
                    Id = 4,
                    ExerciseId = 2,
                    StudentId = 4
                },
                new AssignedExercise()
                {
                    Id = 5,
                    ExerciseId = 3,
                    StudentId = 1,
                },
                new AssignedExercise()
                {
                    Id = 6,
                    ExerciseId = 3,
                    StudentId = 2,
                },
                new AssignedExercise()
                {
                    Id = 7,
                    ExerciseId = 4,
                    StudentId = 3,
                },
                new AssignedExercise()
                {
                    Id = 8,
                    ExerciseId = 5,
                    StudentId = 4
                },
                new AssignedExercise()
                {
                    Id = 9,
                    ExerciseId = 6,
                    StudentId = 1
                }
                );
        }

        }
    }
