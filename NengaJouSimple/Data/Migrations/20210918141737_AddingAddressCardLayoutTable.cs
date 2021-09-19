using Microsoft.EntityFrameworkCore.Migrations;

namespace NengaJouSimple.Data.Migrations
{
    public partial class AddingAddressCardLayoutTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextLayouts_AddressCards_AddressCardId",
                table: "TextLayouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TextLayouts",
                table: "TextLayouts");

            migrationBuilder.RenameTable(
                name: "TextLayouts",
                newName: "AddressCardLayouts");

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
                newName: "Sender_FontSize");

            migrationBuilder.RenameIndex(
                name: "IX_TextLayouts_AddressCardId",
                table: "AddressCardLayouts",
                newName: "IX_AddressCardLayouts_AddressCardId");

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
                name: "Sender_FontSize",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AddColumn<double>(
                name: "Address_FontSize",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Position",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Text",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Address_TextLayoutKind",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Addressee_FontSize",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Addressee_Position",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Addressee_Text",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Addressee_TextLayoutKind",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PostalCode_FontSize",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode_Position",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode_Text",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode_TextLayoutKind",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SenderAddress_FontSize",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderAddress_Position",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderAddress_Text",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderAddress_TextLayoutKind",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "SenderPostalCode_FontSize",
                table: "AddressCardLayouts",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderPostalCode_Position",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderPostalCode_Text",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderPostalCode_TextLayoutKind",
                table: "AddressCardLayouts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sender_Text",
                table: "AddressCardLayouts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressCardLayouts",
                table: "AddressCardLayouts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCardLayouts_AddressCards_AddressCardId",
                table: "AddressCardLayouts",
                column: "AddressCardId",
                principalTable: "AddressCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressCardLayouts_AddressCards_AddressCardId",
                table: "AddressCardLayouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressCardLayouts",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Address_FontSize",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Address_Position",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Address_Text",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Address_TextLayoutKind",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Addressee_FontSize",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Addressee_Position",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Addressee_Text",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Addressee_TextLayoutKind",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PostalCode_FontSize",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PostalCode_Position",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PostalCode_Text",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "PostalCode_TextLayoutKind",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderAddress_FontSize",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderAddress_Position",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderAddress_Text",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderAddress_TextLayoutKind",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderPostalCode_FontSize",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderPostalCode_Position",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderPostalCode_Text",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "SenderPostalCode_TextLayoutKind",
                table: "AddressCardLayouts");

            migrationBuilder.DropColumn(
                name: "Sender_Text",
                table: "AddressCardLayouts");

            migrationBuilder.RenameTable(
                name: "AddressCardLayouts",
                newName: "TextLayouts");

            migrationBuilder.RenameColumn(
                name: "Sender_TextLayoutKind",
                table: "TextLayouts",
                newName: "TextLayoutKind");

            migrationBuilder.RenameColumn(
                name: "Sender_Position",
                table: "TextLayouts",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "Sender_FontSize",
                table: "TextLayouts",
                newName: "FontSize");

            migrationBuilder.RenameIndex(
                name: "IX_AddressCardLayouts_AddressCardId",
                table: "TextLayouts",
                newName: "IX_TextLayouts_AddressCardId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TextLayouts_AddressCards_AddressCardId",
                table: "TextLayouts",
                column: "AddressCardId",
                principalTable: "AddressCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
