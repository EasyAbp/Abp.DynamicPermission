using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.Abp.DynamicPermission.Migrations
{
    public partial class AddedIndexForPermissionGrant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProviderName",
                table: "EasyAbpAbpDynamicPermissionPermissionGrants",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "EasyAbpAbpDynamicPermissionPermissionGrants",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EasyAbpAbpDynamicPermissionPermissionGrants",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpAbpDynamicPermissionPermissionGrants_Name_ProviderName_ProviderKey",
                table: "EasyAbpAbpDynamicPermissionPermissionGrants",
                columns: new[] { "Name", "ProviderName", "ProviderKey" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EasyAbpAbpDynamicPermissionPermissionGrants_Name_ProviderName_ProviderKey",
                table: "EasyAbpAbpDynamicPermissionPermissionGrants");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderName",
                table: "EasyAbpAbpDynamicPermissionPermissionGrants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "EasyAbpAbpDynamicPermissionPermissionGrants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EasyAbpAbpDynamicPermissionPermissionGrants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
