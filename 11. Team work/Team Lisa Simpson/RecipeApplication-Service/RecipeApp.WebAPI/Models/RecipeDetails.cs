using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeApp.WebAPI.Models
{
    public class RecipeDetails
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string PrepContent { get; set; }
        public string ImageUrl { get; set; }
        public int LikesCount { get; set; }
        public int UserId { get; set; }
    }
}