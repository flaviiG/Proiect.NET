using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectVisual.Migrations
{
    /// <inheritdoc />
    public partial class Init2Db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Members_MemberId",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.RenameIndex(
                name: "IX_Job_MemberId",
                table: "Jobs",
                newName: "IX_Jobs_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Members_MemberId",
                table: "Jobs",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Members_MemberId",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_MemberId",
                table: "Job",
                newName: "IX_Job_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Members_MemberId",
                table: "Job",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }
    }
}
