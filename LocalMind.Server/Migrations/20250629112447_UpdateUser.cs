using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalMind.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_userAdditionalDetails_UserId",
                table: "userAdditionalDetails");

            migrationBuilder.CreateIndex(
                name: "IX_userAdditionalDetails_UserId",
                table: "userAdditionalDetails",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_userAdditionalDetails_UserId",
                table: "userAdditionalDetails");

            migrationBuilder.CreateIndex(
                name: "IX_userAdditionalDetails_UserId",
                table: "userAdditionalDetails",
                column: "UserId");
        }
    }
}
