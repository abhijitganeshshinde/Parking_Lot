using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ParkingLot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotsController : ControllerBase
    {
        public readonly IParkingLotBusiness parkingLotBusiness;

        public ParkingLotsController(IParkingLotBusiness _parkingLotBusiness)
        {
            parkingLotBusiness = _parkingLotBusiness;
        }

        /// <summary>
        ///  This Method For Car Parking 
        ///  And The HTTP Request Is Post 
        ///  And This Method Only By Admin(Owner)
        ///  Route Address Is api/ParkingLots/Park 
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Park")]
        public ActionResult CarDetailsForParking(ParkingLotDetails details)
        {
            try
            {

                var data = parkingLotBusiness.CarDetailsForParking(details);
                var count = parkingLotBusiness.ParkingLotStatus();
                bool success = false;
                string message;
                if (data == null)
                {
                    success = false;
                    message = "Parking Full";
                    return Ok(new { success, message });
                }
                else
                {
                    success = true;
                    message = "Success";
                    return Ok(new { success, message, data });

                }
            }
            catch
            {
                bool success = false;
                string message = "Fail";
                return BadRequest(new { success, message });
            }

        }


        /// <summary>
        /// This Method For Get All Parking Cars Details
        /// This Method Is Access By Admin And Police Only
        /// This Method Use HTTPGET
        /// This Method Route Is api/ParkingLots
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Police")]
        [HttpGet]
        [Route("")]
        public ActionResult GetAllParkingCarsDetails()
        {
            try
            {
                var data = parkingLotBusiness.GetAllParkingCarsDetails();
                bool success;
                string message;
                if (data == null)
                {
                    success = false;
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
                bool success = false;
                string message = "Fail";
                return BadRequest(new { success, message });
            }
        }

        /// <summary>
        /// This Method For Park Car Need To UnPark That Car Using Receipt Number
        /// This Method Only Use By  Admin Only
        /// This Method Use HTTPPOST
        /// This Mehod Use Route api/ParkingLots/UnPark
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("UnPark")]
        public ActionResult CarUnPark(VehicleUnPark details)
        {
            try
            {
                var data = parkingLotBusiness.CarUnPark(details);
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
                    success = false;
                    message = "Fail To UnPark";
                    return Ok(new { success, message });
                }
            }
            catch
            {
                bool sucess = false;
                string message = "Fail To UnPakr";
                return BadRequest(new { sucess, message });
            }
        }


        /// <summary>
        /// This Method Get UnPakr Car Details
        /// This Method Use By Admin And Driver
        /// This Method Use HTTPGET
        /// This Method Route Is api/ParkingLots/UnPark
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Driver")]
        [HttpGet]
        [Route("UnPark")]
        public ActionResult GetUnParkCarDetail()
        {
            try
            {
                var data = parkingLotBusiness.GetUnParkCarDetail();
                bool success;
                string message;
                if (data == null)
                {
                    success = false;
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
            catch
            {

                bool success = false;
                string message = "Fail";
                return BadRequest(new { success, message });
            }
        }

        /// <summary>
        /// This Method Get Car Details By Parking Slot
        /// This Method Use By Admin And Police
        /// This Method Use HTTPGET
        /// This Method Route Is api/ParkingLots/SearchBuSlot
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Police")]
        [HttpGet]
        [Route("SearchBySlot/{slot}")]
        public ActionResult GetCarDetailsByParkingSlot(string slot)
        {
            try
            {
                var data = parkingLotBusiness.GetCarDetailsByParkingSlot(slot);
                bool success;
                string message;
                if (data == null)
                {
                    success = false;
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
            catch
            {
                bool success = false;
                string message = "Fail To Search";
                return BadRequest(new { success, message });
            }
        }

        /// <summary>
        /// This Method Get Parking Lot Stautus 
        /// This Method Use By Admin And Seurity
        /// This Method Use HTTPGET
        /// This Method Route Is api/ParkingLots/ParkingStatus
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ParkingStatus")]
        [Authorize(Roles = "Admin,Security")]
        public ActionResult ParkingLotStatus()
        {
            try
            {
                var data = parkingLotBusiness.ParkingLotStatus();
                bool success;
                string message;
                if (data.Equals(10))
                {
                    success = false;
                    message = "Parking Full";
                    return Ok(new { success, message });
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
                bool success = false;
                string message = "Fail";
                return BadRequest(new { success, message });
            }
        }

        /// <summary>
        /// This Method Get Car Details By Car Brand
        /// This Method Use By Admin And Police
        /// This Method Use HTTPPOST
        /// This Method Route Is api/ParkingLots/Search
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Police")]
        [HttpPost]
        [Route("Search/{brand}")]
        public ActionResult GetCarDetailsByVehicleBrand(string brand)
        {
            try
            {
                var data = parkingLotBusiness.GetCarDetailsByVehicleBrand(brand);
                bool success = false;
                string message;
                if (data != null)
                {
                    success = true;
                    message = "Search";
                    return Ok(new { success, message, data });
                }
                else
                {
                    success = false;
                    message = "Search Fail";
                    return Ok(new { success, message });
                }
            }
            catch
            {
                bool success = false;
                string message = "Fail To Search";
                return BadRequest(new { success, message });
            }
        }

        /// <summary>
        /// This Method Get Car Details By Vehicle Number
        /// This Method Use By Admin And Police
        /// This Method Use HTTPGET
        /// This Method Route Is api/ParkingLots/Search
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin,Police")]
        [HttpGet]
        [Route("Search/{vehicleNumber}")]
        public ActionResult GetCarDetailsByVehicleNumber(string vehicleNumber)
        {
            try
            {
                var data = parkingLotBusiness.GetCarDetailsByVehicleNumber(vehicleNumber);
                bool success = false;
                string message;
                if (data == null)
                {
                    success = false;
                    message = "Fail To Search";
                    return Ok(new { success, message });
                }
                else
                {
                    success = true;
                    message = "Search ";
                    return Ok(new { success, message, data });


                }
            }
            catch
            {
                bool success = false;
                string message = "Fail To Search";
                return BadRequest(new { success, message });
            }
        }

        /// <summary>
        /// This Method Delete Car Details By ReceiptNumber
        /// This Method Use By Admin
        /// This Method Use HTTPDELETE
        /// This Method Route Is api/ParkingLots
        /// </summary>
        /// <param name="ReceiptNumber"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{ReceiptNumber}")]
        public ActionResult DeleteCarParkingDetails(int ReceiptNumber)
        {
            try
            {
                var data = parkingLotBusiness.DeleteCarParkingDetails(ReceiptNumber);
                bool success = false;
                string message;
                if (data == null)
                {
                    success = false;
                    message = "Fail To Delete";
                    return Ok(new { success, message });
                }
                else
                {
                    success = true;
                    message = "Delete";
                    return Ok(new { success, message, data });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                string message = "Fail To Delete";
                return BadRequest(new { success, message });
            }
        }
    }
}