using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonLayer.Migrations
{
    public partial class CommonLayerModelParkingLot1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnPark",
                table: "VehicleUnPark",
                newName: "UnParkDate");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "VehicleUnPark",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ParkingDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "VehicleUnPark");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ParkingDetail");

            migrationBuilder.RenameColumn(
                name: "UnParkDate",
                table: "VehicleUnPark",
                newName: "UnPark");
        }
    }
}
