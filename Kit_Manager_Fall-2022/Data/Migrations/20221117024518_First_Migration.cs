using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kit_Manager_Fall_2022.Data.Migrations
{
    public partial class First_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campus",
                columns: table => new
                {
                    CampusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.CampusId);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InstructorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InstructorId);
                });

            migrationBuilder.CreateTable(
                name: "KitBuilder",
                columns: table => new
                {
                    KitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitBuilder", x => x.KitId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusLabel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusCode);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    FName = table.Column<string>(nullable: false),
                    LName = table.Column<string>(nullable: false),
                    CollegeEmail = table.Column<string>(nullable: false),
                    PersonalEmail = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Campus = table.Column<string>(nullable: false),
                    Active = table.Column<string>(nullable: false),
                    HasItem = table.Column<string>(nullable: false),
                    LastEdit = table.Column<DateTime>(nullable: false),
                    EmergencyContact = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(nullable: true),
                    InstructorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Course_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "InstructorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemType = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    ItemCost = table.Column<int>(nullable: false),
                    KitId = table.Column<int>(nullable: false),
                    StatusCode = table.Column<int>(nullable: false),
                    StudentId = table.Column<string>(nullable: true),
                    LastEdit = table.Column<DateTime>(nullable: false),
                    InstructorName = table.Column<string>(nullable: true),
                    Course = table.Column<string>(nullable: true),
                    Active = table.Column<string>(nullable: true),
                    StatusCodeNavigationStatusCode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Equipment_Status_StatusCodeNavigationStatusCode",
                        column: x => x.StatusCodeNavigationStatusCode,
                        principalTable: "Status",
                        principalColumn: "StatusCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_InstructorId",
                table: "Course",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_StatusCodeNavigationStatusCode",
                table: "Equipment",
                column: "StatusCodeNavigationStatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_StudentId",
                table: "Equipment",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campus");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "KitBuilder");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
