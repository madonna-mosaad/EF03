using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF03.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Topics",
                schema: "dbo",
                columns: table => new
                {
                    TId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "dbo",
                columns: table => new
                {
                    CId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Top_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CId);
                    table.ForeignKey(
                        name: "FK_Courses_Topics_Top_Id",
                        column: x => x.Top_Id,
                        principalSchema: "dbo",
                        principalTable: "Topics",
                        principalColumn: "TId");
                });

            migrationBuilder.CreateTable(
                name: "Course_Inst",
                schema: "dbo",
                columns: table => new
                {
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    Ins_Id = table.Column<int>(type: "int", nullable: false),
                    Evaluate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Inst", x => new { x.Course_Id, x.Ins_Id });
                    table.ForeignKey(
                        name: "FK_Course_Inst_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalSchema: "dbo",
                        principalTable: "Courses",
                        principalColumn: "CId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "dbo",
                columns: table => new
                {
                    DId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ins_Id = table.Column<int>(type: "int", nullable: true),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DId);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                schema: "dbo",
                columns: table => new
                {
                    InsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Bouns = table.Column<double>(type: "float", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HourRate = table.Column<int>(type: "int", nullable: false),
                    Dept_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InsId);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_Dept_Id",
                        column: x => x.Dept_Id,
                        principalSchema: "dbo",
                        principalTable: "Departments",
                        principalColumn: "DId");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "dbo",
                columns: table => new
                {
                    SId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Cairo"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Dep_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.SId);
                    table.ForeignKey(
                        name: "FK_Students_Departments_Dep_Id",
                        column: x => x.Dep_Id,
                        principalSchema: "dbo",
                        principalTable: "Departments",
                        principalColumn: "DId");
                });

            migrationBuilder.CreateTable(
                name: "Stud_Course",
                schema: "dbo",
                columns: table => new
                {
                    Stud_Id = table.Column<int>(type: "int", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stud_Course", x => new { x.Stud_Id, x.Course_Id });
                    table.ForeignKey(
                        name: "FK_Stud_Course_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalSchema: "dbo",
                        principalTable: "Courses",
                        principalColumn: "CId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stud_Course_Students_Stud_Id",
                        column: x => x.Stud_Id,
                        principalSchema: "dbo",
                        principalTable: "Students",
                        principalColumn: "SId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_Inst_Ins_Id",
                schema: "dbo",
                table: "Course_Inst",
                column: "Ins_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Top_Id",
                schema: "dbo",
                table: "Courses",
                column: "Top_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ins_Id",
                schema: "dbo",
                table: "Departments",
                column: "ins_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Dept_Id",
                schema: "dbo",
                table: "Instructors",
                column: "Dept_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stud_Course_Course_Id",
                schema: "dbo",
                table: "Stud_Course",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Dep_Id",
                schema: "dbo",
                table: "Students",
                column: "Dep_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Inst_Instructors_Ins_Id",
                schema: "dbo",
                table: "Course_Inst",
                column: "Ins_Id",
                principalSchema: "dbo",
                principalTable: "Instructors",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_ins_Id",
                schema: "dbo",
                table: "Departments",
                column: "ins_Id",
                principalSchema: "dbo",
                principalTable: "Instructors",
                principalColumn: "InsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_ins_Id",
                schema: "dbo",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Course_Inst",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Stud_Course",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Courses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Topics",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Instructors",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "dbo");
        }
    }
}
