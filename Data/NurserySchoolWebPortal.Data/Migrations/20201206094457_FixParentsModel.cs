using Microsoft.EntityFrameworkCore.Migrations;

namespace NurserySchoolWebPortal.Data.Migrations
{
    public partial class FixParentsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Parent_ParentId",
                table: "Children");

            migrationBuilder.DropForeignKey(
                name: "FK_Parent_AspNetUsers_UserId",
                table: "Parent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parent",
                table: "Parent");

            migrationBuilder.RenameTable(
                name: "Parent",
                newName: "Parents");

            migrationBuilder.RenameIndex(
                name: "IX_Parent_UserId",
                table: "Parents",
                newName: "IX_Parents_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Parent_IsDeleted",
                table: "Parents",
                newName: "IX_Parents_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parents",
                table: "Parents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Parents_ParentId",
                table: "Children",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_AspNetUsers_UserId",
                table: "Parents",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Parents_ParentId",
                table: "Children");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_AspNetUsers_UserId",
                table: "Parents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parents",
                table: "Parents");

            migrationBuilder.RenameTable(
                name: "Parents",
                newName: "Parent");

            migrationBuilder.RenameIndex(
                name: "IX_Parents_UserId",
                table: "Parent",
                newName: "IX_Parent_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Parents_IsDeleted",
                table: "Parent",
                newName: "IX_Parent_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parent",
                table: "Parent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Parent_ParentId",
                table: "Children",
                column: "ParentId",
                principalTable: "Parent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parent_AspNetUsers_UserId",
                table: "Parent",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
