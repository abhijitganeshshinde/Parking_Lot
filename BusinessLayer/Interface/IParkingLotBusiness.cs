using CommonLayer.Models;
using CommonLayer.Responce;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IParkingLotBusiness
    {   // Get All Parking Details
        List<Parking> GetAllParkingCarsDetails();
        // Car Details For Parking The Car
        ParkingLotDetails CarDetailsForParking(ParkingLotDetails details);
        // Car UnPark
        object CarUnPark(VehicleUnPark details);

        // Get Car Details By Vehicle Brand
        object GetCarDetailsByVehicleBrand(string brand);

        // Get Car Details By Vehicle Number
        object GetCarDetailsByVehicleNumber(string VehicalNumber);

        // Parking Lot Status (Full OR Not)
        object ParkingLotStatus();
        // Get Car Details By Parking Slot
        object GetCarDetailsByParkingSlot(string Slot);

        // Get UnPark Car Details
        object GetUnParkCarDetail();
        // Delete Car Details
        object DeleteCarParkingDetails(int ReceiptNumber);

        object GetAllCarDetailsOfHandicap();
    }
}
