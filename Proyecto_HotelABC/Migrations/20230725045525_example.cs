using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Proyecto_HotelABC.Migrations
{
    public partial class example : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PkRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PkRole);
                });

            migrationBuilder.CreateTable(
                name: "SuiteNames",
                columns: table => new
                {
                    PkName = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameS = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuiteNames", x => x.PkName);
                });

            migrationBuilder.CreateTable(
                name: "Counts",
                columns: table => new
                {
                    PkCount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    Mail = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FkRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counts", x => x.PkCount);
                    table.ForeignKey(
                        name: "FK_Counts_Roles_FkRole",
                        column: x => x.FkRole,
                        principalTable: "Roles",
                        principalColumn: "PkRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Days = table.Column<int>(type: "int", nullable: false),
                    AmountPerson = table.Column<int>(type: "int", nullable: false),
                    Suite = table.Column<int>(type: "int", nullable: false),
                    CountId = table.Column<int>(type: "int", nullable: true),
                    SuiteId = table.Column<int>(type: "int", nullable: true),
                    SuiteNamePkName = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.IdReservation);
                    table.ForeignKey(
                        name: "FK_Bookings_Counts_CountId",
                        column: x => x.CountId,
                        principalTable: "Counts",
                        principalColumn: "PkCount",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_SuiteNames_SuiteNamePkName",
                        column: x => x.SuiteNamePkName,
                        principalTable: "SuiteNames",
                        principalColumn: "PkName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CountId",
                table: "Bookings",
                column: "CountId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SuiteNamePkName",
                table: "Bookings",
                column: "SuiteNamePkName");

            migrationBuilder.CreateIndex(
                name: "IX_Counts_FkRole",
                table: "Counts",
                column: "FkRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Counts");

            migrationBuilder.DropTable(
                name: "SuiteNames");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
