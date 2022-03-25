using Microsoft.EntityFrameworkCore.Migrations;

namespace CharacterMatch.Server.Data.Migrations
{
    public partial class addedImgUrlToCharacter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Characters");
        }
    }
}
