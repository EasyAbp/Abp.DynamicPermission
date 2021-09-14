using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.Abp.DynamicPermission.Migrations
{
    public partial class RemovedPermissionGrant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EasyAbpAbpDynamicPermissionPermissionGrants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EasyAbpAbpDynamicPermissionPermissionGrants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProviderName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EasyAbpAbpDynamicPermissionPermissionGrants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EasyAbpAbpDynamicPermissionPermissionGrants_Name_ProviderName_ProviderKey",
                table: "EasyAbpAbpDynamicPermissionPermissionGrants",
                columns: new[] { "Name", "ProviderName", "ProviderKey" });
        }
    }
}
