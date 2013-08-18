using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeApp.WebAPI.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
    }
}