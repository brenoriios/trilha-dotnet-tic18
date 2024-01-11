using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techmed.Migrations
{
    /// <inheritdoc />
    public partial class SmallFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentExam_appointments_appointmentsNumber",
                table: "AppointmentExam");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentExam_exams_examsCode",
                table: "AppointmentExam");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_doctorId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_patientId",
                table: "appointments");

            migrationBuilder.RenameColumn(
                name: "patientId",
                table: "appointments",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "doctorId",
                table: "appointments",
                newName: "DoctorId");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "appointments",
                newName: "Date");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_patientId",
                table: "appointments",
                newName: "IX_appointments_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_doctorId",
                table: "appointments",
                newName: "IX_appointments_DoctorId");

            migrationBuilder.RenameColumn(
                name: "examsCode",
                table: "AppointmentExam",
                newName: "ExamsCode");

            migrationBuilder.RenameColumn(
                name: "appointmentsNumber",
                table: "AppointmentExam",
                newName: "AppointmentsNumber");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentExam_examsCode",
                table: "AppointmentExam",
                newName: "IX_AppointmentExam_ExamsCode");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentExam_appointments_AppointmentsNumber",
                table: "AppointmentExam",
                column: "AppointmentsNumber",
                principalTable: "appointments",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentExam_exams_ExamsCode",
                table: "AppointmentExam",
                column: "ExamsCode",
                principalTable: "exams",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_DoctorId",
                table: "appointments",
                column: "DoctorId",
                principalTable: "doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentExam_appointments_AppointmentsNumber",
                table: "AppointmentExam");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentExam_exams_ExamsCode",
                table: "AppointmentExam");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_DoctorId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "appointments",
                newName: "patientId");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "appointments",
                newName: "doctorId");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "appointments",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_PatientId",
                table: "appointments",
                newName: "IX_appointments_patientId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_DoctorId",
                table: "appointments",
                newName: "IX_appointments_doctorId");

            migrationBuilder.RenameColumn(
                name: "ExamsCode",
                table: "AppointmentExam",
                newName: "examsCode");

            migrationBuilder.RenameColumn(
                name: "AppointmentsNumber",
                table: "AppointmentExam",
                newName: "appointmentsNumber");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentExam_ExamsCode",
                table: "AppointmentExam",
                newName: "IX_AppointmentExam_examsCode");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentExam_appointments_appointmentsNumber",
                table: "AppointmentExam",
                column: "appointmentsNumber",
                principalTable: "appointments",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentExam_exams_examsCode",
                table: "AppointmentExam",
                column: "examsCode",
                principalTable: "exams",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_doctorId",
                table: "appointments",
                column: "doctorId",
                principalTable: "doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_patientId",
                table: "appointments",
                column: "patientId",
                principalTable: "patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
