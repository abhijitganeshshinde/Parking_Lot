using CommonLayer.Models;
using CommonLayer.Responce;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IParkingLotBL
    {
        List<Parking> GetAllParkingLotData();
        ParkingLotDetails AddData(ParkingLotDetails parkingLot);
        object vehicleUnPark(VehicleUnPark vehicleUnPark);
    }
}
