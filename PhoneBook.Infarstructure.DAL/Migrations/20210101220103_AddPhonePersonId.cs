using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBook.Infarstructure.DAL.Migrations
{
    public partial class AddPhonePersonId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_People_PersonId",
                table: "Phones");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Phones",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_People_PersonId",
                table: "Phones",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_People_PersonId",
                table: "Phones");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Phones",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_People_PersonId",
                table: "Phones",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
