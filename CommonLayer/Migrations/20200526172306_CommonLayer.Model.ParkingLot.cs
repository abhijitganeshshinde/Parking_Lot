using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonLayer.Migrations
{
    public partial class CommonLayerModelParkingLot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingDetail",
                columns: table => new
                {
                    Receipt_Number = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vehicle_Owner_Name = table.Column<string>(nullable: false),
                    Vehicle_Number = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    Driver_Name = table.Column<string>(nullable: false),
                    Parking_Slot = table.Column<string>(nullable: false),
                    ParkingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingDetail", x => x.Receipt_Number);
                });

            migrationBuilder.CreateTable(
                name: "UserDetail",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    User_Type = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetail", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleUnPark",
                columns: table => new
                {
                    VehicleUnParkID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Receipt_Number = table.Column<int>(nullable: false),
                    UnPark = table.Column<DateTime>(nullable: false),
                    TotalTime = table.Column<double>(nullable: false),
                    Total_Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleUnPark", x => x.VehicleUnParkID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingDetail");

            migrationBuilder.DropTable(
                name: "UserDetail");

            migrationBuilder.DropTable(
                name: "VehicleUnPark");
        }
    }
}
