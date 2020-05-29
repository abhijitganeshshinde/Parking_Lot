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
        [Route("Park")]
        public ActionResult AddParkingDetail(ParkingLotDetails parkingLot)
        {
            try
            {
                var data = parkingLotBL.CarDetailsForParking(parkingLot);
                var count = parkingLotBL.ParkingLotStatus();
                bool success = false;
                string message;
                if (!count.Equals(10))
                {
                    success = true;
                    message = "Success";
                    return Ok(new { success, message, data });
                }
                else
                {
                    success = true;
                    message = "Park Fail Because Parking Full";
                    return Ok(new { success, message });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        [HttpGet]
        [Route("")]
        public ActionResult GetAllParkingDetail()
        {
            try
            {
                var data = parkingLotBL.GetAllParkingLotDetails();
                bool success;
                string message;
                if (data == null)
                {
                    success = true;
                    message = "Fail Get All Parking Data";
                    return Ok(new { success, message });
                }
                else
                {
                    success = true;
                    message = "Successfull Get All Parking Data";
                    return Ok(new { success, message, data });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("UnPark")]
        public ActionResult UnPark(VehicleUnPark vehicleUnPark)
        {
            try
            {
                var data = parkingLotBL.CarUnPark(vehicleUnPark);
                bool success;
                string message;
                if (data != null)
                {
                    success = true;
                    message = "Successfully UnPark";
                    return Ok(new { success, message, data });
                }
                else
                {
                    success = true;
                    message = "Fail To UnPark";
                    return Ok(new { success, message });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [Route("UnPark")]
        public ActionResult UnParkCarDetail()
        {
            try
            {
                var data = parkingLotBL.GetUnParkCarDetail();
                bool success;
                string message;
                if (data == null)
                {
                    success = true;
                    message = "Fail";
                    return Ok(new { success, message });
                }
                else
                {
                    success = true;
                    message = "Get UnPark Car Data";
                    return Ok(new { success, message, data });
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [Route("Search/{slot}")]
        public ActionResult ParkingSlot(string slot)
        {
            try
            {
                var data = parkingLotBL.GetCarDetailsByParkingSlot(slot);
                bool success;
                string message;
                if (data == null)
                {
                    success = true;
                    message = "Fail";
                    return Ok(new { success, message });
                }
                else
                {
                    success = true;
                    message = "Successfully";
                    return Ok(new { success, message, data });
                }
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        [Route("ParkingStatus")]
        public ActionResult ParkingStatus()
        {
            try
            {
                var data = parkingLotBL.ParkingLotStatus();
                bool success;
                string message;
                if (data != null)
                {
                    success = true;
                    message = "Parking Full";
                    return Ok(new { success, message, data });
                }
                else
                {
                    success = true;
                    message = "Parking Avaliable";
                    return Ok(new { success, message, data });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //    [Authorize(Roles = "Admin,Police")]
        [HttpPost]
        [Route("Search/{brand}")]
        public ActionResult GetCarDetailByBrand(string brand)
        {
            try
            {
                var data = parkingLotBL.GetCarDetailsByVehicleBrand(brand);
                bool success = false;
                string message;
                if (data != null)
                {
                    success = true;
                    message = "Successfully Data Get";
                    return Ok(new { success, message, data });
                }
                else
                {
                    message = "Fail";
                    return Ok(new { success, message });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //    [Authorize(Roles = "Admin,Police")]
        [HttpGet]
        [Route("Search/{number}")]
        public ActionResult GetCarDetailByNo(string number)
        {
            try
            {
                var data = parkingLotBL.GetCarDetailsByVehicalNumber(number);
                bool success = false;
                string message;
                if (data == null)
                {
                    success = true;
                    message = "Fail To Search";
                    return Ok(new { success, message });
                }
                else
                {
                    success = true;
                    message = "Successfully Data Get ";
                    return Ok(new { success, message, data });


                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}