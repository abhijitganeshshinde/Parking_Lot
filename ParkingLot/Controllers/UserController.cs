using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Models;
using CommonLayer.Responce;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ParkingLot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;

        public UserController(IUserBL _userBL)
        {
            userBL = _userBL;
        }


        [HttpGet]
        [Route("")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetAllUserData()
        {
            var data = userBL.GetAllUserData();
            bool success = true;
            string message;
            message = "Successfully Get All User Data";
            return Ok(new { success, message, data });
        }

        [HttpPost]
        [Route("")]
        public ActionResult AddUserDetail(UserRegistration registration)
        {
            var data = userBL.AddUserData(registration);
            bool success = true;
            string message;
            message = "Registration Successfully";
            return Ok(new { success, message, data });
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(Login registration)
        {
            var data = userBL.Login(registration);
            bool success = false;
            string message;

            if (registration.User_Type.Contains("Admin"))
            {
                success = true;
                message = "Login Successfully With Admin Privilege ";
                return Ok(new { success, message, data });
            }
            else if (registration.User_Type.Contains("Police"))
            {
                success = true;
                message = "Login Successfully With Police Privilege ";
                return Ok(new { success, message, data });
            }
            else if (registration.User_Type.Contains("Security"))
            {
                success = true;
                message = "Login Successfully With Security Privilege ";

                if (data.Equals(2))
                {
                    // message = "Parking Full";
                    string status = "Parking Full";
                    return Ok(new { success, message, status });
                }
                else
                {
                    string status = "Parking Available";
                    return Ok(new { success, message, status });
                }

            }
            else
            {
                success = true;
                message = "Login Successfully With Driver Privilege ";
                return Ok(new { success, message, data });
            }
        }

        [HttpGet]
        [Route("count")]
        public ActionResult Count()
        {
            var data = userBL.Count();
            bool success = false;
            string message;

            if (data.Equals(2))
            {
                success = true;
                message = "Parking Full";
                return Ok(new { success, message });
            }
            else
            {
                success = true;
                message = "Parking Avaliable";
                return Ok(new { success, message });
            }
        }
    }
}