using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBLibrary.Migrations
{
    /// <inheritdoc />
    public partial class add_fields_to_moviecast_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CastTypeId",
                table: "MovieCast",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_CastTypeId",
                table: "MovieCast",
                column: "CastTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCast_CastType_CastTypeId",
                table: "MovieCast",
                column: "CastTypeId",
                principalTable: "CastType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCast_CastType_CastTypeId",
                table: "MovieCast");

            migrationBuilder.DropIndex(
                name: "IX_MovieCast_CastTypeId",
                table: "MovieCast");

            migrationBuilder.DropColumn(
                name: "CastTypeId",
                table: "MovieCast");
        }
    }
}
