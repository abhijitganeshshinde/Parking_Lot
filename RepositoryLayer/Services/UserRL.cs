using CommonLayer.DBContext;
using CommonLayer.Models;
using CommonLayer.Responce;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RepositoryLayer.Services
{ 
  /// <summary>
  /// This is UserRL Class In This Class
  ///  User Relate Method (Add User Detail , Get User Details ..etc)
  /// </summary>
    public class UserRL : IUserRL
    {

        ParkingLotDBContext db;
        public UserRL(ParkingLotDBContext _db)
        {
            db = _db;
        }

        /// <summary>
        /// This Method For User Registration 
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public object UserRegistration(UserRegistration details)
        {

            try
            {
                // Adding Registration Data
                db.Add(details);
                db.SaveChanges();

                // Quary
                var data = (from userDetails in db.UserDetail
                            where userDetails.UserId == details.UserId
                            select new
                            {
                                userDetails.UserId,
                                userDetails.UserName,
                                userDetails.Email,
                                userDetails.User_Type
                            }).FirstOrDefault();
                // Return User Data 
                return data;

            }
            catch (Exception e)
            {
                //// Exception
                //ResponceMessage myReturnData = new ResponceMessage() { ErrorMessage = "User Data Not Found" };
                //string json = JsonConvert.SerializeObject(myReturnData);
                //return json;
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Method For Getting All User Details
        /// </summary>
        /// <returns></returns>
        public List<UserRegistration> GetAllUserDetails()
        {
            try
            {
                // Return User Data
                return (from userDetails in db.UserDetail
                        select new UserRegistration
                        {
                            UserId = userDetails.UserId,
                            User_Type = userDetails.User_Type,
                            Email = userDetails.Email,
                            UserName = userDetails.UserName,
                            Password = userDetails.Password,
                        }).ToList();
            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// This Mehtod For Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public object UserLogin(Login login)
        {
            try
            {
                // Return Data First Check UserName , Password And UserType Match Or Not
                return (from userDetails in db.UserDetail
                        where login.UserName == userDetails.UserName && login.Password == userDetails.Password && login.User_Type == userDetails.User_Type
                        select new
                        {
                            userDetails.UserId,
                            userDetails.UserName,
                            userDetails.User_Type
                        }).FirstOrDefault();
            }
            catch (Exception e)
            {
                //Exception
                throw new Exception(e.Message);
            }
        }
    }
}