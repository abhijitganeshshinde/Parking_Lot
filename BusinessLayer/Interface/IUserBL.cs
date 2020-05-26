using CommonLayer.Models;
using CommonLayer.Responce;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        UserRegistration AddUserData(UserRegistration registration);
        List<UserRegistration> GetAllUserData();
        object Login(Login user);

        object Count();
    }
}
