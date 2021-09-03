using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.Abp.DynamicPermission.Migrations
{
    public partial class RenamedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DynamicPermissionPermissionGrants",
                table: "DynamicPermissionPermissionGrants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DynamicPermissionPermissionDefinitions",
                table: "DynamicPermissionPermissionDefinitions");

            migrationBuilder.RenameTable(
                name: "DynamicPermissionPermissionGrants",
                newName: "EasyAbpAbpDynamicPermissionPermissionGrants");

            migrationBuilder.RenameTable(
                name: "DynamicPermissionPermissionDefinitions",
                newName: "EasyAbpAbpDynamicPermissionPermissionDefinitions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EasyAbpAbpDynamicPermissionPermissionGrants",
                table: "EasyAbpAbpDynamicPermissionPermissionGrants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EasyAbpAbpDynamicPermissionPermissionDefinitions",
                table: "EasyAbpAbpDynamicPermissionPermissionDefinitions",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EasyAbpAbpDynamicPermissionPermissionGrants",
                table: "EasyAbpAbpDynamicPermissionPermissionGrants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EasyAbpAbpDynamicPermissionPermissionDefinitions",
                table: "EasyAbpAbpDynamicPermissionPermissionDefinitions");

            migrationBuilder.RenameTable(
                name: "EasyAbpAbpDynamicPermissionPermissionGrants",
                newName: "DynamicPermissionPermissionGrants");

            migrationBuilder.RenameTable(
                name: "EasyAbpAbpDynamicPermissionPermissionDefinitions",
                newName: "DynamicPermissionPermissionDefinitions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DynamicPermissionPermissionGrants",
                table: "DynamicPermissionPermissionGrants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DynamicPermissionPermissionDefinitions",
                table: "DynamicPermissionPermissionDefinitions",
                column: "Name");
        }
    }
}
