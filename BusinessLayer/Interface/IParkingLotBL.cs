using CommonLayer.Models;
using CommonLayer.Responce;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IParkingLotBL
    {
        List<Parking> GetAllParkingLotDetails();
        object CarDetailsForParking(ParkingLotDetails parkingLot);
        object CarUnPark(VehicleUnPark vehicleUnPark);

        object GetCarDetailsByVehicleBrand(string brand);
        object GetCarDetailsByVehicalNumber(string VehicalNumber);

        object ParkingLotStatus();
        object GetCarDetailsByParkingSlot(string Slot);
        object GetUnParkCarDetail();
    }
}
