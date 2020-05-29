using CommonLayer.DBContext;
using CommonLayer.Models;
using CommonLayer.Responce;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class ParkingLotRL : IParkingLotRL
    {
        ParkingLotDBContext db;
        public ParkingLotRL(ParkingLotDBContext _db)
        {
            db = _db;
        }

        /// <summary>
        /// Add Car Details 
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public object CarDetailsForParking(ParkingLotDetails details)
        {
            try
            {
                // Conditions 
                bool condition1 = db.ParkingDetail.Any(parkingDetails => parkingDetails.Vehicle_Number == details.Vehicle_Number);
                var condition2 = (from parkingDetails in db.ParkingDetail where parkingDetails.Vehicle_Number == details.Vehicle_Number select parkingDetails.Status == "UnPark").LastOrDefault();
                // Check Same Data Available Or Not By Vehicale Number
                if (!condition1)
                {

                    details.ParkingDate = DateTime.Now;
                    details.Status = "Park";
                    db.Add(details);
                    db.SaveChanges();
                    // Return Data
                    return details;
                }
                else if (condition2)  // Check Second Condition The Data Avaliable With UnPark And Last Data Of That Vehical Number
                {
                    // Current Date And Time
                    details.ParkingDate = DateTime.Now;
                    details.Status = "Park";
                    db.Add(details);
                    db.SaveChanges();
                    // Return Data
                    return details;
                }
                else
                {
                    // If Data Avaliable With Park Status Return This Message
                    return details.Vehicle_Number + " This Car Data Available With Park Status";
                }
            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Car UnPark Using Receipt Number (Receipt Number  Generate In Parking )
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public object CarUnPark(VehicleUnPark details)
        {
            try
            {
                // Quary For Calculating Total Time
                double total = db.ParkingDetail
                    .Where(p => p.Receipt_Number == details.Receipt_Number)
                    .Select(i => (DateTime.Now.Subtract(i.ParkingDate).TotalMinutes)).Sum();
                // Current Date Time
                details.UnParkDate = DateTime.Now;
                // Total Amount Calculating With Total Time
                details.Total_Amount = total * 10;
                // Total Time In Minutes
                details.TotalTime = total;
                // Status
                details.Status = "UnPark";
                // Finding Data With Receipt Number
                var Status = db.ParkingDetail.Find(details.Receipt_Number);
                // Changing Status Park To UnPark
                Status.Status = "UnPark";
                // Undate Changing Status
                db.ParkingDetail.Update(Status);
                // Adding Data In VehicleUnPark Table
                db.Add(details);
                // Save Both Tables (VehicleUnPark And ParkingDetail)
                db.SaveChanges();

                // Quary For Return Data
                var data = (from parkingDetails in db.ParkingDetail
                            where parkingDetails.Receipt_Number == details.Receipt_Number
                            //       join e in db.VehicleUnPark on p.Receipt_Number equals vehicleUnPark.Receipt_Number
                            from q in db.VehicleUnPark
                            select new
                            {
                                parkingDetails.Receipt_Number,
                                parkingDetails.Vehicle_Owner_Name,
                                parkingDetails.Brand,
                                parkingDetails.Color,
                                parkingDetails.Driver_Name,
                                parkingDetails.Parking_Slot,
                                parkingDetails.Vehicle_Number,
                                parkingDetails.ParkingDate,
                                details.UnParkDate,
                                details.TotalTime,
                                details.Total_Amount

                            }).FirstOrDefault();
                // Return Data
                return data;

            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Getting All Parking Details
        /// </summary>
        /// <returns></returns>
        public List<Parking> GetAllParkingCarsDetails()
        {
            try
            {
                // Return Parking Lot Data
                return (from parkingDetails in db.ParkingDetail
                        select new Parking
                        {
                            Receipt_Number = parkingDetails.Receipt_Number,
                            Vehicle_Owner_Name = parkingDetails.Vehicle_Owner_Name,
                            Brand = parkingDetails.Brand,
                            Color = parkingDetails.Color,
                            Driver_Name = parkingDetails.Driver_Name,
                            Parking_Slot = parkingDetails.Parking_Slot,
                            Vehicle_Number = parkingDetails.Vehicle_Number,
                            ParkingDate = parkingDetails.ParkingDate,


                        }).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        /// Getting Data By Vehicle Number
        /// </summary>
        /// <param name="VehicleNumber"></param>
        /// <returns></returns>
        public object GetCarDetailsByVehicleNumber(string VehicleNumber)
        {
            ParkingLotDetails detail = new ParkingLotDetails();
            detail.Vehicle_Number = VehicleNumber;
            try
            {
                // IF Check Data Is Avaliable By Using Vehicle Number
                if (db.ParkingDetail.Any(x => x.Vehicle_Number == VehicleNumber))
                {
                    // Quary For Print All Data Of That Vehicle
                    var VehicleData = (from parkingDetails in db.ParkingDetail
                                       where parkingDetails.Vehicle_Number == VehicleNumber
                                       select parkingDetails).ToList();
                    // Return Data
                    return VehicleData;
                }
                else
                {
                    // Return If Data Not Available
                    return "No Data Available For This " + VehicleNumber + " Number";
                }

            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Get Vehicle Details By Brand
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public object GetCarDetailsByVehicleBrand(string brand)
        {
            try
            {

                // Check Brand Name
                if (db.ParkingDetail.Any(x => x.Brand == brand))
                {
                    // Quary For Get All  Car Detail  Mathcs With Brand Name
                    var VehicleData = (from parkingDetails in db.ParkingDetail
                                       where parkingDetails.Brand == brand
                                       select parkingDetails).ToList();
                    // Return Data
                    return VehicleData;
                }
                else
                {
                    // If Data Not Found
                    return "No Data Available For This " + brand + " Brand";
                }
            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// Get UnPark Car Details
        /// </summary>
        /// <returns></returns>
        public object GetUnParkCarDetail()
        {
            try
            {
                // Return UnPark Car Details
                return (from parkingDetails in db.ParkingDetail
                        join vehicleUnParkDetails in db.VehicleUnPark on parkingDetails.Receipt_Number equals vehicleUnParkDetails.Receipt_Number
                        select new
                        {
                            parkingDetails.Vehicle_Number,
                            parkingDetails.ParkingDate,
                            vehicleUnParkDetails.UnParkDate,
                            vehicleUnParkDetails.TotalTime,
                            vehicleUnParkDetails.Total_Amount
                        }).ToList();

            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method Help To Set Parking Status (Full Or Not)
        /// </summary>
        /// <returns></returns>
        public object ParkingLotStatus()
        {
            try
            {
                // Count How Many Car Is Park
                var park = db.ParkingDetail.Where(parkingDetails => parkingDetails.Status == "Park").Count();
                // Reurn Count
                return park;
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
                // Quary 
                var data = (from parkingDetails in db.ParkingDetail
                            where parkingDetails.Parking_Slot == Slot
                            select new
                            {
                                parkingDetails.Receipt_Number,
                                parkingDetails.Vehicle_Number,
                                parkingDetails.Parking_Slot,
                                parkingDetails.ParkingDate
                            });
                // Return Data
                return data.ToList();
            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }
        }
    }
}
