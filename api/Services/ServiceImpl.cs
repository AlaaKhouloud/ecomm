using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api.Models;

namespace api.Services
{
    public class ServiceImpl : IService
    {
        public bool SignIn(string username, string password)
        {
            return true;
        }

        public bool SignUp(AspNetUser user)
        {
            return false;
        }
    }
}