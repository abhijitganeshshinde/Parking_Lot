using CommonLayer.Models;
using CommonLayer.Responce;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        object UserRegistration(UserRegistration registration);
        List<UserRegistration> GetAllUserDetails();

        object UserLogin(Login login);
    }
}
