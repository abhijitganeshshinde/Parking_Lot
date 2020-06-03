using CommonLayer.Models;
using CommonLayer.Responce;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IParkingLotRepository
    {
        // Get All Parking Cars Details
        List<Parking> GetAllParkingCarsDetails();

        // Car Details For Parking The Car
        ParkingLotDetails CarDetailsForParking(ParkingLotDetails details);

        // Car UnPark 
        object CarUnPark(VehicleUnPark details);

        // Get Car Details By Car Brand
        object GetCarDetailsByVehicleBrand(string brand);

        // Get Car Details By Car Number
        object GetCarDetailsByVehicleNumber(string VehicleNumber);

        // Parking Lot Status (Full Or Not)
        object ParkingLotStatus();

        // Get Car Details By Parking Slot
        object GetCarDetailsByParkingSlot(string Slot);

        // Get All UnPark Car Details
        object GetUnParkCarDetail();

        // Delete Car Data
        object DeleteCarParkingDetails(int ReceiptNumber);

        // Get All Car Details Of Handicap
        object GetAllCarDetailsOfHandicap();


    }
}
