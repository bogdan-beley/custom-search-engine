using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomSearchEngine.Migrations
{
    public partial class AddGoogleCustomSearchItemNavigationProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoogleCustomSearchItems_GoogleCustomSearchRootObjects_GoogleCustomSearchRootObjectId",
                table: "GoogleCustomSearchItems");

            migrationBuilder.AlterColumn<int>(
                name: "GoogleCustomSearchRootObjectId",
                table: "GoogleCustomSearchItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GoogleCustomSearchItems_GoogleCustomSearchRootObjects_GoogleCustomSearchRootObjectId",
                table: "GoogleCustomSearchItems",
                column: "GoogleCustomSearchRootObjectId",
                principalTable: "GoogleCustomSearchRootObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoogleCustomSearchItems_GoogleCustomSearchRootObjects_GoogleCustomSearchRootObjectId",
                table: "GoogleCustomSearchItems");

            migrationBuilder.AlterColumn<int>(
                name: "GoogleCustomSearchRootObjectId",
                table: "GoogleCustomSearchItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_GoogleCustomSearchItems_GoogleCustomSearchRootObjects_GoogleCustomSearchRootObjectId",
                table: "GoogleCustomSearchItems",
                column: "GoogleCustomSearchRootObjectId",
                principalTable: "GoogleCustomSearchRootObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
