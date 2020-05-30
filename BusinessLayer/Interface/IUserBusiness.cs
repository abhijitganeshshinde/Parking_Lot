using CommonLayer.Models;
using CommonLayer.Responce;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBusiness
    {
        // User Registration
        object UserRegistration(UserRegistration registration);
        //Get All User Details
        List<UserRegistration> GetAllUserDetails();
        // User Login
        object UserLogin(Login login);
    }
}
