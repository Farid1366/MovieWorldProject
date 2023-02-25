using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBLibrary.Migrations
{
    /// <inheritdoc />
    public partial class add_fields_to_movie_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "IMDB_Rate",
                table: "Movie",
                type: "decimal(3,1)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PublishYear",
                table: "Movie",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "IMDB_Rate",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "PublishYear",
                table: "Movie");
        }
    }
}
