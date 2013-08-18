using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeApp.WebAPI.Controllers
{
    public class UserLoggedModel
    {
        public string Username { get; set; }
        public string SessionKey { get; set; }
    }
}
