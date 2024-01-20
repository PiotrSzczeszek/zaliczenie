using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zaliczenie.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientDocuments_ClientDocumentTypes_DocumentTypeEntityId",
                table: "ClientDocuments");

            migrationBuilder.DropIndex(
                name: "IX_ClientDocuments_DocumentTypeEntityId",
                table: "ClientDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentTypeEntityId",
                table: "ClientDocuments");

            migrationBuilder.CreateIndex(
                name: "IX_ClientDocuments_DocumentTypeId",
                table: "ClientDocuments",
                column: "DocumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientDocuments_ClientDocumentTypes_DocumentTypeId",
                table: "ClientDocuments",
                column: "DocumentTypeId",
                principalTable: "ClientDocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientDocuments_ClientDocumentTypes_DocumentTypeId",
                table: "ClientDocuments");

            migrationBuilder.DropIndex(
                name: "IX_ClientDocuments_DocumentTypeId",
                table: "ClientDocuments");

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeEntityId",
                table: "ClientDocuments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClientDocuments_DocumentTypeEntityId",
                table: "ClientDocuments",
                column: "DocumentTypeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientDocuments_ClientDocumentTypes_DocumentTypeEntityId",
                table: "ClientDocuments",
                column: "DocumentTypeEntityId",
                principalTable: "ClientDocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
