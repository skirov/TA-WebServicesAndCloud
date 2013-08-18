using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeApp.WebAPI.Models
{
    public class UserDetails
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string SessionKey { get; set; }
    }
}