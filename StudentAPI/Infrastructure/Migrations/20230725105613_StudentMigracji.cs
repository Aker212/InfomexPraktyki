using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StudentMigracji : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    IdAdresu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numer = table.Column<int>(type: "int", nullable: false),
                    Miasto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodPocztowy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kraj = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.IdAdresu);
                });

            migrationBuilder.CreateTable(
                name: "Kursy",
                columns: table => new
                {
                    IdKursu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaKursu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kursy", x => x.IdKursu);
                });

            migrationBuilder.CreateTable(
                name: "Wydzial",
                columns: table => new
                {
                    IdWydzialu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaWydzialu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budynek = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydzial", x => x.IdWydzialu);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RokRozpoczencia = table.Column<int>(type: "int", nullable: false),
                    IdAdresu = table.Column<int>(type: "int", nullable: false),
                    IdWydzialu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Adres_IdAdresu",
                        column: x => x.IdAdresu,
                        principalTable: "Adres",
                        principalColumn: "IdAdresu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Wydzial_IdWydzialu",
                        column: x => x.IdWydzialu,
                        principalTable: "Wydzial",
                        principalColumn: "IdWydzialu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KursyStudentow",
                columns: table => new
                {
                    IdStudenta = table.Column<int>(type: "int", nullable: false),
                    IdKursu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KursyStudentow", x => new { x.IdStudenta, x.IdKursu });
                    table.ForeignKey(
                        name: "FK_KursyStudentow_Kursy_IdKursu",
                        column: x => x.IdKursu,
                        principalTable: "Kursy",
                        principalColumn: "IdKursu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KursyStudentow_Students_IdStudenta",
                        column: x => x.IdStudenta,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KursyStudentow_IdKursu",
                table: "KursyStudentow",
                column: "IdKursu");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdAdresu",
                table: "Students",
                column: "IdAdresu");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdWydzialu",
                table: "Students",
                column: "IdWydzialu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KursyStudentow");

            migrationBuilder.DropTable(
                name: "Kursy");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropTable(
                name: "Wydzial");
        }
    }
}
