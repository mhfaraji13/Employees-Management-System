using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employesmhfdev.Migrations
{
    /// <inheritdoc />
    public partial class AddSystemCodeToDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderNo",
                table: "SystemCodeDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SystemCodeId",
                table: "SystemCodeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SystemCodeDetails_SystemCodeId",
                table: "SystemCodeDetails",
                column: "SystemCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemCodeDetails_SystemCodes_SystemCodeId",
                table: "SystemCodeDetails",
                column: "SystemCodeId",
                principalTable: "SystemCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemCodeDetails_SystemCodes_SystemCodeId",
                table: "SystemCodeDetails");

            migrationBuilder.DropIndex(
                name: "IX_SystemCodeDetails_SystemCodeId",
                table: "SystemCodeDetails");

            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "SystemCodeDetails");

            migrationBuilder.DropColumn(
                name: "SystemCodeId",
                table: "SystemCodeDetails");
        }
    }
}
