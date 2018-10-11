using Microsoft.EntityFrameworkCore.Migrations;

namespace SahilNameSorterCore.DataAccess.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PersonFullNames",
                columns: new[] { "ID", "FirstName", "LastName", "MiddleName", "MiddleNameOptional" },
                values: new object[] { 1, "Sahil", "Deshpande", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonFullNames",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
