using CommonLayer.Models;
using CommonLayer.Responce;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        UserRegistration AddUserData(UserRegistration registration);
        List<UserRegistration> GetAllUserData();

        object Login(Login user);

        object Count();
    }
}
