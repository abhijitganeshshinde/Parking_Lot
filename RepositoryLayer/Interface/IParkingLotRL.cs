using CommonLayer.Models;
using CommonLayer.Responce;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IParkingLotRL
    {
        List<Parking> GetAllParkingLotData();
        ParkingLotDetails AddData(ParkingLotDetails parkingLot);
        object vehicleUnPark(VehicleUnPark vehicleUnPark);
    }
}
