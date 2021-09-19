using Microsoft.EntityFrameworkCore.Migrations;

namespace NengaJouSimple.Data.Migrations
{
    public partial class AddingPrintTargetProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressCardLayouts",
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
                name: "FontFamilyName",
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
                name: "SenderPostalCode_Font_FontSize",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderPostalCode_Font_FontStyle",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderPostalCode_Font_FontWeight",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderPostalCode_Font_VerticalAlignment",
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
                name: "SenderPostalCode_TextLayoutKind",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Sender_Font_FontStyle",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Sender_Font_FontWeight",
                table: "AddressCardLayouts");

            migrationBuilder.RenameTable(
                name: "AddressCardLayouts",
                newName: "TextLayouts");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "SenderAddressCards",
                newName: "Address2");

            migrationBuilder.RenameColumn(
                name: "IsAlreadyPrinted",
                table: "AddressCards",
                newName: "IsFamilyPrinting");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AddressCards",
                newName: "Address2");

            migrationBuilder.RenameColumn(
                name: "Sender_TextLayoutKind",
                table: "TextLayouts",
                newName: "TextLayoutKind");

            migrationBuilder.RenameColumn(
                name: "Sender_Position",
                table: "TextLayouts",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "Sender_Font_FontSize",
                table: "TextLayouts",
                newName: "FontSize");

            migrationBuilder.RenameColumn(
                name: "Sender_Font_VerticalAlignment",
                table: "TextLayouts",
                newName: "AddressCardId");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
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
                table: "TextLayouts",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "TextLayoutKind",
                table: "TextLayouts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "FontSize",
                table: "TextLayouts",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TextLayouts",
                table: "TextLayouts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TextLayouts_AddressCardId",
                table: "TextLayouts",
                column: "AddressCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_TextLayouts_AddressCards_AddressCardId",
                table: "TextLayouts",
                column: "AddressCardId",
                principalTable: "AddressCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextLayouts_AddressCards_AddressCardId",
                table: "TextLayouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TextLayouts",
                table: "TextLayouts");

            migrationBuilder.DropIndex(
                name: "IX_TextLayouts_AddressCardId",
                table: "TextLayouts");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "SenderAddressCards");

            migrationBuilder.DropColumn(
                name: "Address1",
                table: "AddressCards");

            migrationBuilder.RenameTable(
                name: "TextLayouts",
                newName: "AddressCardLayouts");

            migrationBuilder.RenameColumn(
                name: "Address2",
                table: "SenderAddressCards",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "IsFamilyPrinting",
                table: "AddressCards",
                newName: "IsAlreadyPrinted");

            migrationBuilder.RenameColumn(
                name: "Address2",
                table: "AddressCards",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "TextLayoutKind",
                table: "AddressCardLayouts",
                newName: "Sender_TextLayoutKind");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "AddressCardLayouts",
                newName: "Sender_Position");

            migrationBuilder.RenameColumn(
                name: "FontSize",
                table: "AddressCardLayouts",
                newName: "Sender_Font_FontSize");

            migrationBuilder.RenameColumn(
                name: "AddressCardId",
                table: "AddressCardLayouts",
                newName: "Sender_Font_VerticalAlignment");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Sender_TextLayoutKind",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<double>(
                name: "Sender_Font_FontSize",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

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
                name: "FontFamilyName",
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

            migrationBuilder.AddColumn<int>(
                name: "SenderPostalCode_Font_VerticalAlignment",
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

            migrationBuilder.AddColumn<int>(
                name: "SenderPostalCode_TextLayoutKind",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sender_Font_FontStyle",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sender_Font_FontWeight",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressCardLayouts",
                table: "AddressCardLayouts",
                column: "Id");
        }
    }
}
