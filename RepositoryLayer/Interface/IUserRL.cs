using CommonLayer.Models;
using CommonLayer.Responce;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        // User Registration
        object UserRegistration(UserRegistration details);

        // Get All User Data
        List<UserRegistration> GetAllUserDetails();

        // User Login
        object UserLogin(Login login);
    }
}
