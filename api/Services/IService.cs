using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Services
{
    interface IService
    {
        Boolean SignIn(string username, string password);
        Boolean SignUp(AspNetUser user);
    }
}
