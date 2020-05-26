using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ParkingLot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotsController : ControllerBase
    {
        public readonly IParkingLotBL parkingLotBL;

        public ParkingLotsController(IParkingLotBL _parkingLotBL)
        {
            parkingLotBL = _parkingLotBL;
        }

        [HttpPost]
        [Route("")]
        public ActionResult AddParkingDetail(ParkingLotDetails parkingLot)
        {
            var data = parkingLotBL.AddData(parkingLot);
            bool success = true;
            string message;
            message = "Registration Successfully";
            return Ok(new { success, message, data });
        }

        [HttpGet]
        [Route("")]
        public ActionResult GetAllParkingDetail()
        {
            var data = parkingLotBL.GetAllParkingLotData();
            bool success = true;
            string message;
            message = "Successfull Get All Parking Data";
            return Ok(new { success, message, data });
        }

        [HttpPost]
        [Route("UnPark")]
        public ActionResult UnPark(VehicleUnPark vehicleUnPark)
        {
            var data = parkingLotBL.vehicleUnPark(vehicleUnPark);
            bool success = true;
            string message;
            message = "Successfully UnPark";
            return Ok(new { success, message, data });
        }
    }
}