using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RecipeApp.Models
{
    public class Recipe
    {
        private ICollection<Ingredient> ingredients;
        private ICollection<Like> likes;
        private ICollection<Comment> comments;
        private ICollection<Step> steps;

        public Recipe()
        {
            this.ingredients = new HashSet<Ingredient>();
            this.likes = new HashSet<Like>();
            this.comments = new HashSet<Comment>();
            this.steps = new HashSet<Step>();
        }

        [Key]
        public int RecipeId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string PrepContent { get; set; }
        public string ImageUrl { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Step> Steps
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

        public virtual ICollection<Comment> Comments
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

        public virtual ICollection<Like> Likes
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

        public virtual ICollection<Ingredient> Ingredients
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
    }
}
