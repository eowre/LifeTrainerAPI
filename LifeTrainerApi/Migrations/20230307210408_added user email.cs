using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeTrainerApi.Migrations
{
    public partial class addeduseremail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_avatars_AvatarId",
                table: "items");

            migrationBuilder.RenameColumn(
                name: "AvatarId",
                table: "items",
                newName: "AvatarID");

            migrationBuilder.RenameIndex(
                name: "IX_items_AvatarId",
                table: "items",
                newName: "IX_items_AvatarID");

            migrationBuilder.AlterColumn<int>(
                name: "AvatarID",
                table: "items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "avatars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_items_avatars_AvatarID",
                table: "items",
                column: "AvatarID",
                principalTable: "avatars",
                principalColumn: "AvatarId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_avatars_AvatarID",
                table: "items");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "avatars");

            migrationBuilder.RenameColumn(
                name: "AvatarID",
                table: "items",
                newName: "AvatarId");

            migrationBuilder.RenameIndex(
                name: "IX_items_AvatarID",
                table: "items",
                newName: "IX_items_AvatarId");

            migrationBuilder.AlterColumn<int>(
                name: "AvatarId",
                table: "items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_items_avatars_AvatarId",
                table: "items",
                column: "AvatarId",
                principalTable: "avatars",
                principalColumn: "AvatarId");
        }
    }
}
