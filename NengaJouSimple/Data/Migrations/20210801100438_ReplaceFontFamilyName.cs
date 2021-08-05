using Microsoft.EntityFrameworkCore.Migrations;

namespace NengaJouSimple.Data.Migrations
{
    public partial class ReplaceFontFamilyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_Font_FontFamilyName",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Addressee_Font_FontFamilyName",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PostalCode_Font_FontFamilyName",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderAddress_Font_FontFamilyName",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderPostalCode_Font_FontFamilyName",
                table: "AddressCardLayouts");

            migrationBuilder.RenameColumn(
                name: "Sender_Font_FontFamilyName",
                table: "AddressCardLayouts",
                newName: "FontFamilyName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FontFamilyName",
                table: "AddressCardLayouts",
                newName: "Sender_Font_FontFamilyName");

            migrationBuilder.AddColumn<string>(
                name: "Address_Font_FontFamilyName",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Addressee_Font_FontFamilyName",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode_Font_FontFamilyName",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderAddress_Font_FontFamilyName",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderPostalCode_Font_FontFamilyName",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);
        }
    }
}
