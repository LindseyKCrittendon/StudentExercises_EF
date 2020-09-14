using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentExercises_EF.Data.Migrations
{
    public partial class seedDataWithUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "e7e86263-f793-4948-bb0c-ed0beb0f8598", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMIWC4AmD1QwWPNwcBe5FLlT9IJW/ERRGOe93i41/qKGiu6HMUbuHzEMGrGmAAmbnA==", null, false, "8671f587-34ec-4c43-a801-565ac3859221", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Cohort",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Cohort I", "1" },
                    { 2, "Cohort II", "1" },
                    { 3, "Cohort III", "1" }
                });

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "Id", "Language", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "JavaScript", "Chicken Monkey", "1" },
                    { 2, "JavaScript", "Nutshell", "1" },
                    { 3, "React", "Nutshell", "1" },
                    { 4, "C#", "Trestlebridge", "1" },
                    { 5, "C#", "Bangazon API", "1" },
                    { 6, "C#", "Student Exercises", "1" }
                });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "Id", "CohortId", "FirstName", "LastName", "SlackHandle", "Specialty", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Jordan", "Castelloe", "JordanC", "Suffering", "1" },
                    { 2, 1, "Jacob", "Perry", "JPpuffinStuff", "Life Coach", "1" },
                    { 3, 2, "Tommy", "Spurlock", "TacoPro", "Tacos", "1" },
                    { 4, 2, "Orby", "Hotchkiss", "Orbster", "Cuddles", "1" },
                    { 5, 3, "Karman", "Crittendon", "KarmyKar", "Establishing Dominance", "1" },
                    { 6, 3, "Also", "Crittendon", "BoofBooof", null, "1" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "CohortId", "FirstName", "InstructorId", "LastName", "SlackHandle", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Mike", null, "Hotchkiss", "Mikey", "1" },
                    { 2, 2, "Joey", null, "Wellman", "Beesus", "1" },
                    { 3, 3, "Lindsey", null, "Crittendon", "Lindsey", "1" },
                    { 4, 3, "Dylan", null, "Bishop", "DylanB", "1" }
                });

            migrationBuilder.InsertData(
                table: "AssignedExercise",
                columns: new[] { "Id", "ExerciseId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 5, 3, 1 },
                    { 9, 6, 1 },
                    { 2, 1, 2 },
                    { 6, 3, 2 },
                    { 3, 2, 3 },
                    { 7, 4, 3 },
                    { 4, 2, 4 },
                    { 8, 5, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AssignedExercise",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AssignedExercise",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AssignedExercise",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AssignedExercise",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AssignedExercise",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AssignedExercise",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AssignedExercise",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AssignedExercise",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AssignedExercise",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cohort",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cohort",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cohort",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
