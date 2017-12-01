namespace HospitalDatabase.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Medicaments",
                table => new
                {
                    MedicamentId = table.Column<int>(nullable: false)
                        .Annotation(
                            "SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.MedicamentId);
                });
            migrationBuilder.CreateTable(
                "Patients",
                table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation(
                            "SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    HasInsurance = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });
            migrationBuilder.CreateTable(
                "Diagnoses",
                table => new
                {
                    DiagnoseId = table.Column<int>(nullable: false)
                        .Annotation(
                            "SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.DiagnoseId);
                    table.ForeignKey(
                        "FK_Diagnoses_Patients_PatientId",
                        x => x.PatientId,
                        "Patients",
                        "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                "PatientsMedicaments",
                table => new
                {
                    PatientId = table.Column<int>(nullable: false),
                    MedicamentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_PatientsMedicaments",
                        x => new
                        {
                            x.PatientId,
                            x.MedicamentId
                        });
                    table.ForeignKey(
                        "FK_PatientsMedicaments_Medicaments_MedicamentId",
                        x => x.MedicamentId,
                        "Medicaments",
                        "MedicamentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_PatientsMedicaments_Patients_PatientId",
                        x => x.PatientId,
                        "Patients",
                        "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                "Visitations",
                table => new
                {
                    VisitationId = table.Column<int>(nullable: false)
                        .Annotation(
                            "SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Comments = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitations", x => x.VisitationId);
                    table.ForeignKey(
                        "FK_Visitations_Patients_PatientId",
                        x => x.PatientId,
                        "Patients",
                        "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex("IX_Diagnoses_PatientId", "Diagnoses", "PatientId");
            migrationBuilder.CreateIndex("IX_PatientsMedicaments_MedicamentId", "PatientsMedicaments", "MedicamentId");
            migrationBuilder.CreateIndex("IX_Visitations_PatientId", "Visitations", "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Diagnoses");
            migrationBuilder.DropTable("PatientsMedicaments");
            migrationBuilder.DropTable("Visitations");
            migrationBuilder.DropTable("Medicaments");
            migrationBuilder.DropTable("Patients");
        }
    }
}