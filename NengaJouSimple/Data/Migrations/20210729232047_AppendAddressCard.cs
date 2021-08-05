using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NengaJouSimple.Data.Migrations
{
    public partial class AppendAddressCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressNumber",
                table: "SenderAddressCards",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "AddressNumber",
                table: "AddressCards",
                newName: "PostalCode");

            migrationBuilder.CreateTable(
                name: "TextLayouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TextLayoutKind = table.Column<int>(type: "INTEGER", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    SpaceBetweenMainWardAndTownWard = table.Column<double>(type: "REAL", nullable: true),
                    SpaceBetweenEachWard = table.Column<double>(type: "REAL", nullable: true),
                    RegisterdDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextLayouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddressCardLayouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FontFamilyName = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCodeId = table.Column<int>(type: "INTEGER", nullable: true),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: true),
                    AddresseeId = table.Column<int>(type: "INTEGER", nullable: true),
                    SenderPostalCodeId = table.Column<int>(type: "INTEGER", nullable: true),
                    SenderId = table.Column<int>(type: "INTEGER", nullable: true),
                    SenderAddressId = table.Column<int>(type: "INTEGER", nullable: true),
                    RegisterdDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressCardLayouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressCardLayouts_TextLayouts_AddresseeId",
                        column: x => x.AddresseeId,
                        principalTable: "TextLayouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddressCardLayouts_TextLayouts_AddressId",
                        column: x => x.AddressId,
                        principalTable: "TextLayouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddressCardLayouts_TextLayouts_PostalCodeId",
                        column: x => x.PostalCodeId,
                        principalTable: "TextLayouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddressCardLayouts_TextLayouts_SenderAddressId",
                        column: x => x.SenderAddressId,
                        principalTable: "TextLayouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddressCardLayouts_TextLayouts_SenderId",
                        column: x => x.SenderId,
                        principalTable: "TextLayouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddressCardLayouts_TextLayouts_SenderPostalCodeId",
                        column: x => x.SenderPostalCodeId,
                        principalTable: "TextLayouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fonts",
                columns: table => new
                {
                    TextLayoutId = table.Column<int>(type: "INTEGER", nullable: false),
                    FontSize = table.Column<double>(type: "REAL", nullable: false),
                    FontStyle = table.Column<int>(type: "INTEGER", nullable: false),
                    FontWeight = table.Column<int>(type: "INTEGER", nullable: false),
                    VerticalAlignment = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fonts", x => x.TextLayoutId);
                    table.ForeignKey(
                        name: "FK_Fonts_TextLayouts_TextLayoutId",
                        column: x => x.TextLayoutId,
                        principalTable: "TextLayouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressCardLayouts_AddresseeId",
                table: "AddressCardLayouts",
                column: "AddresseeId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressCardLayouts_AddressId",
                table: "AddressCardLayouts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressCardLayouts_PostalCodeId",
                table: "AddressCardLayouts",
                column: "PostalCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressCardLayouts_SenderAddressId",
                table: "AddressCardLayouts",
                column: "SenderAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressCardLayouts_SenderId",
                table: "AddressCardLayouts",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressCardLayouts_SenderPostalCodeId",
                table: "AddressCardLayouts",
                column: "SenderPostalCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressCardLayouts");

            migrationBuilder.DropTable(
                name: "Fonts");

            migrationBuilder.DropTable(
                name: "TextLayouts");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "SenderAddressCards",
                newName: "AddressNumber");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "AddressCards",
                newName: "AddressNumber");
        }
    }
}
