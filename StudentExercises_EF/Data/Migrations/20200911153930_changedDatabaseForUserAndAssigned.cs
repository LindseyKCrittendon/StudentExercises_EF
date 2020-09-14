using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentExercises_EF.Data.Migrations
{
    public partial class changedDatabaseForUserAndAssigned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Student_StudentId",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_StudentId",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Exercise");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedExercise_ExerciseId",
                table: "AssignedExercise",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedExercise_Exercise_ExerciseId",
                table: "AssignedExercise",
                column: "ExerciseId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedExercise_Exercise_ExerciseId",
                table: "AssignedExercise");

            migrationBuilder.DropIndex(
                name: "IX_AssignedExercise_ExerciseId",
                table: "AssignedExercise");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Exercise",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_StudentId",
                table: "Exercise",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Student_StudentId",
                table: "Exercise",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
