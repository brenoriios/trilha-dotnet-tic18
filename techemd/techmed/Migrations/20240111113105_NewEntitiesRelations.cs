using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techmed.Migrations
{
    /// <inheritdoc />
    public partial class NewEntitiesRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentExam",
                columns: table => new
                {
                    appointmentsNumber = table.Column<int>(type: "int", nullable: false),
                    examsCode = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentExam", x => new { x.appointmentsNumber, x.examsCode });
                    table.ForeignKey(
                        name: "FK_AppointmentExam_appointments_appointmentsNumber",
                        column: x => x.appointmentsNumber,
                        principalTable: "appointments",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentExam_exams_examsCode",
                        column: x => x.examsCode,
                        principalTable: "exams",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentExam_examsCode",
                table: "AppointmentExam",
                column: "examsCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentExam");
        }
    }
}
