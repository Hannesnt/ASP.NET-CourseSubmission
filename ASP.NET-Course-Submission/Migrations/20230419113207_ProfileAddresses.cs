using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_Course_Submission.Migrations
{
    /// <inheritdoc />
    public partial class ProfileAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileAddressEntity_Address_AddressId",
                table: "ProfileAddressEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileAddressEntity_Profiles_ProfileId",
                table: "ProfileAddressEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileAddressEntity",
                table: "ProfileAddressEntity");

            migrationBuilder.RenameTable(
                name: "ProfileAddressEntity",
                newName: "ProfileAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileAddressEntity_AddressId",
                table: "ProfileAddresses",
                newName: "IX_ProfileAddresses_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileAddresses",
                table: "ProfileAddresses",
                columns: new[] { "ProfileId", "AddressId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileAddresses_Address_AddressId",
                table: "ProfileAddresses",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileAddresses_Profiles_ProfileId",
                table: "ProfileAddresses",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileAddresses_Address_AddressId",
                table: "ProfileAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfileAddresses_Profiles_ProfileId",
                table: "ProfileAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileAddresses",
                table: "ProfileAddresses");

            migrationBuilder.RenameTable(
                name: "ProfileAddresses",
                newName: "ProfileAddressEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ProfileAddresses_AddressId",
                table: "ProfileAddressEntity",
                newName: "IX_ProfileAddressEntity_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileAddressEntity",
                table: "ProfileAddressEntity",
                columns: new[] { "ProfileId", "AddressId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileAddressEntity_Address_AddressId",
                table: "ProfileAddressEntity",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileAddressEntity_Profiles_ProfileId",
                table: "ProfileAddressEntity",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
