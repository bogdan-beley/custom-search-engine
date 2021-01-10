using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomSearchEngine.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoogleCustomSearchRootObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoogleCustomSearchRootObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoogleCustomSearchItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Snippet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleCustomSearchRootObjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoogleCustomSearchItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoogleCustomSearchItems_GoogleCustomSearchRootObjects_GoogleCustomSearchRootObjectId",
                        column: x => x.GoogleCustomSearchRootObjectId,
                        principalTable: "GoogleCustomSearchRootObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoogleCustomSearchItems_GoogleCustomSearchRootObjectId",
                table: "GoogleCustomSearchItems",
                column: "GoogleCustomSearchRootObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoogleCustomSearchItems");

            migrationBuilder.DropTable(
                name: "GoogleCustomSearchRootObjects");
        }
    }
}
