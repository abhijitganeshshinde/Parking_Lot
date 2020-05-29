using BusinessLayer.Interface;
using CommonLayer.Models;
using CommonLayer.Responce;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        public readonly IUserRL userRL;

        public UserBL(IUserRL _userRL)
        {
            userRL = _userRL;
        }

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
