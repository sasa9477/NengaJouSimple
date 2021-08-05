using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NengaJouSimple.Data.Migrations
{
    public partial class AddSenderAddressCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SenderAddressCardId",
                table: "AddressCards",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SenderAddressCards",
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
                    table.PrimaryKey("PK_SenderAddressCards", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressCards_SenderAddressCardId",
                table: "AddressCards",
                column: "SenderAddressCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCards_SenderAddressCards_SenderAddressCardId",
                table: "AddressCards",
                column: "SenderAddressCardId",
                principalTable: "SenderAddressCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressCards_SenderAddressCards_SenderAddressCardId",
                table: "AddressCards");

            migrationBuilder.DropTable(
                name: "SenderAddressCards");

            migrationBuilder.DropIndex(
                name: "IX_AddressCards_SenderAddressCardId",
                table: "AddressCards");

            migrationBuilder.DropColumn(
                name: "SenderAddressCardId",
                table: "AddressCards");
        }
    }
}
