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

        public List<Parking> GetAllParkingLotDetails()
        {
            try
            {
                var data = parkingLotRL.GetAllParkingCarsDetails();
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

        public object CarDetailsForParking(ParkingLotDetails parkingLot)
        {
            try
            {
                var data = parkingLotRL.CarDetailsForParking(parkingLot);
                if (data != null)
                {
                    return data;

                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public object CarUnPark(VehicleUnPark vehicleUnPark)
        {
            try
            {
                var data = parkingLotRL.CarUnPark(vehicleUnPark);
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


        public object GetCarDetailsByVehicleBrand(string brand)
        {
            try
            {
                var data = parkingLotRL.GetCarDetailsByVehicleBrand(brand);
                if (data != null)
                {
                    return data;
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public object GetCarDetailsByVehicalNumber(string number)
        {
            try
            {
                var data = parkingLotRL.GetCarDetailsByVehicleNumber(number);
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

        public object ParkingLotStatus()
        {
            try
            {
                var data = parkingLotRL.ParkingLotStatus();
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

        public object GetCarDetailsByParkingSlot(string Slot)
        {
            try
            {
                var data = parkingLotRL.GetCarDetailsByParkingSlot(Slot);
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

        public object GetUnParkCarDetail()
        {
            try
            {
                var data = parkingLotRL.GetUnParkCarDetail();
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
