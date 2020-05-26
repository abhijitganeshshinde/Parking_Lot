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

        public UserRegistration AddUserData(UserRegistration registration)
        {
            try
            {
                var data = userRL.AddUserData(registration);
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

        public List<UserRegistration> GetAllUserData()
        {
            try
            {
                var data = userRL.GetAllUserData();
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

        public object Login(Login user)
        {
            try
            {
                var data = userRL.Login(user);
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

        public object Count()
        {
            var data = userRL.Count();

            //if(data.Equals(1))
            //{
            //    return "Parking Full";
            //}
            return data;
        }
    }
}
