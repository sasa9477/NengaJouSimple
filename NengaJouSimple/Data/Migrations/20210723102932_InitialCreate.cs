using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NengaJouSimple.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MainName = table.Column<string>(type: "TEXT", nullable: true),
                    MainNameKana = table.Column<string>(type: "TEXT", nullable: true),
                    AddressNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Address1 = table.Column<string>(type: "TEXT", nullable: true),
                    Address2 = table.Column<string>(type: "TEXT", nullable: true),
                    Address3 = table.Column<string>(type: "TEXT", nullable: true),
                    Renmei1 = table.Column<string>(type: "TEXT", nullable: true),
                    Renmei2 = table.Column<string>(type: "TEXT", nullable: true),
                    Renmei3 = table.Column<string>(type: "TEXT", nullable: true),
                    Renmei4 = table.Column<string>(type: "TEXT", nullable: true),
                    Renmei5 = table.Column<string>(type: "TEXT", nullable: true),
                    RegisterdDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressCards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressCards");
        }
    }
}
