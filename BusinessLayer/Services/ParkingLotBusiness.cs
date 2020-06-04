using BusinessLayer.Interface;
using CommonLayer.DBContext;
using CommonLayer.Models;
using CommonLayer.ParkingLimit;
using CommonLayer.Responce;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Services
{
    public class ParkingLotBusiness : IParkingLotBusiness
    {
        private readonly IParkingLotRepository parkingLotRL;

        private readonly ParkingLotDBContext dataBase;

        ParkingLimit Limit = new ParkingLimit();

        public ParkingLotBusiness(IParkingLotRepository _parkingLotRL)
        {
            parkingLotRL = _parkingLotRL;
        }

        /// <summary>
        /// Get All Parking Car Details 
        /// </summary>
        /// <returns></returns>
        public List<Parking> GetAllParkingCarsDetails()
        {
            try
            {
                var data = parkingLotRL.GetAllParkingCarsDetails();
                // Check IF Data Equal To Null 
                if (data == null)
                {
                    // IF Data Null Throw Exception
                    throw new Exception();
                }
                else
                {
                    // Return Data
                    return data;
                }
            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// Car Details For Parking The Car
        /// </summary>
        /// <param name="parkingLot"></param>
        /// <returns></returns>
        public ParkingLotDetails CarDetailsForParking(ParkingLotDetails parkingLot)
        {
            try
            {
                var data = parkingLotRL.CarDetailsForParking(parkingLot);
                var condition = dataBase.ParkingDetail.Where(parkingDetails => parkingDetails.Parking_Slot == "A").Count();
                var condition1 = dataBase.ParkingDetail.Where(parkingDetails => parkingDetails.Parking_Slot == "B").Count();
                if (condition != Limit.Parking_Slot_A)
                {
                    // Return Data
                    parkingLot.Parking_Slot = "A";
                    return data;

                }
                else if (condition1 != Limit.Parking_Slot_B)
                {
                    parkingLot.Parking_Slot = "B";
                    return data;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Car UnPark
        /// </summary>
        /// <param name="vehicleUnPark"></param>
        /// <returns></returns>
        public object CarUnPark(VehicleUnPark vehicleUnPark)
        {
            try
            {
                var data = parkingLotRL.CarUnPark(vehicleUnPark);
                // Check IF Data Equal To Null 
                if (data == null)
                {
                    // IF Data Null Throw Exception
                    throw new Exception();
                }
                else
                {
                    // Return Data
                    return data;
                }
            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        ///  Get Car Details By Vehicle Brand
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public object GetCarDetailsByVehicleBrand(string brand)
        {
            try
            {
                var data = parkingLotRL.GetCarDetailsByVehicleBrand(brand);
                // Check IF Data Equal To Null Or Not
                if (data != null)
                {
                    // Return data
                    return data;
                }
                else
                {
                    // IF Data Null Throw Exception
                    throw new Exception();
                }

            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Get Car Details By Vehicle Number
        /// </summary>
        /// <param name="vehicleNumber"></param>
        /// <returns></returns>
        public object GetCarDetailsByVehicleNumber(string VehicleNumber)
        {
            try
            {
                var data = parkingLotRL.GetCarDetailsByVehicleNumber(VehicleNumber);
                // Check IF Data Equal To Null 
                if (data == null)
                {
                    // IF Data Null Throw Exception
                    throw new Exception();
                }
                else
                {
                    // Return
                    return data;

                }
            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Parking Lot Status
        /// </summary>
        /// <returns></returns>
        public object ParkingLotStatus()
        {
            try
            {
                var data = parkingLotRL.ParkingLotStatus();
                // Check IF Data Equal To Null 
                if (data == null)
                {
                    // IF Data Null Throw Exception
                    throw new Exception();
                }
                else
                {
                    // Return data
                    return data;
                }
            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        /// Get Car Details By Parking Slot
        /// </summary>
        /// <param name="Slot"></param>
        /// <returns></returns>
        public object GetCarDetailsByParkingSlot(string Slot)
        {
            try
            {
                var data = parkingLotRL.GetCarDetailsByParkingSlot(Slot);
                // Check IF Data Equal To Null 
                if (data == null)
                {
                    // IF Data Null Throw Exception
                    throw new Exception();
                }
                else
                {
                    // Return Data
                    return data;
                }
            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Get UnParkCarDetails
        /// </summary>
        /// <returns></returns>
        public object GetUnParkCarDetail()
        {
            try
            {
                var data = parkingLotRL.GetUnParkCarDetail();
                // Check IF Data Equal To Null 
                if (data == null)
                {
                    // IF Data Null Throw Exception
                    throw new Exception();
                }
                else
                {
                    // Return data
                    return data;
                }
            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }
        }


        public object DeleteCarParkingDetails(int ReceiptNumber)
        {
            try
            {
                var data = parkingLotRL.DeleteCarParkingDetails(ReceiptNumber);
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
                // Exception
                throw new Exception(e.Message);

            }
        }

        /// <summary>
        /// Get All  Car Details Of Handiicap
        /// </summary>
        /// <returns></returns>

        public object GetAllCarDetailsOfHandicap()
        {
            try
            {
                var data = parkingLotRL.GetAllCarDetailsOfHandicap();
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
                // Exception
                throw new Exception(e.Message);

            }
        }
    }
}