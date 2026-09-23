using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rentaly.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class MoveCategoryToCarModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Categories_CategoryId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "CarModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_VIN",
                table: "Cars",
                column: "VIN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CategoryId",
                table: "CarModels",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_Categories_CategoryId",
                table: "CarModels",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_Categories_CategoryId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_Cars_VIN",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_CategoryId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "CarModels");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Categories_CategoryId",
                table: "Cars",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
