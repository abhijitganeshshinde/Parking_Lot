﻿using CommonLayer.DBContext;
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
    public class UserRepository : IUserRepository
    {

        ParkingLotDBContext dataBase;
        public UserRepository(ParkingLotDBContext _dataBase)
        {
            dataBase = _dataBase;
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
                dataBase.Add(details);
                dataBase.SaveChanges();

                // Quary
                var data = (from userDetails in dataBase.UserDetail
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
                // Exception
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
                return (from userDetails in dataBase.UserDetail
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
                return (from userDetails in dataBase.UserDetail
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
