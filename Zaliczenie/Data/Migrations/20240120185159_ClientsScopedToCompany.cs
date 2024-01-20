using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zaliczenie.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClientsScopedToCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "ClientDocumentTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CompanyId",
                table: "Clients",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDocumentTypes_CompanyId",
                table: "ClientDocumentTypes",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientDocumentTypes_Companies_CompanyId",
                table: "ClientDocumentTypes",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Companies_CompanyId",
                table: "Clients",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientDocumentTypes_Companies_CompanyId",
                table: "ClientDocumentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Companies_CompanyId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CompanyId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_ClientDocumentTypes_CompanyId",
                table: "ClientDocumentTypes");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "ClientDocumentTypes");
        }
    }
}
