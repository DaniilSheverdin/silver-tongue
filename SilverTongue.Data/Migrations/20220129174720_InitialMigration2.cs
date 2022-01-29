using Microsoft.EntityFrameworkCore.Migrations;

namespace SilverTongue.Data.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersDicts_DictionaryId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DictionaryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "English",
                table: "UsersDicts");

            migrationBuilder.DropColumn(
                name: "DictionaryId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UsersDicts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Word",
                table: "UsersDicts",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersDicts_UserId",
                table: "UsersDicts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDicts_Users_UserId",
                table: "UsersDicts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersDicts_Users_UserId",
                table: "UsersDicts");

            migrationBuilder.DropIndex(
                name: "IX_UsersDicts_UserId",
                table: "UsersDicts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsersDicts");

            migrationBuilder.DropColumn(
                name: "Word",
                table: "UsersDicts");

            migrationBuilder.AddColumn<string>(
                name: "English",
                table: "UsersDicts",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DictionaryId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DictionaryId",
                table: "Users",
                column: "DictionaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersDicts_DictionaryId",
                table: "Users",
                column: "DictionaryId",
                principalTable: "UsersDicts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
