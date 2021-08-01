using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NengaJouSimple.Data.Migrations
{
    public partial class AddressCardLayoutOwnsTextLayout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressCardLayouts_TextLayouts_AddresseeId",
                table: "AddressCardLayouts");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressCardLayouts_TextLayouts_AddressId",
                table: "AddressCardLayouts");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressCardLayouts_TextLayouts_PostalCodeId",
                table: "AddressCardLayouts");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressCardLayouts_TextLayouts_SenderAddressId",
                table: "AddressCardLayouts");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressCardLayouts_TextLayouts_SenderId",
                table: "AddressCardLayouts");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressCardLayouts_TextLayouts_SenderPostalCodeId",
                table: "AddressCardLayouts");

            migrationBuilder.DropTable(
                name: "Fonts");

            migrationBuilder.DropTable(
                name: "TextLayouts");

            migrationBuilder.DropIndex(
                name: "IX_AddressCardLayouts_AddresseeId",
                table: "AddressCardLayouts");

            migrationBuilder.DropIndex(
                name: "IX_AddressCardLayouts_AddressId",
                table: "AddressCardLayouts");

            migrationBuilder.DropIndex(
                name: "IX_AddressCardLayouts_PostalCodeId",
                table: "AddressCardLayouts");

            migrationBuilder.DropIndex(
                name: "IX_AddressCardLayouts_SenderAddressId",
                table: "AddressCardLayouts");

            migrationBuilder.DropIndex(
                name: "IX_AddressCardLayouts_SenderId",
                table: "AddressCardLayouts");

            migrationBuilder.DropIndex(
                name: "IX_AddressCardLayouts_SenderPostalCodeId",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "SenderAddressCards");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "SenderAddressCards");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "AddressCards");

            migrationBuilder.RenameColumn(
                name: "Address3",
                table: "SenderAddressCards",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Address3",
                table: "AddressCards",
                newName: "PrintedDateTime");

            migrationBuilder.RenameColumn(
                name: "Address2",
                table: "AddressCards",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "FontFamilyName",
                table: "AddressCardLayouts",
                newName: "Sender_Font_FontFamilyName");

            migrationBuilder.RenameColumn(
                name: "SenderPostalCodeId",
                table: "AddressCardLayouts",
                newName: "Sender_TextLayoutKind");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "AddressCardLayouts",
                newName: "Sender_Font_VerticalAlignment");

            migrationBuilder.RenameColumn(
                name: "SenderAddressId",
                table: "AddressCardLayouts",
                newName: "Sender_Font_FontWeight");

            migrationBuilder.RenameColumn(
                name: "PostalCodeId",
                table: "AddressCardLayouts",
                newName: "Sender_Font_FontStyle");

            migrationBuilder.RenameColumn(
                name: "AddresseeId",
                table: "AddressCardLayouts",
                newName: "SenderPostalCode_TextLayoutKind");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "AddressCardLayouts",
                newName: "SenderPostalCode_Font_VerticalAlignment");

            migrationBuilder.AddColumn<bool>(
                name: "IsAlreadyPrinted",
                table: "AddressCards",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Font_FontFamilyName",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Address_Font_FontSize",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Address_Font_FontStyle",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Address_Font_FontWeight",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Address_Font_VerticalAlignment",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Position",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Address_TextLayoutKind",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Addressee_Font_FontFamilyName",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Addressee_Font_FontSize",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Addressee_Font_FontStyle",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Addressee_Font_FontWeight",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Addressee_Font_VerticalAlignment",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Addressee_Position",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Addressee_TextLayoutKind",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode_Font_FontFamilyName",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PostalCode_Font_FontSize",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode_Font_FontStyle",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode_Font_FontWeight",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode_Font_VerticalAlignment",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode_Position",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PostalCode_SpaceBetweenMailWardAndTownWard",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PostalCode_SpaceBetweenMailWardEachWard",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PostalCode_SpaceBetweenTownWardEachWard",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode_TextLayoutKind",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PrintMarginLeft",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PrintMarginTop",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SenderAddress_Font_FontFamilyName",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SenderAddress_Font_FontSize",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderAddress_Font_FontStyle",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderAddress_Font_FontWeight",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderAddress_Font_VerticalAlignment",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderAddress_Position",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderAddress_TextLayoutKind",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderPostalCode_Font_FontFamilyName",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SenderPostalCode_Font_FontSize",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderPostalCode_Font_FontStyle",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderPostalCode_Font_FontWeight",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderPostalCode_Position",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SenderPostalCode_SpaceBetweenMailWardAndTownWard",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SenderPostalCode_SpaceBetweenMailWardEachWard",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SenderPostalCode_SpaceBetweenTownWardEachWard",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Sender_Font_FontSize",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sender_Position",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAlreadyPrinted",
                table: "AddressCards");

            migrationBuilder.DropColumn(
                name: "Address_Font_FontFamilyName",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Address_Font_FontSize",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Address_Font_FontStyle",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Address_Font_FontWeight",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Address_Font_VerticalAlignment",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Address_Position",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Address_TextLayoutKind",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Addressee_Font_FontFamilyName",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Addressee_Font_FontSize",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Addressee_Font_FontStyle",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Addressee_Font_FontWeight",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Addressee_Font_VerticalAlignment",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Addressee_Position",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Addressee_TextLayoutKind",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PostalCode_Font_FontFamilyName",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PostalCode_Font_FontSize",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PostalCode_Font_FontStyle",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PostalCode_Font_FontWeight",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PostalCode_Font_VerticalAlignment",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PostalCode_Position",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PostalCode_SpaceBetweenMailWardAndTownWard",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PostalCode_SpaceBetweenMailWardEachWard",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PostalCode_SpaceBetweenTownWardEachWard",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PostalCode_TextLayoutKind",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PrintMarginLeft",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PrintMarginTop",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderAddress_Font_FontFamilyName",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderAddress_Font_FontSize",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderAddress_Font_FontStyle",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderAddress_Font_FontWeight",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderAddress_Font_VerticalAlignment",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderAddress_Position",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderAddress_TextLayoutKind",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderPostalCode_Font_FontFamilyName",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderPostalCode_Font_FontSize",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderPostalCode_Font_FontStyle",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderPostalCode_Font_FontWeight",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderPostalCode_Position",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderPostalCode_SpaceBetweenMailWardAndTownWard",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderPostalCode_SpaceBetweenMailWardEachWard",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderPostalCode_SpaceBetweenTownWardEachWard",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Sender_Font_FontSize",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Sender_Position",
                table: "AddressCardLayouts");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "SenderAddressCards",
                newName: "Address3");

            migrationBuilder.RenameColumn(
                name: "PrintedDateTime",
                table: "AddressCards",
                newName: "Address3");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AddressCards",
                newName: "Address2");

            migrationBuilder.RenameColumn(
                name: "Sender_Font_FontFamilyName",
                table: "AddressCardLayouts",
                newName: "FontFamilyName");

            migrationBuilder.RenameColumn(
                name: "Sender_TextLayoutKind",
                table: "AddressCardLayouts",
                newName: "SenderPostalCodeId");

            migrationBuilder.RenameColumn(
                name: "Sender_Font_VerticalAlignment",
                table: "AddressCardLayouts",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "Sender_Font_FontWeight",
                table: "AddressCardLayouts",
                newName: "SenderAddressId");

            migrationBuilder.RenameColumn(
                name: "Sender_Font_FontStyle",
                table: "AddressCardLayouts",
                newName: "PostalCodeId");

            migrationBuilder.RenameColumn(
                name: "SenderPostalCode_TextLayoutKind",
                table: "AddressCardLayouts",
                newName: "AddresseeId");

            migrationBuilder.RenameColumn(
                name: "SenderPostalCode_Font_VerticalAlignment",
                table: "AddressCardLayouts",
                newName: "AddressId");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "SenderAddressCards",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "SenderAddressCards",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "AddressCards",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "TextLayouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: true),
                    RegisterdDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TextLayoutKind = table.Column<int>(type: "INTEGER", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SpaceBetweenEachWard = table.Column<double>(type: "REAL", nullable: true),
                    SpaceBetweenMainWardAndTownWard = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextLayouts", x => x.Id);
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

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCardLayouts_TextLayouts_AddresseeId",
                table: "AddressCardLayouts",
                column: "AddresseeId",
                principalTable: "TextLayouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCardLayouts_TextLayouts_AddressId",
                table: "AddressCardLayouts",
                column: "AddressId",
                principalTable: "TextLayouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCardLayouts_TextLayouts_PostalCodeId",
                table: "AddressCardLayouts",
                column: "PostalCodeId",
                principalTable: "TextLayouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCardLayouts_TextLayouts_SenderAddressId",
                table: "AddressCardLayouts",
                column: "SenderAddressId",
                principalTable: "TextLayouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCardLayouts_TextLayouts_SenderId",
                table: "AddressCardLayouts",
                column: "SenderId",
                principalTable: "TextLayouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCardLayouts_TextLayouts_SenderPostalCodeId",
                table: "AddressCardLayouts",
                column: "SenderPostalCodeId",
                principalTable: "TextLayouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
