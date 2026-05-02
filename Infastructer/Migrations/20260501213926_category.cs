using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructer.Migrations
{
    /// <inheritdoc />
    public partial class category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestDetails_Requests_RequestId",
                table: "RequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestHitories_Requests_RequestId",
                table: "RequestHitories");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestHitories_Users_UserId",
                table: "RequestHitories");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Categories_CategoryId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_EmployeeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_TechnicianId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicianCategories_Categories_CategoryId",
                table: "TechnicianCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicianCategories_Users_TechnicianId",
                table: "TechnicianCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDetails_Requests_RequestId",
                table: "RequestDetails",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestHitories_Requests_RequestId",
                table: "RequestHitories",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestHitories_Users_UserId",
                table: "RequestHitories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Categories_CategoryId",
                table: "Requests",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_EmployeeId",
                table: "Requests",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_TechnicianId",
                table: "Requests",
                column: "TechnicianId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicianCategories_Categories_CategoryId",
                table: "TechnicianCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicianCategories_Users_TechnicianId",
                table: "TechnicianCategories",
                column: "TechnicianId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestDetails_Requests_RequestId",
                table: "RequestDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestHitories_Requests_RequestId",
                table: "RequestHitories");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestHitories_Users_UserId",
                table: "RequestHitories");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Categories_CategoryId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_EmployeeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_TechnicianId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicianCategories_Categories_CategoryId",
                table: "TechnicianCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicianCategories_Users_TechnicianId",
                table: "TechnicianCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestDetails_Requests_RequestId",
                table: "RequestDetails",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestHitories_Requests_RequestId",
                table: "RequestHitories",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestHitories_Users_UserId",
                table: "RequestHitories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Categories_CategoryId",
                table: "Requests",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_EmployeeId",
                table: "Requests",
                column: "EmployeeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_TechnicianId",
                table: "Requests",
                column: "TechnicianId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicianCategories_Categories_CategoryId",
                table: "TechnicianCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicianCategories_Users_TechnicianId",
                table: "TechnicianCategories",
                column: "TechnicianId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
