using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppFullStackDemo.Infra.Migrations
{
    public partial class FirstBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedIn = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: false),
                    UpdatedIn = table.Column<DateTime>(nullable: false),
                    ClaimName = table.Column<string>(maxLength: 40, nullable: false),
                    ClaimUrlOpt = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedIn = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: false),
                    UpdatedIn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedIn = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: false),
                    UpdatedIn = table.Column<DateTime>(nullable: false),
                    AditionalInfo = table.Column<string>(maxLength: 200, nullable: false),
                    Document_CountryRegistryNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Document_StateRegistryNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Email_EmailAddress = table.Column<string>(maxLength: 100, nullable: true),
                    Name_FirstName = table.Column<string>(maxLength: 40, nullable: true),
                    Name_LastName = table.Column<string>(maxLength: 80, nullable: true),
                    Phone_MobilePhoneNumber1 = table.Column<string>(maxLength: 20, nullable: true),
                    Phone_MobilePhoneNumber2 = table.Column<string>(maxLength: 20, nullable: true),
                    Phone_PhoneNumber1 = table.Column<string>(maxLength: 20, nullable: true),
                    Phone_PhoneNumber2 = table.Column<string>(maxLength: 20, nullable: true),
                    Address_City = table.Column<string>(maxLength: 60, nullable: true),
                    Address_NeighborHood = table.Column<string>(maxLength: 60, nullable: true),
                    Address_Street = table.Column<string>(nullable: true),
                    Address_StreetNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Address_ZipCode = table.Column<string>(maxLength: 10, nullable: true),
                    UserAccount_Password = table.Column<string>(maxLength: 120, nullable: true),
                    UserAccount_UserName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedIn = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: false),
                    UpdatedIn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ManufacturerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceModel_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedIn = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: false),
                    UpdatedIn = table.Column<DateTime>(nullable: false),
                    ClaimId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_Claim_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedIn = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: false),
                    UpdatedIn = table.Column<DateTime>(nullable: false),
                    AndroidId = table.Column<string>(maxLength: 30, nullable: false),
                    Imei1 = table.Column<string>(maxLength: 30, nullable: true),
                    Imei2 = table.Column<string>(maxLength: 30, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 30, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 30, nullable: true),
                    ApiLevel = table.Column<string>(maxLength: 10, nullable: false),
                    ApiLevelDesc = table.Column<string>(maxLength: 30, nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 40, nullable: true),
                    SystemName = table.Column<string>(maxLength: 20, nullable: true),
                    SystemVersion = table.Column<string>(maxLength: 20, nullable: false),
                    DeviceModelId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_DeviceModel_DeviceModelId",
                        column: x => x.DeviceModelId,
                        principalTable: "DeviceModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceModel_ManufacturerId",
                table: "DeviceModel",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_DeviceModelId",
                table: "Equipment",
                column: "DeviceModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_UserId",
                table: "Equipment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_ClaimId",
                table: "UserClaim",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "DeviceModel");

            migrationBuilder.DropTable(
                name: "Claim");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Manufacturer");
        }
    }
}
