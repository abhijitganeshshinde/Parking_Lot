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
    public class UserRL : IUserRL
    {
        ParkingLotDBContext db;
        public UserRL(ParkingLotDBContext _db)
        {
            db = _db;
        }

        // Adding Data
        public UserRegistration AddUserData(UserRegistration registration)
        {
            try
            {
                db.Add(registration);
                db.SaveChanges();
                // Return Data
                return registration;

            }
            catch (Exception e)
            {
                // Exception
                throw new Exception(e.Message);
            }
        }


        public List<UserRegistration> GetAllUserData()
        {
            // Return User Data
            return (from p in db.UserDetail
                    select new UserRegistration
                    {
                        UserId = p.UserId,
                        User_Type = p.User_Type,
                        Email = p.Email,
                        UserName = p.UserName,
                        Password = p.Password,
                    }).ToList();
        }

        public object Login(Login user)
        {

            //      UserRegistration userRegistration = new UserRegistration();
            try
            {
                if (user.User_Type.Contains("Admin"))
                {
                    return (from login in db.UserDetail
                            from abc in db.ParkingDetail
                            where login.UserName == user.UserName && login.Password == user.Password && login.User_Type == user.User_Type
                            select new
                            {
                                //   login.UserId,
                                //   login.User,
                                //    login.Password,
                                abc.Receipt_Number,
                                abc.Vehicle_Owner_Name,
                                abc.Brand,
                                abc.Color,
                                abc.Driver_Name,
                                abc.Parking_Slot,
                                abc.Vehicle_Number

                            }).ToList();
                }
                else if (user.User_Type.Contains("Police"))
                {
                    return (from login in db.UserDetail
                            from abc in db.ParkingDetail
                            where login.UserName == user.UserName && login.Password == user.Password && login.User_Type == user.User_Type
                            select new
                            {
                                //   login.UserId,
                                //   login.User,
                                //    login.Password,
                                abc.Receipt_Number,
                                abc.Vehicle_Owner_Name,
                                abc.Brand,
                                abc.Color,
                                abc.Driver_Name,
                                abc.Parking_Slot,
                                abc.Vehicle_Number
                                //   abc.Total_Amount
                            }).ToList();

                    //  }
                    //else
                    //{
                    //    return "Not Found";
                    //}
                }
                else if (user.User_Type.Contains("Security"))
                {
                    return (from login in db.UserDetail
                            from abc in db.ParkingDetail
                            where login.UserName == user.UserName && login.Password == user.Password && login.User_Type == user.User_Type
                            select abc
                            ).Count();
                }
                else
                {
                    return (from login in db.UserDetail
                            from abc in db.ParkingDetail
                            where login.UserName == user.UserName && login.Password == user.Password && login.User_Type == user.User_Type
                            select new
                            {
                                abc.Brand,
                                abc.Color,
                                abc.Driver_Name,
                                abc.Parking_Slot,
                                abc.Vehicle_Number
                                //   abc.Total_Amount
                            }).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public object Count()
        {
            return (from p in db.ParkingDetail
                    select p).Count();
        }
    }
}
