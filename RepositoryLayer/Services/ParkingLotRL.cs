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

        // Adding Data
        public ParkingLotDetails AddData(ParkingLotDetails parkingLot)
        {
            try
            {
                parkingLot.ParkingDate = DateTime.Now;
                db.Add(parkingLot);
                db.SaveChanges();
                // Return Data
                return parkingLot;

            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }
        }


        public object vehicleUnPark(VehicleUnPark vehicleUnPark)
        {

            //var cal = (from ac in db.ParkingDetail
            //           from bc in db.VehicleUnPark
            //           select new
            //           {
            //               diff = bc.UnPark - ac.ParkingDate,
            //           });

            //double ab = Convert.ToDouble(cal);
            //double calcu = ab * 10;


            try
            {
                //var cal = (from ac in db.ParkingDetail
                //           from bc in db.VehicleUnPark
                //           select new
                //           {
                //               diff = bc.UnPark.Subtract(ac.ParkingDate).TotalMinutes
                //           });

                //var ab = Convert.ToDouble(cal);
                //var calcu = ab * 10;

                double total = db.ParkingDetail
                .Where(p => p.Receipt_Number == vehicleUnPark.Receipt_Number)
                .Select(i => (DateTime.Now.Subtract(i.ParkingDate).TotalMinutes)).Sum();

                vehicleUnPark.UnPark = DateTime.Now;
                vehicleUnPark.Total_Amount = total * 10;
                vehicleUnPark.TotalTime = total;
                db.Add(vehicleUnPark);
                db.SaveChanges();
                // return vehicleUnPark;

                var abcd = (from abc in db.ParkingDetail
                            from a in db.VehicleUnPark
                            where abc.Receipt_Number == vehicleUnPark.Receipt_Number
                            select new
                            {
                                a.Total_Amount,
                                abc.ParkingDate,
                                a.UnPark,
                                abc.Vehicle_Number,
                                //differences =  a.UnPark.Subtract(abc.ParkingDate).TotalMinutes,
                                //    amout = a.Total_Amount =
                                a.TotalTime
                            }).ToList();
                return abcd;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Parking> GetAllParkingLotData()
        {
            try
            {
                // Return Parking Lot Data
                return (from p in db.ParkingDetail
                        select new Parking
                        {
                            Receipt_Number = p.Receipt_Number,
                            Vehicle_Owner_Name = p.Vehicle_Owner_Name,
                            Brand = p.Brand,
                            Color = p.Color,
                            Driver_Name = p.Driver_Name,
                            Parking_Slot = p.Parking_Slot,
                            Vehicle_Number = p.Vehicle_Number,
                            ParkingDate = p.ParkingDate,


                        }).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
