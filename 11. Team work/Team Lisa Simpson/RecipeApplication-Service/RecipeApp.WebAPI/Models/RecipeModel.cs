using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace RecipeApp.WebAPI.Models
{
    public class RecipeModel : RecipeDetails
    {
        private ICollection<Ingredient> ingredients;
        private ICollection<Like> likes;
        private ICollection<Comment> comments;
        private ICollection<Step> steps;

        private static int StaticRecipeId { get; set; }
        public RecipeModel()
        {
            this.ingredients = new HashSet<Ingredient>();
            this.likes = new HashSet<Like>();
            this.comments = new HashSet<Comment>();
            this.steps = new HashSet<Step>();
            RecipeModel.StaticRecipeId = this.RecipeId;
        }


        public ICollection<Step> Steps
        {
            get
            {
                return this.steps;
            }
            set
            {
                this.steps = value;
            }
        }

        public ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        public ICollection<Like> Likes
        {
            get
            {
                return this.likes;
            }
            set
            {
                this.likes = value;
            }
        }

        public ICollection<Ingredient> Ingredients
        {
            get
            {
                return this.ingredients;
            }
            set
            {
                this.ingredients = value;
            }
        }

        public static RecipeModel FromRecipeToRecipeModel(Recipe x)
        {
            return new RecipeModel
            {
                UserId = x.UserId,
                Comments = x.Comments,
                ImageUrl = x.ImageUrl,
                Ingredients = x.Ingredients,
                //Likes = x.Likes,
                LikesCount = x.Likes.Where(l=>l.Recipe_Id == x.RecipeId).Count(),
                PrepContent = x.PrepContent,
                RecipeId = x.RecipeId,
                Steps = x.Steps.OrderBy(s => s.Number).ToList(),
                Title = x.Title
            };
        }

        public static Recipe FromRecipeModeltoRecipe(RecipeModel x, int UserId)
        {
            foreach (var comment in x.Comments)
            {
                comment.UserId = UserId;
            }
            foreach (var like in x.Likes)
            {
                like.User_Id = UserId;
                like.Recipe_Id = x.RecipeId;
            }
            return new Recipe
            {
                UserId = UserId,
                Title = x.Title,
                ImageUrl = x.ImageUrl,
                Ingredients = x.Ingredients,                
                PrepContent = x.PrepContent,
                Likes = x.Likes,
                Comments = x.Comments,
                Steps = x.Steps.OrderBy(s => s.Number).ToList()
            };
        }   
    }
}