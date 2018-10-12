using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SahilNameSorterCore.DataAccess.Migrations
{
    public partial class ChangePersonKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
              name: "ID",
              table: "Person");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Person",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);//.Annotation("HasDatabaseGeneratedOption", DatabaseGeneratedOption.Identity);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Person",
                nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                columns: new[] { "ID", "FullName" });
            
           
            migrationBuilder.InsertData(
               
                table: "Person",
                columns: new[] { "ID", "FullName", "FirstName", "Gender", "Surname" },
                values: new object[] { 1, "Sahil Deshpande", "Sahil", null, "Deshpande" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Person",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Person",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "ID",
                keyValue: 1,
                column: "FullName",
                value: null);
        }
    }
}
