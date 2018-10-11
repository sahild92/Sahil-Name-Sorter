using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SahilNameSorterCore.DataAccess.Migrations
{
    public partial class PersonModelRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonFullNames");

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    FullName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "ID", "FirstName", "FullName", "Gender", "Surname" },
                values: new object[] { 1, "Sahil", null, null, "Deshpande" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.CreateTable(
                name: "PersonFullNames",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    MiddleNameOptional = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonFullNames", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "PersonFullNames",
                columns: new[] { "ID", "FirstName", "LastName", "MiddleName", "MiddleNameOptional" },
                values: new object[] { 1, "Sahil", "Deshpande", null, null });
        }
    }
}
