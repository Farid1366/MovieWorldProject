using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBLibrary.Migrations
{
    /// <inheritdoc />
    public partial class add_unique_index_movie_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Movie_Name",
                table: "Movie",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movie_Name",
                table: "Movie");
        }
    }
}
