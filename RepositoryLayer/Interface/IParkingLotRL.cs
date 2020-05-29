using CommonLayer.Models;
using CommonLayer.Responce;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IParkingLotRL
    {
        // Get All Parking Cars Details
        List<Parking> GetAllParkingCarsDetails();

        // Car Details For Parking The Car
        object CarDetailsForParking(ParkingLotDetails details);

        // Car UnPark 
        object CarUnPark(VehicleUnPark details);

        // Get Car Details By Car Brand
        object GetCarDetailsByVehicleBrand(string brand);

        // Get Car Details By Car Number
        object GetCarDetailsByVehicleNumber(string number);

        // Parking Lot Status (Full Or Not)
        object ParkingLotStatus();

        // Get Car Details By Parking Slot
        object GetCarDetailsByParkingSlot(string Slot);

        // Get All UnPark Car Details
        object GetUnParkCarDetail();

    }
}
