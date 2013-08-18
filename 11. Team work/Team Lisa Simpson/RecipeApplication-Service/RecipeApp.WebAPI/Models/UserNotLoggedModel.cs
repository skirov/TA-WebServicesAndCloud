using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeApp.WebAPI.Controllers
{
    public class UserNotLoggedModel
    {
        public string Username { get; set; }
        public string AuthCode { get; set; }
    }
}
