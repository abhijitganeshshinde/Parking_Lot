using Microsoft.EntityFrameworkCore.Migrations;

namespace CommonLayer.Migrations
{
    public partial class CommonLayerModelParkingLot2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParkingException",
                table: "ParkingDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkingException",
                table: "ParkingDetail");
        }
    }
}
