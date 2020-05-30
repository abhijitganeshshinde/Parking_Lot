using BusinessLayer.Interface;
using CommonLayer.Models;
using CommonLayer.Responce;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBusiness : IUserBusiness
    {

        public readonly IUserRepository userRL;

        public UserBusiness(IUserRepository _userRL)
        {
            userRL = _userRL;
        }

        /// <summary>
        /// User Registration
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        public object UserRegistration(UserRegistration registration)
        {
            try
            {
                var data = userRL.UserRegistration(registration);
                if (data == null)
                {
                    throw new Exception();
                }
                else
                {
                    return data;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Get All User Details
        /// </summary>
        /// <returns></returns>
        public List<UserRegistration> GetAllUserDetails()
        {
            try
            {
                var data = userRL.GetAllUserDetails();
                if (data == null)
                {
                    throw new Exception();
                }
                else
                {
                    return data;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /// <summary>
        /// User Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public object UserLogin(Login login)
        {
            try
            {

                var data = userRL.UserLogin(login);
                if (login != null)
                {
                    return data;
                }
                else
                {
                    throw new Exception();

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}