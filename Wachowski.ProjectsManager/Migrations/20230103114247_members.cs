using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wachowski.ProjectsManager.Migrations
{
    /// <inheritdoc />
    public partial class members : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Projects_ProjectId",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Members");

            migrationBuilder.RenameIndex(
                name: "IX_Person_ProjectId",
                table: "Members",
                newName: "IX_Members_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Projects_ProjectId",
                table: "Members",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Projects_ProjectId",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Person");

            migrationBuilder.RenameIndex(
                name: "IX_Members_ProjectId",
                table: "Person",
                newName: "IX_Person_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Projects_ProjectId",
                table: "Person",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
