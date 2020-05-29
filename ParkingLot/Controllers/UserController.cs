using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Models;
using CommonLayer.Responce;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace ParkingLot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;
        private readonly IConfiguration _config;

        public UserController(IUserBL _userBL, IConfiguration config)
        {
            userBL = _userBL;
            _config = config;
        }

        /// <summary>
        /// Get All User Detals
        /// This Method Only Access By Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetAllUserDetails()
        {
            try
            {
                var data = userBL.GetAllUserDetails();
                bool success = false;
                string message;
                if (data == null)
                {
                    success = true;
                    message = "Successfully Get All User Data";
                    return Ok(new { success, message, data });
                }
                else
                {
                    message = "Fail To Get All User Data";
                    return Ok(new { success, message });
                }
            }
            catch (Exception e)
            {
                // Exception
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// This Method For User Registration
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Registration")]
        public ActionResult UserRegistration(UserRegistration registration)
        {
            try
            {
                var data = userBL.UserRegistration(registration);
                bool success = false;
                string message;
                if (data != null)
                {
                    success = true;
                    message = "Registration Successfully";
                    return Ok(new { success, message, data });
                }
                else
                {
                    //  success = true;
                    message = "Registration Fail";
                    return Ok(new { success, message });
                }
            }
            catch (Exception)
            {
                string message = "UserName Or Email Is Already Available In Database";
                //ResponceMessage myReturnData = new ResponceMessage() { ErrorMessage = "UserName Or Email Is Alrady Available In Database" };
                //string json = JsonConvert.SerializeObject(myReturnData);
                return BadRequest(message);
            }
        }


        /// <summary>
        /// This Method For User Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public ActionResult UserLogin(Login login)
        {
            try
            {
                var data = userBL.UserLogin(login);
                bool success = false;
                string message, JsonToken;

                if (data != null)
                {
                    success = true;
                    message = "Login Successfully With " + login.User_Type + " Privilege ";
                    JsonToken = CreateToken(login);
                    return Ok(new { success, message, data, JsonToken });
                }
                else
                {
                    message = "Login Fail";
                    return Ok(new { success, message });
                }
            }
            catch
            {
                ResponceMessage myReturnData = new ResponceMessage() { ErrorMessage = "User Data Not Found" };
                string json = JsonConvert.SerializeObject(myReturnData);
                return Ok(json);
            }
        }

        /// <summary>
        /// This Method Help Us To Generate Token With Role Base
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string CreateToken(Login user)
        {
            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, user.User_Type));
                claims.Add(new Claim("UserName", user.UserName.ToString()));
                claims.Add(new Claim("Password", user.Password.ToString()));

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCreds);
                // Return Token
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }
        }
    }
}