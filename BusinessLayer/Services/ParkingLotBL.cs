using BusinessLayer.Interface;
using CommonLayer.Models;
using CommonLayer.Responce;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class ParkingLotBL : IParkingLotBL
    {
        private readonly IParkingLotRL parkingLotRL;
        public ParkingLotBL(IParkingLotRL _parkingLotRL)
        {
            parkingLotRL = _parkingLotRL;
        }

        public List<Parking> GetAllParkingLotData()
        {
            try
            {
                var data = parkingLotRL.GetAllParkingLotData();
                if (data == null)
                {
                    throw new Exception();
                }
                else
                {
                    return data;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public ParkingLotDetails AddData(ParkingLotDetails parkingLot)
        {
            try
            {
                var data = parkingLotRL.AddData(parkingLot);
                if (data == null)
                {
                    throw new Exception();
                }
                else
                {
                    return data;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public object vehicleUnPark(VehicleUnPark vehicleUnPark)
        {
            try
            {
                var data = parkingLotRL.vehicleUnPark(vehicleUnPark);
                var d = parkingLotRL.GetAllParkingLotData();
                if (data == null)
                {
                    throw new Exception();
                }
                else
                {
                    return data;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
