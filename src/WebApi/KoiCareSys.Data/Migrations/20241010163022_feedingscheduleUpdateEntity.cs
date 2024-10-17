using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiCareSys.Data.Migrations
{
    /// <inheritdoc />
    public partial class feedingscheduleUpdateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                schema: "koicare",
                table: "pond",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "note",
                schema: "koicare",
                table: "pond",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "food_type",
                schema: "koicare",
                table: "feeding_schedule",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "note",
                schema: "koicare",
                table: "feeding_schedule",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                schema: "koicare",
                table: "pond");

            migrationBuilder.DropColumn(
                name: "note",
                schema: "koicare",
                table: "pond");

            migrationBuilder.DropColumn(
                name: "food_type",
                schema: "koicare",
                table: "feeding_schedule");

            migrationBuilder.DropColumn(
                name: "note",
                schema: "koicare",
                table: "feeding_schedule");
        }
    }
}
