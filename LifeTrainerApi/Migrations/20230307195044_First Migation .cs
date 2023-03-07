using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifeTrainerApi.Migrations
{
    public partial class FirstMigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "avatars",
                columns: table => new
                {
                    AvatarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvatarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    XPLevel = table.Column<int>(type: "int", nullable: false),
                    XP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avatars", x => x.AvatarId);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RewardAmount = table.Column<int>(type: "int", nullable: false),
                    CompletionCount = table.Column<int>(type: "int", nullable: false),
                    AvatarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_items_avatars_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "avatars",
                        principalColumn: "AvatarId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_items_AvatarId",
                table: "items",
                column: "AvatarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "avatars");
        }
    }
}
